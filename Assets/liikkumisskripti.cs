using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sideSpeed = 5f;   
    private float fixedY;  

    void Start()
    {
        fixedY = transform.position.y;  
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); 

        transform.Translate(Vector3.right * h * sideSpeed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = fixedY;
        transform.position = pos;
    }
}
