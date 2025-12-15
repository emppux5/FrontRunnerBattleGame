using UnityEngine;

public class FallingUnitSpawner : MonoBehaviour
{
    public GameObject[] fallingUnitPrefabs;
    public RectTransform canvasRect;
    public float spawnInterval = 5f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnAll();
            timer = 0f;
        }
    }

    void SpawnAll()
    {
        foreach (GameObject prefab in fallingUnitPrefabs)
        {
            if (prefab == null) continue;

            GameObject go = Instantiate(prefab, canvasRect);
            RectTransform rt = go.GetComponent<RectTransform>();

            rt.anchoredPosition = new Vector2(
                Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f),
                canvasRect.rect.height / 2f + 100f
            );
        }
    }
}
