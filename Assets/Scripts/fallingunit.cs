using UnityEngine;

public class FallingUnit : MonoBehaviour
{
    public float fallSpeed = 200f;
    private RectTransform rectTransform;
    private bool collected = false;

    private GateUI gateUI;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        gateUI = GetComponent<GateUI>(); // ?? TÄRKEÄ RIVI
    }

    void Update()
    {
        if (!collected)
        {
            Vector2 pos = rectTransform.anchoredPosition;
            pos.y -= fallSpeed * Time.deltaTime;
            rectTransform.anchoredPosition = pos;

            if (pos.y < -Screen.height)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Collect()
    {
        if (collected) return;

        collected = true;

        if (gateUI != null)
        {
            gateUI.ActivateGate();
        }
        else
        {
            Debug.LogWarning("GateUI puuttuu FallingUnitista!");
        }

        Destroy(gameObject);
    }
}
