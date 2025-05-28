/// PlayerMoveVirtual.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows; // => 코드 자동 생성됨. 주석 처리 할 것

public class PlayerMoveVirtual : MonoBehaviour
{
    const float SPEED_JUMP = 5.0f;
    const float SPEED_MOVE = 3.0f;

    public FixedJoystick fixedJoystick;
    public bool useVirtualJoystick = true;  ///

    Rigidbody2D rb;

    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        useVirtualJoystick = true;  /// Skip if unnecessary.

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float yInput = GetVerticalInput(); // 이렇게 밖으로 빼내면 가독성이 좋다.

        Debug.Log("yInput: " + yInput);        

        // 점프 - // 마우스 왼쪽 클릭 ↑ or 키보드 or 조이스틱 위 → 점프           
        if (yInput > 0.19f || Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isWalking", false);

            Vector2 velocity = rb.linearVelocity;
            velocity.y = SPEED_JUMP;
            rb.linearVelocity = velocity;            
        } // if

        // 마우스 우 클릭 => 순간 이동
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("isWalking", false);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; // 2D 게임에서는 z를 0으로 고정
            transform.position = mousePos;
            rb.linearVelocity = Vector2.zero;
        } // if    

    }  // Update

    private void FixedUpdate()
    {
        float xInput = GetHorizontalInput();

        float xSpeed = xInput * SPEED_MOVE;
        float ySpeed = rb.linearVelocity.y;

        anim.SetBool("isWalking", false);

        if (xInput < -0.01f)  //  
        {
            anim.SetBool("isWalking", true);

            // 왼쪽으로 방향 전환
            Vector3 vec = transform.localScale;
            vec.x = -Mathf.Abs(vec.x);
            transform.localScale = vec;
        }
        else if (xInput > 0.01f)  //
        {
            anim.SetBool("isWalking", true);

            // 오른쪽
            Vector3 vec = transform.localScale;
            vec.x = Mathf.Abs(vec.x);
            transform.localScale = vec;
        }

        // xInput == 0: 아무 동작 없음 (정지 시 방향 고정)

        rb.linearVelocity = new Vector2(xSpeed, ySpeed);
    }  // FixedUpdate

    private float GetHorizontalInput() 
    {
        float xInput1 = Input.GetAxis("Horizontal");
        float xInput2 = useVirtualJoystick ? fixedJoystick.Horizontal : Input.GetAxis("HorizontalJoy");

        float xInput = (Mathf.Abs(xInput1) > Mathf.Abs(xInput2)) ? xInput1 : xInput2;

        return xInput;
    }

    private float GetVerticalInput()
    {
        float yInput1 = Input.GetAxis("Vertical");
        float yInput2 = useVirtualJoystick ? fixedJoystick.Vertical : Input.GetAxis("VerticalJoy");

        float yInput = (Mathf.Abs(yInput1) > Mathf.Abs(yInput2)) ? yInput1 : yInput2;

        return yInput;
    }
}


