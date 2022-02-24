using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 5f;
    private bool isHolding = false;
    private bool isAlreadyShot = false;
    private Vector3 scale;

    private void Awake()
    {
        scale = gameObject.transform.localScale;
    }

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
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane + 1));

        return mouseWorldPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.parent = GameObject.Find("GamePlane").transform;
        transform.localScale = scale;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
