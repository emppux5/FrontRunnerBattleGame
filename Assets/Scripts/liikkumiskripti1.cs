using UnityEngine;

public class UILiikkumisskripti : MonoBehaviour
{
    public float sideSpeed = 500f;
    private float minX, maxX;
    private float halfWidth;

    public RectTransform armyGroup;
    public float armyFollowDistance = 50f;

    private RectTransform rectTransform;
    private RectTransform canvasRect;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        halfWidth = rectTransform.rect.width / 2f;

        minX = -canvasRect.rect.width / 2f + halfWidth;
        maxX = canvasRect.rect.width / 2f - halfWidth;

        Vector2 pos = rectTransform.anchoredPosition;
        pos.x = 0;
        rectTransform.anchoredPosition = pos;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 pos = rectTransform.anchoredPosition;
        pos.x += h * sideSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rectTransform.anchoredPosition = pos;

        if (armyGroup != null)
        {
            Vector2 armyTargetPos = pos + Vector2.left * armyFollowDistance;
            armyGroup.anchoredPosition = Vector2.Lerp(armyGroup.anchoredPosition, armyTargetPos, 5f * Time.deltaTime);
        }
    }
}
