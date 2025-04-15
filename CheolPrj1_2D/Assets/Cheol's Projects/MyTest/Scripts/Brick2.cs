using UnityEngine;
using UnityEngine.EventSystems;

public class Brick2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler // , IPointerHandler
{
    public event System.Action<Brick2> OnBrickDestroyed;

    private Camera mainCamera;
    private Vector3 offset;
    private bool isDragging = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnEnable()
    {
        GameManager2.RegisterBrick(this);
    }

    void OnDisable()
    {
        GameManager2.UnregisterBrick(this);
    }

    public void DestroyBrick()
    {
        OnBrickDestroyed?.Invoke(this); // ���ο��� �̺�Ʈ ȣ��
        Destroy(gameObject);
    }


    // Ŭ�� �� ���� ����
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isDragging) // �巡�װ� �ƴ� ���� ����
        {
            Debug.Log("���� ������: " + gameObject.name);
            OnBrickDestroyed?.Invoke(this); // GameManager2���� ó���� �� �ֵ��� �̺�Ʈ �߻�
            Destroy(gameObject);
        }
    }
    // OnMouseDown
    // --> OnPointerDown

    // �巡�� ���� �� ȣ��
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(eventData.position);
        mousePosition.z = 0f;
        offset = transform.position - mousePosition;
        isDragging = true;
    }

    // �巡�� �� ȣ��
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(eventData.position);
            mousePosition.z = 0f;
            transform.position = mousePosition + offset;
        }
    }

    // �巡�� ���� �� ȣ��
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log("�巡�� ���� - ���ο� ��ġ: " + transform.position);
    }
}