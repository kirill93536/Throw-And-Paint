using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SculptButtonScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject projectile;
    private Button btn;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetProjectile()
    {
        Vector3 point = MousePosition.GetMousePosition(Camera.main, FindObjectOfType<Throw>().transform);
        Instantiate(projectile, point, transform.rotation);
        Debug.Log("Press");
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
