using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public float fallSpeed = 200f;
    private RectTransform rectTransform;

    public PlayerUnits playerUnits;
    public int damageAmount = 5;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (playerUnits == null)
        {
            playerUnits = FindObjectOfType<PlayerUnits>();
        }
    }

    void Update()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        pos.y -= fallSpeed * Time.deltaTime;
        rectTransform.anchoredPosition = pos;

        if (pos.y < -Screen.height)
        {
            if (playerUnits != null)
            {
                playerUnits.AddUnits(-damageAmount);
                Debug.Log("Vihollinen läpäisi! -" + damageAmount);
            }

            Destroy(gameObject);
        }
    }
}
