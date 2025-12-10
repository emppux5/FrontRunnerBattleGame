using UnityEngine;

public class katinhommatesti : MonoBehaviour
{
    [Header("Pelaaja")]
    public int playerUnits = 5;
    public int playerDamagePerUnit = 1;

    [Header("Vihollinen")]
    public bool enemyUsesHp = false;
    public int enemyUnits = 5;
    public int enemyHp = 150;
    public int enemyDamagePerUnit = 10;

    [Header("Aikaviiveet")]
    public float enemyShootInterval = 1f; // vihollinen ampuu 1 sek välein

    public System.Action OnPlayerDeath;
    public System.Action OnEnemyDefeated;

    private bool battleActive = true;

    private void Start()
    {
        // Aloitetaan vihollisen automaattinen ammunta,joka määritettiin ylempänä
        StartCoroutine(EnemyShootLoop());
    }

    private void Update()
    {
        if (!battleActive) return;

        // Pelaaja ampuu mousebutton 1 
        if (Input.GetMouseButtonDown(0))
        {
            PlayerShoot();
        }
    }

    // minun eli pelaajan ammunta loop
    void PlayerShoot()
    {
        if (!battleActive) return;

        int dmg = playerUnits * playerDamagePerUnit;
        ApplyDamageToEnemy(dmg);

        Debug.Log($"Pelaaja ampui ja teki {dmg} dmg");

        CheckBattleEnd();
    }

    //bottien ammunta loop
    System.Collections.IEnumerator EnemyShootLoop()
    {
        while (battleActive)
        {
            yield return new WaitForSeconds(enemyShootInterval);

            EnemyShoot();
        }
    }

    void EnemyShoot()
    {
        if (!battleActive) return;
        if (!EnemyIsAlive()) return;

        int dmg = enemyUsesHp ? enemyHp : enemyUnits * enemyDamagePerUnit;
        ApplyDamageToPlayer(dmg);

        Debug.Log($"Vihollinen ampui ja teki {dmg} dmg");

        CheckBattleEnd();
    }

    [Header("UI")]
    public GameObject gameOverPanel;

    // tarkistetaan onko pelaajat yhöä hengissä jos ei taistelu lopetetaan
    void CheckBattleEnd()
    {
        if (!PlayerIsAlive())
        {
            battleActive = false;
            Debug.Log("Kuolit! GAME OVER");

            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            OnPlayerDeath?.Invoke();
        }
        else if (!EnemyIsAlive())
        {
            battleActive = false;
            Debug.Log("Voitto!");

            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            OnEnemyDefeated?.Invoke();
        }
    }

    // funktiot  
    bool PlayerIsAlive() => playerUnits > 0;

    bool EnemyIsAlive() => enemyUsesHp ? enemyHp > 0 : enemyUnits > 0;

    void ApplyDamageToEnemy(int dmg)
    {
        if (enemyUsesHp)
        {
            enemyHp -= dmg;
            if (enemyHp < 0) enemyHp = 0;
        }
        else
        {
            enemyUnits -= dmg;
            if (enemyUnits < 0) enemyUnits = 0;
        }
    }

    void ApplyDamageToPlayer(int dmg)
    {
        playerUnits -= dmg;
        if (playerUnits < 0) playerUnits = 0;
    }
}
