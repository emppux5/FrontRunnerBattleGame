using UnityEngine;
using System;

public class FallingUnit : MonoBehaviour
{
    public float fallSpeed = 200f;
    private RectTransform rectTransform;
    private bool collected = false;

    private GateUI gateUI;

    // Tapahtuma, joka ilmoittaa kun yksikkö tuhoutuu tai kerätään
    public event Action OnUnitDestroyed;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        gateUI = GetComponent<GateUI>();
    }

    void Update()
    {
        if (!collected)
        {
            Vector2 pos = rectTransform.anchoredPosition;
            pos.y -= fallSpeed * Time.deltaTime;
            rectTransform.anchoredPosition = pos;

            // Rajan määrittely, milloin yksikkö tuhoutuu (kun putoaa pois näytöltä)
            float bottomLimit = -GetComponentInParent<Canvas>().GetComponent<RectTransform>().rect.height / 2f - 100f;
            if (pos.y < bottomLimit)
            {
                DestroyUnit();
            }
        }
    }

    public void Collect()
    {
        if (collected) return;

        collected = true;

        Debug.Log("Bonus kerätty!");

        if (gateUI != null)
        {
            gateUI.ActivateGate();
        }
        else
        {
            Debug.LogWarning("GateUI puuttuu FallingUnitista!");
        }

        DestroyUnit();
    }

    void DestroyUnit()
    {
        // Ilmoitetaan kuolemasta spawnerille
        OnUnitDestroyed?.Invoke();

        Destroy(gameObject);
    }
}
