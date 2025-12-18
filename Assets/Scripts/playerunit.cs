using UnityEngine;
using UnityEngine.UI;

public class PlayerUnits : MonoBehaviour
{
    public int unitCount = 10;
    public bool isGameOver = false;

    public Slider healthBar;

    void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = unitCount;
            healthBar.value = unitCount;
        }
    }

    public void AddUnits(int amount)
    {
        if (isGameOver) return;

        unitCount += amount;

        if (unitCount <= 0)
        {
            unitCount = 0;
            GameOver();
        }

        if (healthBar != null)
        {
            healthBar.value = unitCount;
        }

        Debug.Log("UnitCount nyt: " + unitCount);
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}
