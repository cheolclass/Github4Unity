using UnityEngine;

public class BrickMngr : MonoBehaviour
{
    public GameObject Brick;

    void Start()
    {
        // collision.transform.CompareTag("Brick")

        //GameObject block = Instantiate(Bricks[i]);
        //block.transform.position = new Vector3(x, y, 0);

        GameObject brick0 = Instantiate(Brick, new Vector2(-1, 0), Quaternion.identity);
        GameObject brick1 = Instantiate(Brick, new Vector2(0, 0), Quaternion.identity);  // BrickColors[i]);
        GameObject brick2 = Instantiate(Brick, new Vector2(1, 0), Quaternion.identity);

        GameObject brick3 = Instantiate(Brick, new Vector2(-1, 1), Quaternion.identity);
        GameObject brick4 = Instantiate(Brick, new Vector2(0, 1), Quaternion.identity);  // BrickColors[i]);
        GameObject brick5 = Instantiate(Brick, new Vector2(1, 1), Quaternion.identity);
        // 3개씩 다른 방법으로 만들기



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
