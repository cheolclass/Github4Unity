// PlayerMove.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    const float SPEED_JUMP = 5.0f;
    const float SPEED_MOVE = 3.0f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float yInput = Input.GetAxis("Vertical");

        // 점프 - 마우스 왼쪽 클릭   
        if (Input.GetMouseButtonDown(0) || (yInput > 0.19f))   // <= Why this?
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.y = SPEED_JUMP;
            rb.linearVelocity = velocity;
        } // if

        // 마우스 오른쪽 클릭 시 위치 이동
        if (Input.GetMouseButtonDown(1))  // 순간 이동
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; // 2D 게임에서는 z를 0으로 고정
            transform.position = mousePos;
            rb.linearVelocity = Vector2.zero;
        } // if    
    }  // Update

    private void FixedUpdate()
    {
        // 수평 및 수직 입력 처리
        float xInput = Input.GetAxis("Horizontal");
        //float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * SPEED_MOVE;
        float ySpeed = rb.linearVelocity.y; // 점프 유지 (yInput은 점프에 사용하지 않음)

        if (xInput < 0)   // -0.19f is better
        {
            // 왼쪽으로 방향 전환
            Vector3 vec = transform.localScale;
            vec.x = -Mathf.Abs(vec.x);
            transform.localScale = vec;
        }
        else if (xInput > 0)  // <= Why this?  // 0.19f is better
        {
            // 오른쪽
            Vector3 vec = transform.localScale;
            vec.x = Mathf.Abs(vec.x);
            transform.localScale = vec;
        }
        // How about the case "xInput == 0"?

        rb.linearVelocity = new Vector2(xSpeed, ySpeed);

    }  // FixedUpdate

}