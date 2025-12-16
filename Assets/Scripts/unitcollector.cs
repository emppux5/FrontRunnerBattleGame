using UnityEngine;

public class UnitCollector : MonoBehaviour
{
    public RectTransform playerRectTransform;

    void Update()
    {
        foreach (var unit in FindObjectsOfType<FallingUnit>())
        {
            if (RectTransformOverlaps(playerRectTransform, unit.GetComponent<RectTransform>()))
            {
                unit.Collect();
            }
        }
    }

    bool RectTransformOverlaps(RectTransform rt1, RectTransform rt2)
    {
        Vector3[] corners1 = new Vector3[4];
        Vector3[] corners2 = new Vector3[4];

        rt1.GetWorldCorners(corners1);
        rt2.GetWorldCorners(corners2);

        Rect rect1 = new Rect(corners1[0], corners1[2] - corners1[0]);
        Rect rect2 = new Rect(corners2[0], corners2[2] - corners2[0]);

        return rect1.Overlaps(rect2);
    }
}
