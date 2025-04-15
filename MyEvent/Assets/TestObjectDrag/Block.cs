using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private Vector2 offset;
    private bool isDragging = false;
    public TextBox myTextBox;   //<= InspV�� �ش� ���Կ�, HierV�� TextBox ��ü D&D

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
        if (!isDragging)    /// ���콺 �ٿ� ��, (�߰��� �巡�� ����) �ٷ� �� ���� ������ ����
        {
            Text textBox = myTextBox.GetComponent<Text>();
            textBox.text = "I'm BLOCK!";
            textBox.color = new Color(Random.value, Random.value, Random.value); // ���� ���� ����
        }

        //isDragging = false;
    }

    /// Update �Լ��� ���� �� �����Ӹ��� ȣ��� 
        public void OnMouseDrag()
    {
        // �ε巯�� �̵�
        Vector2 newPosition = 
            (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;            
        transform.position = newPosition;

        if(Vector3.Distance(mouseDownPos, Input.mousePosition) > 0.0f ) /// ��¥ �巹�� �ÿ���
            isDragging = true;  

        Debug.Log("BlockOnMouseDrag...");
    }

}
