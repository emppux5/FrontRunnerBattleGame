using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public float fallSpeed = 200f;
    private RectTransform rectTransform;

    public PlayerUnits playerUnits;
    public RectTransform playerRectTransform;  // Viittaus pelaajan UI-elementtiin (RectTransform)
    public int damageAmount = 10;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (playerUnits == null)
            playerUnits = FindObjectOfType<PlayerUnits>();

        if (playerRectTransform == null && playerUnits != null)
            playerRectTransform = playerUnits.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 pos = rectTransform.anchoredPosition;
        pos.y -= fallSpeed * Time.deltaTime;
        rectTransform.anchoredPosition = pos;

        // Tarkista osuuko vihollinen pelaajaan
        if (IsOverlapping(rectTransform, playerRectTransform))
        {
            if (playerUnits != null)
            {
                playerUnits.AddUnits(-damageAmount);
                Debug.Log("Vihollinen osui pelaajaan! -" + damageAmount);
            }
            Destroy(gameObject);
            return;
        }

        // Tarkista jos vihollinen menee ohi (ruudun alapuolelle)
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

    bool IsOverlapping(RectTransform a, RectTransform b)
    {
        if (a == null || b == null)
            return false;

        Rect rectA = GetWorldRect(a);
        Rect rectB = GetWorldRect(b);

        return rectA.Overlaps(rectB);
    }

    Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        Vector3 position = corners[0];
        Vector2 size = new Vector2(rt.rect.width * rt.lossyScale.x, rt.rect.height * rt.lossyScale.y);
        return new Rect(position.x, position.y, size.x, size.y);
    }
}

