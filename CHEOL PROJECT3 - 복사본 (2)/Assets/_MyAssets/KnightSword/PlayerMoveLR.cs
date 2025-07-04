// PlayerMoveLR.cs 코드
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLR : MonoBehaviour
{
    const float SPEED_JUMP = 5.0f;
    const float SPEED_MOVE = 3.0f;

    Rigidbody2D rb;
    bool leftPressed = false;
    bool rightPressed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            float dist = SPEED_MOVE * Time.deltaTime;
            Vector2 pos = transform.position;
            // 좌측이동
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                leftPressed = true;

            if (Input.GetKeyUp(KeyCode.LeftArrow))
                leftPressed = false;

            if (leftPressed)
            {
                pos.x -= dist;

                // 왼쪽으로 방향 전환
                Vector3 vec = transform.localScale;
                vec.x = -Mathf.Abs(vec.x);
                transform.localScale = vec;
            }
            // 우측이동
            if (Input.GetKeyDown(KeyCode.RightArrow))
                rightPressed = true;

            if (Input.GetKeyUp(KeyCode.RightArrow))
                rightPressed = false;

            if (rightPressed)
            {
                pos.x += dist;

                // 오른쪽으로 방향 전환
                Vector3 vec = transform.localScale;
                vec.x = Mathf.Abs(vec.x);
                transform.localScale = vec;
            }
            transform.position = pos;

            // 점프
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
            {
                Vector2 moveVelocity = rb.linearVelocity;
                moveVelocity.y = SPEED_JUMP;
                rb.linearVelocity = moveVelocity;
            }

            // 순간이동 - 오른쪽 버튼
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = newPos;
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}