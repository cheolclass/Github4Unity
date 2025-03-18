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
        // 마우스 포인터 위치를 UI 위치로 변환하여 적용
        // UI 요소는 Screen Space - Overlay 또는 Screen Space - Camera에서 동작하므로 ScreenToWorldPoint()가 아니라 eventData.position을 이용
        rectTransform.position = eventData.position;

        Debug.Log("ButtonOnDrag...");
    }

    public void OnButtonClick()
    {
        /// 드래깅 시에는 비클릭으로 처리
        if(!isDragging)
        {
            GameObject[] textBoxes = GameObject.FindGameObjectsWithTag("TextBox"); // 1개일 때: FindGameObjectWithTag
            foreach (GameObject textBoxObject in textBoxes)
            {
                Text textBox = textBoxObject.GetComponent<Text>();
                textBox.text = "I'm BUTTON!";
                textBox.color = new Color(Random.value, Random.value, Random.value); // 랜덤 색상 적용
            }

        }
    }

    }