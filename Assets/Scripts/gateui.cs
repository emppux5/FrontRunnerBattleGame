using UnityEngine;

public class GateUI : MonoBehaviour
{
    public int bonusUnits = 10;
    public PlayerUnits playerUnits;

    public void ActivateGate()
    {
        if (playerUnits != null)
        {
            playerUnits.AddUnits(bonusUnits);
            Debug.Log("Gate activated! Bonus annettu: " + bonusUnits + " yksikköä.");
        }
        else
        {
            Debug.LogWarning("PlayerUnits-komponenttia ei ole asetettu GateUI:lle!");
        }
    }
}
