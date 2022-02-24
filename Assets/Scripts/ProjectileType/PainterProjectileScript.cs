using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterProjectileScript : MonoBehaviour
{
    [HideInInspector] Renderer renderer;

    [HideInInspector] public Color color;
    private Vector3 mouseScreenPosition;
    private Vector3 mouseWorldPosition;
    public float speed = 5f;
    private bool isHolding = true;
    private bool isAlreadyShot = false;

    float hue;
    float sat;
    float val;

    LineRenderer lineRenderer;
    Color lineColor;
    private void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        lineRenderer = GetComponent<LineRenderer>();
        Color.RGBToHSV(renderer.material.color, out hue, out sat, out val);
        sat -= 0.5f;
        lineColor = Color.HSVToRGB(hue, sat, val);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                if (isHolding)
                {
                    lineRenderer.startColor = lineColor;
                    lineRenderer.endColor = lineColor;
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
        rb.velocity = (transform.forward - transform.up) * speed;
        rb.AddForce((-Vector3.up + Vector3.forward) * speed * Time.deltaTime, ForceMode.Impulse);
        isAlreadyShot = true;
    }

    private Vector3 MousePos(Touch touch)
    {
        Vector3 mouseScreenPosition = touch.position;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane + 1));

        return mouseWorldPosition;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = renderer.material.color;
            Destroy(gameObject);
        }
    }
}
