using UnityEngine;
using UnityEngine.EventSystems;

public class SculptButtonScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject projectile;

    public void SetProjectile()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane + 1));
        Instantiate(projectile, point, transform.rotation);
        Debug.Log("Press");
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
