using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Voit vaihtaa RectTransform -> GameObject helpottamaan asetusta inspectorissa
    public GameObject canvasGameObject;
    private RectTransform canvasRect;

    public GameObject[] enemyPrefabs;

    public float spawnInterval = 5f;

    public int minEnemiesPerSpawn = 1;
    public int maxEnemiesPerSpawn = 5;

    public int maxTotalEnemies = 100;  // Max vihollisten m‰‰r‰ koko pelin aikana

    private float timer = 0f;
    private int totalSpawnedEnemies = 0;

    void Start()
    {
        if (canvasGameObject != null)
        {
            canvasRect = canvasGameObject.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Canvas GameObject not assigned!");
        }
    }

    void Update()
    {
        if (canvasRect == null)
            return;

        if (totalSpawnedEnemies >= maxTotalEnemies)
            return;  // Ei en‰‰ spawnata

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;

            int spawnCount = Random.Range(minEnemiesPerSpawn, maxEnemiesPerSpawn + 1);

            // Varmistetaan, ettei ylitet‰ maksimim‰‰r‰‰
            int canSpawn = maxTotalEnemies - totalSpawnedEnemies;
            spawnCount = Mathf.Min(spawnCount, canSpawn);

            for (int i = 0; i < spawnCount; i++)
            {
                SpawnEnemy();
                totalSpawnedEnemies++;
            }
        }
    }

    public void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0 || canvasRect == null)
            return;

        int index = Random.Range(0, enemyPrefabs.Length);

        float halfWidth = canvasRect.rect.width / 2f;
        float spawnY = canvasRect.rect.height / 2f + 50f;

        // P‰‰tet‰‰n kummalta sivulta vihollinen tulee
        bool fromRight = Random.value > 0.5f;

        // SpawnX joko oikealta tai vasemmalta, hieman randomisti 
        float baseSpawnX = fromRight ? halfWidth : -halfWidth;

        // Lis‰t‰‰n spawnX:lle pieni satunnainen siirto (mutta pidet‰‰n spawn oikealla puolella)
        float randomOffset = Random.Range(0, halfWidth / 2f);
        float spawnX = fromRight ? baseSpawnX - randomOffset : baseSpawnX + randomOffset;

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
