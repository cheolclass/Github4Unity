using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private Vector2 offset;
    private bool isDragging = false;
    public TextBox myTextBox;   //<= InspV의 해당 슬롯에, HierV의 TextBox 객체 D&D

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
        if (!isDragging)    /// 마우스 다운 후, (중간에 드래그 없이) 바로 업 했을 때에만 실행
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
            isDragging = true;  

        Debug.Log("BlockOnMouseDrag...");
    }

}
