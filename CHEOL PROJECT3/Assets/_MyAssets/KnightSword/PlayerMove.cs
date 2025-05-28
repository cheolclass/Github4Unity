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

        // ���� - ���콺 ���� Ŭ��   
        if (Input.GetMouseButtonDown(0) || (yInput > 0.19f))   // <= Why this?
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.y = SPEED_JUMP;
            rb.linearVelocity = velocity;
        } // if

        // ���콺 ������ Ŭ�� �� ��ġ �̵�
        if (Input.GetMouseButtonDown(1))  // ���� �̵�
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; // 2D ���ӿ����� z�� 0���� ����
            transform.position = mousePos;
            rb.linearVelocity = Vector2.zero;
        } // if    
    }  // Update

    private void FixedUpdate()
    {
        // ���� �� ���� �Է� ó��
        float xInput = Input.GetAxis("Horizontal");
        //float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * SPEED_MOVE;
        float ySpeed = rb.linearVelocity.y; // ���� ���� (yInput�� ������ ������� ����)

        if (xInput < 0)   // -0.19f is better
        {
            // �������� ���� ��ȯ
            Vector3 vec = transform.localScale;
            vec.x = -Mathf.Abs(vec.x);
            transform.localScale = vec;
        }
        else if (xInput > 0)  // <= Why this?  // 0.19f is better
        {
            // ������
            Vector3 vec = transform.localScale;
            vec.x = Mathf.Abs(vec.x);
            transform.localScale = vec;
        }
        // How about the case "xInput == 0"?

        rb.linearVelocity = new Vector2(xSpeed, ySpeed);

    }  // FixedUpdate

}