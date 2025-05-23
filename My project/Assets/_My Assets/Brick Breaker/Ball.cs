using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public const int EVENT_BRICKBREAK = 0; // 벽돌이 부딪친 경우
    public const int EVENT_DEAD = 1; // 아래로 떨어져 죽은 경우 

    public float speed;
    public delegate void BallEvent(int eventId);  // 함수 위치 저장 
    public BallEvent ballCallBack;

    private Vector2 currentVelocity;
    private Rigidbody2D rb;
    private bool isStart = false;


    // 볼이 바운스 시, 불허 각도: 수평, 수직 각도
    const float DEG_LOW_LIMIT = 0.4f;
    const float DEG_HIGH_LIMIT = Mathf.PI / 2.0f - DEG_LOW_LIMIT;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void SetVelocity(Vector2 vel)
    {
        rb.linearVelocity = vel;
        currentVelocity = vel;
    }

    void SetVelocityFromTh(float th) // 각도(라디안) th에 대한 객체(리지드 바디)의 속도
    {
        Vector2 vel = new Vector2(speed * Mathf.Cos(th),
            speed * Mathf.Sin(th));
        SetVelocity(vel);
    }
       
    void BounceBar(Transform bar)   /// OnCollisionEnter2D에서 'Bar' 충돌시 호출
    {
        // 공이 막대에 맞고 튕기는 경우
        // 막대의 좌우측에 따라 튕기는 방향이 달라짐 
        Vector2 vel = rb.linearVelocity;
        if (bar.position.x > transform.position.x)  /// 공이 바의 왼쪽에 있다.
        {
            // 공은 왼쪽으로 날아감
            vel.x = -Mathf.Abs(rb.linearVelocity.x);
        }
        else
        {
            // 공은 오른쪽으로 날아감
            vel.x = Mathf.Abs(rb.linearVelocity.x);
        }

        SetVelocity(vel);
        AdjustAngle();
    }

    void AdjustAngle()
    {
        float th = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x);
        float newTh;
        if (th >= 0)
        {
            // 0 ~ 180도 사이의 처리
            if (th < Mathf.PI / 2.0f)
            {
                // 90 ~ 180도 사이의 처리
                newTh = Mathf.Clamp(th,
                    DEG_LOW_LIMIT, DEG_HIGH_LIMIT);
                SetVelocityFromTh(newTh);
            }
            else
            {
                newTh = Mathf.Clamp(th, Mathf.PI / 2.0f + DEG_LOW_LIMIT,
                    Mathf.PI / 2.0f + DEG_HIGH_LIMIT);
                SetVelocityFromTh(newTh);
            }
        }
        else
        {
            // 0 ~ -180도 사이의 처리
            if (th > -Mathf.PI / 2.0f)
            {
                // 0 ~ -90도 사이의 처리
                newTh = Mathf.Clamp(th, -DEG_HIGH_LIMIT, -DEG_LOW_LIMIT);
                SetVelocityFromTh(newTh);
            }
            else
            {
                // -90 ~ -180도 사이의 처리
                newTh = Mathf.Clamp(th, -Mathf.PI / 2.0f - DEG_HIGH_LIMIT,
                    -Mathf.PI / 2.0f - DEG_LOW_LIMIT);
                SetVelocityFromTh(newTh);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Brick"))
        {
            // 반사처리
            Destroy(collision.gameObject);
            ballCallBack(EVENT_BRICKBREAK);
            Debug.Log("Brick");
            AdjustAngle();
        }
        else if (collision.transform.CompareTag("Bar"))
        {
            // 반사처리
            BounceBar(collision.transform);
            Debug.Log("Bar");
        }
        else if (collision.transform.CompareTag("Wall"))
        {
            // 반사처리
        }
        else if (collision.transform.CompareTag("Deadzone"))
        {
            // 사망
            ballCallBack(EVENT_DEAD);
            StopMove();
        }
    }

    public void StartMove()
    {
        if (!isStart)
        {
            // 시작각도로 볼을 발사한다.
            SetVelocityFromTh(Mathf.PI / 4.0f);
            isStart = true;
        }
    }

    public void StopMove()
    {
        currentVelocity = rb.linearVelocity = Vector2.zero;
        isStart = false;
    }

    public void ResetBall(Vector3 pos)
    {
        rb.position = pos - new Vector3(0, -0.6f, 0);
    }
}