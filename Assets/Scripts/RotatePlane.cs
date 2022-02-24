using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    public int angle;
    public float rotSpeed;
    
    void Update()
    {
        transform.Rotate(Vector2.up, rotSpeed * Time.deltaTime);
    }
}
