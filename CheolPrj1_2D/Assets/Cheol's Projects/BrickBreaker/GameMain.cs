using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public List<GameObject> Bricks;  /// 4  ������ ���� �������� ����

    public GameObject mBall; 
    public GameObject Bar;
    public GameObject BrickNode;  /// ��� ������ ��ġ�� �θ� ���
    public float BarLimit;
    public float BrickY;
    public int BrickAcross;
    public float BrickWidth;
    public float BrickHeight;
    public Text ResultText;
    public Text ScoreText;
    public Text BallText;
    public Button Restart;

    // (����) [SerializeField]  // �� InsV�� ���� ��Ű�� ���� �� 
    private Ball BallScript;
    private bool IsPressed;
    private int TotalBricks;
    private int Score;
    private int Balls;
    private bool Paused;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Balls = 3;
        ResetStage();

        BallScript = mBall.GetComponent<Ball>();
        BallScript.ballCallBack += OnBallEvent;
    }

    void ResetStage()
    {
        // ��� ������ �����.
        foreach (Transform child in BrickNode.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        Paused = true;

        // ui ����
        Restart.gameObject.SetActive(false);
        ResultText.gameObject.SetActive(false);

        // ���������� ����
        float y = BrickY;
        float brickX = -(BrickAcross - 1) * BrickWidth / 2.0f;    /// ���� ���� �߽��� X ��ǥ:  -(8-1)*2/2

        TotalBricks = 0;
        for (int i = 0; i < Bricks.Count; i++)   /// 4 ���� ������ �� �ٿ� BrickAcross ��(8) ��ŭ ������
        {
            float x = brickX;  /// �� �ٸ���, �� ���ʿ������� �迭
            for (int j = 0; j < BrickAcross; j++)
            {
                GameObject block = Instantiate(Bricks[i]);
                block.transform.position = new Vector3(x, y, 0);
                x += BrickWidth;
                TotalBricks++;
                block.transform.parent = BrickNode.transform;   /// ���� ��ü�� �θ� ���� BrickNode ��ü�� ����
            }
            y += BrickHeight;
        }

        RefreshBalls();
    }

    void RefreshBalls()
    {
        BallText.text = "Balls: " + Balls;
    }

    void RefreshScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        /// if (Mouse.current.leftButton.wasPressedThisFrame) // in InputSystem 
        if (Input.GetMouseButtonDown(0)) 
        {   
            IsPressed = true;
            if (Paused && Balls > 0)
            {
                Paused = false;
                BallScript.StartMove();
            }
        }

        if (IsPressed)
        {
            Vector3 worldPos =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            worldPos.x = Mathf.Clamp(worldPos.x, -BarLimit, BarLimit);

            Vector3 pos = Bar.transform.position;
            Bar.transform.position =
                new Vector3((float)worldPos.x, (float)pos.y, 0);
            if (Paused)
            {
                BallScript.ResetBall(Bar.transform.position);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsPressed = false;
        }
    }

    public void OnBallEvent(int eventID)
    {
        if (eventID == Ball.EVENT_BRICKBREAK)
        {
            TotalBricks--;

            // ���ھ� ����
            Score += 10;
            RefreshScore();

            if (TotalBricks == 0)
            {
                Debug.Log("Stage clear");
                BallScript.StopMove();

                ResetStage();
                BallScript.ResetBall(Bar.transform.position);
            }
        }
        else if (eventID == Ball.EVENT_DEAD)
        {
            Balls--;
            Paused = true;
            RefreshBalls();

            if (Balls <= 0)
            {
                ResultText.gameObject.SetActive(true);
                Restart.gameObject.SetActive(true);
                ResultText.text = "Game Over";
                Debug.Log("Game Over");
                IsPressed = false;
            }
            else
            {
                BallScript.ResetBall(Bar.transform.position);
            }
        }
    }

    public void OnRestart()
    {
        Score = 0;
        Balls = 3;

        ResetStage();
        RefreshScore();
    }
}
