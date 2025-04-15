using UnityEngine;
using UnityEngine.EventSystems;

public class BrickMngr : MonoBehaviour
{
    public GameObject Brick;
    public GameObject Brick_Physic;
    public GameObject Circle;

    public float horiNum, vertiNum;
    public float brickWidth, brickHeight;
    public float botMostCoordi;   /// 블록이 놓일 Y축 시작 좌표


    void Start()
    {
        /// 직접 좌표 주기
        GameObject brick0 = Instantiate(Brick_Physic, new Vector2(-1.5f, -1), Quaternion.identity);
        GameObject brick1 = Instantiate(Brick_Physic, new Vector2(-0.5f, -1), Quaternion.identity);  // BrickColors[i]);
        GameObject brick3 = Instantiate(Brick_Physic, new Vector2(0.5f, -1), Quaternion.identity);
        GameObject brick4 = Instantiate(Brick_Physic, new Vector2(1.5f, -1), Quaternion.identity);

        float y = botMostCoordi;
        float leftmostCoordi = -(horiNum - 1) * (brickWidth / 2);  /// 

        /// Y 축 전체 줄 중 반은 타원으로 채우고
        for (int row = 0; row < vertiNum/2; row++)
        {
            float x = leftmostCoordi;
            for (int col = 0; col < horiNum; col++)
            {               
                GameObject cir = Instantiate(Circle);
                cir.transform.position = new Vector2(x, y);   /// 좌표
                x += brickWidth;
            }
            //y += brickHeight / 2;  /// 각 행을 바짝 붙여서
            y += brickHeight; /// 한 줄을 띄고 배열
        }

        /// 나머지 반은 사각형 벽돌로 채우기
        for (int row = 0; row < vertiNum/2; row++)
        {
            float x = leftmostCoordi;
            for (int col = 0; col < horiNum; col++)
            {
                /// 좌표
                GameObject brick = Instantiate(Brick);
                brick.transform.position = new Vector2(x, y);
                x += brickWidth;
            }
            //y += brickHeight/2;
            y += brickHeight;
        }
    }

    void Update()
    {

    }

    /// 마우스 이벤트 처리 
    //public void OnMouseDown()
    /// 별도 스크립트로 분리해야 함
    ////public void OnBrickClicked(BaseEventData eventData)
    ////{
    ////    Debug.Log($"{gameObject.name} 벽돌이 클릭되어 삭제됨! (EventTrigger 사용)");
    ////    Destroy(gameObject);
    ////}



}



