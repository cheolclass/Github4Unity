using UnityEngine;
using UnityEngine.EventSystems;

public class TextBox : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Debug.Log("TextBoxAwake...");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("TextBoxOnPointerDown...");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 마우스 포인터 위치를 UI 위치로 변환하여 적용
        // UI 요소는 Screen Space - Overlay 또는 Screen Space - Camera에서 동작하므로 ScreenToWorldPoint()가 아니라 eventData.position을 이용
        rectTransform.position = eventData.position;

        Debug.Log("TextBoxOnDrag...");
    }
}