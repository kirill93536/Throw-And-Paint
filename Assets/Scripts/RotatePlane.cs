using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    public int angle;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //Quaternion rot = Quaternion.Euler(transform.rotation.x + angle, 90, 90);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotSpeed);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.up, rotSpeed * Time.deltaTime);
    }
}
