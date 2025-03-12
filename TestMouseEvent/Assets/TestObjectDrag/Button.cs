using UnityEngine;

public class Button : MonoBehaviour
{
    private bool isDragging;

    public void OnMouseDown()
    {
        isDragging = true;
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

            Debug.Log("Dragging button...");
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
