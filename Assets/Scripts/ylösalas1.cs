using UnityEngine;

public class UILoopBackgroundVertical : MonoBehaviour
{
    public float backgroundHeight = 1000f; 

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 pos = rectTransform.anchoredPosition;

        pos.y -= Time.deltaTime * 100f;
        if (pos.y <= -backgroundHeight)
        {
            pos.y += backgroundHeight;
        }

        rectTransform.anchoredPosition = pos;
    }
}

