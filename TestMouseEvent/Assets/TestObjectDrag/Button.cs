using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private bool        isDragging = false;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        isDragging = false;

        Debug.Log("ButtonAwake...");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log("ButtonOnPointerDown...");
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        // ���콺 ������ ��ġ�� UI ��ġ�� ��ȯ�Ͽ� ����
        // UI ��Ҵ� Screen Space - Overlay �Ǵ� Screen Space - Camera���� �����ϹǷ� ScreenToWorldPoint()�� �ƴ϶� eventData.position�� �̿�
        rectTransform.position = eventData.position;

        Debug.Log("ButtonOnDrag...");
    }

    public void OnButtonClick()
    {
        /// �巡�� �ÿ��� ��Ŭ������ ó��
        if(!isDragging)
        {
            GameObject[] textBoxes = GameObject.FindGameObjectsWithTag("TextBox"); // 1���� ��: FindGameObjectWithTag
            foreach (GameObject textBoxObject in textBoxes)
            {
                Text textBox = textBoxObject.GetComponent<Text>();
                textBox.text = "I'm BUTTON!";
                textBox.color = new Color(Random.value, Random.value, Random.value); // ���� ���� ����
            }

        }
    }

    }