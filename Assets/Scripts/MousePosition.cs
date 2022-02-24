using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public static Vector3 GetMousePosition(Camera cam, Transform spawnPosition)
    {
        Vector3 point;
        Vector2 mousePos = new Vector2();

        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, spawnPosition.position.z));

        return point;
    }
}
