using UnityEngine;

public class automaattiskrollaus : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
