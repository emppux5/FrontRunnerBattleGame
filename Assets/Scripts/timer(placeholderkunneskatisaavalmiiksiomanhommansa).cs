using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Timer : MonoBehaviour
{
    public float startTime = 10f;
    private float currentTime;

    //public Text timerText;
    public TMP_Text timerText; 

    public GameObject GameOverPanel;

    void Start()
    {
        currentTime = startTime;
        GameOverPanel.SetActive(false);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOverPanel.SetActive(true);
        }

        timerText.text = currentTime.ToString("0");
    }
}
