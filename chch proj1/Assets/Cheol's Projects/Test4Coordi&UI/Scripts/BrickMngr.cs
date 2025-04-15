using UnityEngine;
using UnityEngine.EventSystems;

public class BrickMngr : MonoBehaviour
{
    public GameObject Brick;
    public GameObject Brick_Physic;
    public GameObject Circle;

    public float horiNum, vertiNum;
    public float brickWidth, brickHeight;
    public float botMostCoordi;   /// ����� ���� Y�� ���� ��ǥ


    void Start()
    {
        /// ���� ��ǥ �ֱ�
        GameObject brick0 = Instantiate(Brick_Physic, new Vector2(-1.5f, -1), Quaternion.identity);
        GameObject brick1 = Instantiate(Brick_Physic, new Vector2(-0.5f, -1), Quaternion.identity);  // BrickColors[i]);
        GameObject brick3 = Instantiate(Brick_Physic, new Vector2(0.5f, -1), Quaternion.identity);
        GameObject brick4 = Instantiate(Brick_Physic, new Vector2(1.5f, -1), Quaternion.identity);

        float y = botMostCoordi;
        float leftmostCoordi = -(horiNum - 1) * (brickWidth / 2);  /// 

        /// Y �� ��ü �� �� ���� Ÿ������ ä���
        for (int row = 0; row < vertiNum/2; row++)
        {
            float x = leftmostCoordi;
            for (int col = 0; col < horiNum; col++)
            {               
                GameObject cir = Instantiate(Circle);
                cir.transform.position = new Vector2(x, y);   /// ��ǥ
                x += brickWidth;
            }
            //y += brickHeight / 2;  /// �� ���� ��¦ �ٿ���
            y += brickHeight; /// �� ���� ��� �迭
        }

        /// ������ ���� �簢�� ������ ä���
        for (int row = 0; row < vertiNum/2; row++)
        {
            float x = leftmostCoordi;
            for (int col = 0; col < horiNum; col++)
            {
                /// ��ǥ
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

    /// ���콺 �̺�Ʈ ó�� 
    //public void OnMouseDown()
    /// ���� ��ũ��Ʈ�� �и��ؾ� ��
    ////public void OnBrickClicked(BaseEventData eventData)
    ////{
    ////    Debug.Log($"{gameObject.name} ������ Ŭ���Ǿ� ������! (EventTrigger ���)");
    ////    Destroy(gameObject);
    ////}



}



