using UnityEngine;
using UnityEngine.EventSystems;

public class TextBox : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool isDragging;
    //private RectTransform rectTransform;

    public void OnPointerDown(PointerEventData eventData)
    {
        //isDragging = true;
        Debug.Log("OnPointerDown: TextBox ...");

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        Debug.Log("OnBeginDrag: TextBox ...");

    }

    public void OnDrag(PointerEventData eventData)
    {
        //isDragging = true;
        //Debug.Log("OnDrag: TextBox ...");
        if (isDragging)
        {
            //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //transform.Translate(mousePos);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rectTransform.position;
            rectTransform.Translate(mousePos);

            Debug.Log("OnDrag: TextBox...");
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
       isDragging = false;
        Debug.Log("OnEndDrag: TextBox ...");
    }

    

    public void OnMouseDown()
    {
        isDragging = true;
        Debug.Log("OnMouseDown: TextBox clicked...");
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    public void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);

            Debug.Log("OnMouseDrag: TextBox...");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if(isDragging)
        //{
        //    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //    transform.Translate(mousePos);
        //}
    }
}
