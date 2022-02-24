using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public LineRenderer lineRenderer;
    public int vertexCount = 12;
    private bool isHolding = true;
    void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.startColor = Color.gray;
        lineRenderer.endColor = Color.gray;
        lineRenderer.material.color = Color.gray;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                isHolding = false;
                lineRenderer.positionCount = 0;
                Destroy(GetComponent<DrawTrajectory>());
            }
        }
        if(isHolding)
        {
            point1 = transform.position;
            point2 = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z / 2);
            point3 = new Vector3(transform.position.x, transform.position.y, 0);
            var pointList = new List<Vector3>();
            for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(point1, point2, ratio);
                var tangentLineVertex2 = Vector3.Lerp(point2, point3, ratio);
                var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                pointList.Add(bezierpoint);
            }
            lineRenderer.positionCount = pointList.Count;
            lineRenderer.SetPositions(pointList.ToArray());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(point1, point2);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(point2, point3);

        Gizmos.color = Color.red;
        for (float ratio = 0.5f / vertexCount; ratio < 1; ratio += 1.0f / vertexCount)
        {
            Gizmos.DrawLine(Vector3.Lerp(point1, point2, ratio), Vector3.Lerp(point2, point3, ratio));
        }
    }
}