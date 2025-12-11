using UnityEngine;

public class PlayerUnits : MonoBehaviour
{
    public int unitCount = 10;

    public void AddUnits(int amount)
    {
        unitCount += amount;
        Debug.Log("Yksiköitä lisätty: " + amount + ", yhteensä nyt: " + unitCount);
    }
}
