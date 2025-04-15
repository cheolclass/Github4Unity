using UnityEngine;

public class Sprite : MonoBehaviour
{
    private Vector2 offset;

    public void OnMouseDown()
    {
        offset = (Vector2)transform.position
            - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log("SpriteOnMouseDown...");
    }

    public void OnMouseUp()
    {
        Debug.Log("SpriteOnMouseUp...");
    }

    public void OnMouseDrag()
    {
        // 부드러운 이동
        Vector2 newPosition =
            (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = newPosition;

        Debug.Log("SpriteOnMouseDrag...");
    }

}
