using UnityEngine;

public class taustapyöriiloopil : MonoBehaviour
{
    public float backgroundHeight = 10f;

    void Update()
    {
        if (Camera.main.transform.position.y - transform.position.y > backgroundHeight)
        {
            transform.position += new Vector3(0, backgroundHeight * 2f, 0);
        }
    }
}
