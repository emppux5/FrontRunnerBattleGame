using UnityEngine;

public class PlayerArmy : MonoBehaviour
{
    public Transform[] soldiers;       
    public Transform playerTransform; 
    public float spacing = 0.5f;

    void Update()
    {
        if (playerTransform == null) return;

        for (int i = 0; i < soldiers.Length; i++)
        {
            Vector3 targetPos = playerTransform.position;
            targetPos.x -= (i + 1) * spacing;
            targetPos.y = playerTransform.position.y;

            soldiers[i].position = Vector3.Lerp(soldiers[i].position, targetPos, 5f * Time.deltaTime);
        }
    }
}
