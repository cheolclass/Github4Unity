using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private Vector2 offset;
    private bool isDragging = false;
    public TextBox myTextBox;

    private Vector3 mouseDownPos;

    private void Awake()
    {
        isDragging = false;
    }

    public void OnMouseDown()
    {
        offset = (Vector2) transform.position 
            - (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDownPos = Input.mousePosition;

        Debug.Log("BlockOnMouseDown...");

        isDragging = false;
    }

    public void OnMouseUp()
    {
        Debug.Log("BlockOnMouseUp...");
        if (!isDragging)
        {
            Text textBox = myTextBox.GetComponent<Text>();
            textBox.text = "I'm BLOCK!";
            textBox.color = new Color(Random.value, Random.value, Random.value); // 랜덤 색상 적용
        }

        //isDragging = false;
    }

    /// Update 함수와 같이 매 프레임마다 호출됨 
        public void OnMouseDrag()
    {
        // 부드러운 이동
        Vector2 newPosition = 
            (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;            
        transform.position = newPosition;

        if(Vector3.Distance(mouseDownPos, Input.mousePosition) > 0.0f ) /// 진짜 드레그 시에만
            isDragging = true;   /// 변수를 true로 수정

        Debug.Log("BlockOnMouseDrag...");
    }

}
