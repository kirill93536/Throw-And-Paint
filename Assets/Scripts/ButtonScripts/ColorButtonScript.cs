using UnityEngine;
using UnityEngine.EventSystems;

public enum ColorType
{
    black, cyan, yellow, red, green, blue
};

public class ColorButtonScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

{
    public ColorType colorType;
    public GameObject painter;
    private GameObject instance;

    public void SetProjectile()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane + 1));
        instance = Instantiate(painter, point, transform.rotation) as GameObject;
        instance.transform.rotation = Quaternion.Euler(-90, 0, 0);
        Renderer textureRenderer = instance.GetComponent<Renderer>();
        switch (colorType)
        {
            case ColorType.black:
                textureRenderer.material.color = Color.black;
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
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
