using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GameManager2 : MonoBehaviour
{
    public GameObject brick2Prefab; // ���� ������
    private Camera mainCamera;
    private static HashSet<Brick2> bricks = new HashSet<Brick2>();

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ����
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // UI�� Ŭ�������� �̺�Ʈ �������� ����
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
            // �� ���� -> ���ο� ���� ����
            Instantiate(brick2Prefab, mousePosition, Quaternion.identity);
            Debug.Log("���ο� ���� ����!");
        }
        else
        {



            // ������ �����ϸ� ����
            Brick2 brick = hitCollider.GetComponent<Brick2>();
            if (brick != null)
            {
                //brick.OnBrickDestroyed?.Invoke(brick); // �̺�Ʈ �߻�
                //brick.OnBrickDestroyed?.Invoke(brick); 
                //Destroy(brick.gameObject);
                brick.DestroyBrick();
                Debug.Log("���� ������!");
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
        Debug.Log("������ �ı���: " + brick.gameObject.name);
    }
}