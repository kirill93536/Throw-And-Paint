using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ColorType
{
    black, cyan, yellow, red, green, blue
};

public class ColorButtonScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

{
    public ColorType colorType;
    public GameObject painter;
    private GameObject instance;
    private Button btn;
    private bool isHolding;
    private bool hasThrown = true;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetProjectile()
    {

        Debug.Log("Color Button Pressed");
        Vector3 point = MousePosition.GetMousePosition(Camera.main, FindObjectOfType<Throw>().transform);
        instance = Instantiate(painter, point, transform.rotation) as GameObject;
        instance.transform.rotation = Quaternion.Euler(-90, 0, 0);
        Renderer textureRenderer = instance.GetComponent<Renderer>();
        //Debug.Log("Color is:");
        switch (colorType)
        {
            case ColorType.black:
                textureRenderer.material.color = Color.black;
                //Debug.Log("Black");
                break;
            case ColorType.cyan:
                textureRenderer.material.color = Color.cyan;
                break;
            case ColorType.yellow:
                textureRenderer.material.color = Color.yellow;
                break;
            case ColorType.red:
                textureRenderer.material.color = Color.red;
                break;
            case ColorType.green:
                textureRenderer.material.color = Color.green;
                break;
            case ColorType.blue:
                textureRenderer.material.color = Color.blue;
                break;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Invoke("SetProjectile", 0);
        //throw new System.NotImplementedException();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
       //throw new System.NotImplementedException();
    }

    
}
