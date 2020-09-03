using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 10; //스피드
    public float xMove, yMove;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveASDW();

        notOut();


    }

    // Player2 이동
    public void moveASDW()
    {
        /* GetAxis 이용해서 이동하기
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축으로 이동할양
        this.transform.Translate(new Vector3(xMove, yMove, 0));  //이동
        */

        // 키보드로 이동하기
        xMove = 0;
        yMove = 0;

        if (Input.GetKey(KeyCode.D))
            xMove = speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.A))
            xMove = -speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            yMove = speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            yMove = -speed * Time.deltaTime;
        this.transform.Translate(new Vector3(xMove, yMove, 0));

    }

    // 화면 밖으로 나가는 거 막기
    public void notOut()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
