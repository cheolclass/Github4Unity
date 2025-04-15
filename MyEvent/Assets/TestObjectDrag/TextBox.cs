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
        // ���콺 ������ ��ġ�� UI ��ġ�� ��ȯ�Ͽ� ����
        // UI ��Ҵ� Screen Space - Overlay �Ǵ� Screen Space - Camera���� �����ϹǷ� ScreenToWorldPoint()�� �ƴ϶� eventData.position�� �̿�
        rectTransform.position = eventData.position;

        Debug.Log("TextBoxOnDrag...");
    }
}