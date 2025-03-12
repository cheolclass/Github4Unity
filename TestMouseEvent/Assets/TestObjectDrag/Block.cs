using UnityEngine;

public class Block : MonoBehaviour
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

            Debug.Log("Dragging block...");
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
