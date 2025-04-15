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
        OnBrickDestroyed?.Invoke(this); // 내부에서 이벤트 호출
        Destroy(gameObject);
    }


    // 클릭 시 벽돌 삭제
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isDragging) // 드래그가 아닐 때만 삭제
        {
            Debug.Log("벽돌 삭제됨: " + gameObject.name);
            OnBrickDestroyed?.Invoke(this); // GameManager2에서 처리할 수 있도록 이벤트 발생
            Destroy(gameObject);
        }
    }
    // OnMouseDown
    // --> OnPointerDown

    // 드래그 시작 시 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(eventData.position);
        mousePosition.z = 0f;
        offset = transform.position - mousePosition;
        isDragging = true;
    }

    // 드래그 중 호출
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(eventData.position);
            mousePosition.z = 0f;
            transform.position = mousePosition + offset;
        }
    }

    // 드래그 종료 시 호출
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log("드래그 종료 - 새로운 위치: " + transform.position);
    }
}