using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Vector3 mouseScreenPosition;
    private Vector3 mouseWorldPosition;
    public float speed = 5f;
    private bool isHolding = false;
    private bool isAlreadyShot = false;
    private bool isAttached = false;
    //Transform scale;
    Vector3 center = Vector3.zero;

    [SerializeField]
    float radius = 2f, angularSpeed = 2f;

    float positionX, positionY, angle = 0f;


    private void Start()
    {
        isHolding = true;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if (isHolding)
                {
                    Debug.Log(mouseWorldPosition);
                    transform.position = MousePos(touch);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                isHolding = false;
                if (!isAlreadyShot)
                {
                    Throw();
                }
            }
        }
    }

    private void Throw()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = (transform.forward + transform.up) * speed;
        rb.AddForce((Vector3.up + Vector3.forward) * speed * Time.deltaTime, ForceMode.Impulse);
        isAlreadyShot = true;
    }

    private Vector3 MousePos(Touch touch)
    {
        mouseScreenPosition = Input.mousePosition;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane + 1));

        return mouseWorldPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isAttached = true;
        
        
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.parent = GameObject.Find("GamePlane").transform;
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
