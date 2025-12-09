using UnityEngine;

public class liikkumisskripti : MonoBehaviour
{
    public float sideSpeed = 5f;
    private float fixedY;
    private float minX, maxX;
    private float halfWidth;

    public Transform armyGroup;
    public float armyFollowDistance = 1f;

    void Start()
    {
        fixedY = transform.position.y;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            halfWidth = sr.bounds.extents.x;
        }
        else
        {
            halfWidth = 0.5f;
        }

        Camera cam = Camera.main;
        float distance = Mathf.Abs(cam.transform.position.z - transform.position.z);

        Vector3 leftBoundary = cam.ScreenToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightBoundary = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, distance));

        minX = leftBoundary.x + halfWidth;
        maxX = rightBoundary.x - halfWidth;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * h * sideSpeed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = fixedY;

        transform.position = pos;
        if (armyGroup != null)
        {
            Vector3 armyTargetPos = transform.position + Vector3.left * armyFollowDistance;
            armyGroup.position = Vector3.Lerp(armyGroup.position, armyTargetPos, 5f * Time.deltaTime);
        }
    }
}
