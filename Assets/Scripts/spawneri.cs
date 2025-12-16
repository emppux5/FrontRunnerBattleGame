using UnityEngine;

public class FallingUnitSpawner : MonoBehaviour
{
    public RectTransform canvasRect;
    public GameObject[] fallingUnitPrefabs;
    public float spawnY;
    public float spawnInterval = 5f;

    private float timer = 0f;
    private bool canSpawn = true;

    void Start()
    {
        spawnY = canvasRect.rect.height / 2f + 50f;
    }

    void Update()
    {
        if (!canSpawn) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnUnit();
            canSpawn = false; // estet‰‰n spawn, kunnes nykyinen on ker‰tty tai tuhoutunut
        }
    }

    void SpawnUnit()
    {
        int prefabIndex = Random.Range(0, fallingUnitPrefabs.Length);

        float spawnX = Random.Range(0, canvasRect.rect.width) - canvasRect.rect.width / 2f;
        float spawnY = canvasRect.rect.height / 2f + 50f;

        Vector2 spawnPos = new Vector2(spawnX, spawnY);

        GameObject unitObj = Instantiate(fallingUnitPrefabs[prefabIndex], canvasRect);
        RectTransform rt = unitObj.GetComponent<RectTransform>();
        rt.localScale = Vector3.one; // varmista skaalaus
        rt.anchoredPosition = spawnPos;

        FallingUnit fallingUnit = unitObj.GetComponent<FallingUnit>();
        if (fallingUnit != null)
        {
            fallingUnit.OnUnitDestroyed += OnUnitDestroyed;
        }
    }


    // Callback kun unit poistuu
    void OnUnitDestroyed()
    {
        canSpawn = true; // sallitaan uuden spawn
    }
}
