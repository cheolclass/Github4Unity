using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GameManager2 : MonoBehaviour
{
    public GameObject brick2Prefab; // 벽돌 프리팹
    private Camera mainCamera;
    private static HashSet<Brick2> bricks = new HashSet<Brick2>();

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 감지
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // UI를 클릭했으면 이벤트 실행하지 않음
                return;
            }

            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

        if (hitCollider == null)
        {
            // 빈 공간 -> 새로운 벽돌 생성
            Instantiate(brick2Prefab, mousePosition, Quaternion.identity);
            Debug.Log("새로운 벽돌 생성!");
        }
        else
        {



            // 벽돌이 존재하면 삭제
            Brick2 brick = hitCollider.GetComponent<Brick2>();
            if (brick != null)
            {
                //brick.OnBrickDestroyed?.Invoke(brick); // 이벤트 발생
                //brick.OnBrickDestroyed?.Invoke(brick); 
                //Destroy(brick.gameObject);
                brick.DestroyBrick();
                Debug.Log("벽돌 삭제됨!");
            }
        }
    }

    public static void RegisterBrick(Brick2 brick)
    {
        if (!bricks.Contains(brick))
        {
            bricks.Add(brick);
            brick.OnBrickDestroyed += HandleBrickDestroyed;
        }
    }

    public static void UnregisterBrick(Brick2 brick)
    {
        if (bricks.Contains(brick))
        {
            brick.OnBrickDestroyed -= HandleBrickDestroyed;
            bricks.Remove(brick);
        }
    }

    private static void HandleBrickDestroyed(Brick2 brick)
    {
        bricks.Remove(brick);
        Debug.Log("벽돌이 파괴됨: " + brick.gameObject.name);
    }
}