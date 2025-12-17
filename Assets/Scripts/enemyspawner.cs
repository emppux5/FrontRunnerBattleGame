using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public RectTransform canvasRect;
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
            return;

        int index = Random.Range(0, enemyPrefabs.Length);

        float halfWidth = canvasRect.rect.width / 2f;
        float spawnY = canvasRect.rect.height / 2f + 50f;

        bool fromRight = Random.value > 0.5f;

        float spawnX = fromRight ? halfWidth : -halfWidth;

        Vector2 spawnPos = new Vector2(spawnX, spawnY);

        GameObject enemyObj = Instantiate(enemyPrefabs[index], canvasRect);

        RectTransform rt = enemyObj.GetComponent<RectTransform>();
        rt.localScale = Vector3.one;
        rt.anchoredPosition = spawnPos;

        EnemyUI enemyUI = enemyObj.GetComponent<EnemyUI>();
        if (enemyUI != null)
        {
            enemyUI.playerUnits = FindObjectOfType<PlayerUnits>();
        }
    }
}
