using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Map3 : MonoBehaviour
{
    [SerializeField]
    private GameObject player1, player2;
    int stageNum;
    int monsterFlag = 0;
    int movementFlag = 0;
    GameObject []soju;
    float moveSpeed = 2f;
    float pixelTime = 0.5f;
    int[] sojuFlag;
    Vector3 pos;

    // 플레이어의 위치 제공
    Vector3 pos1, pos2;

    Monster mon;
    #region  몬스터 타입 
    enum MonsterType
    {
        mProfessor = 0, // cha_gyosu
        mJogyo = 1, // cha_jogyo
        mGreen = 2, // friend2
        mYellow = 3, // friend4
        mPurple = 4, // friend1
        mBlue = 5 // friend 3

    }
    #endregion


    void FixedUpdate()
    {
        switch (monsterFlag)
        {
            case (int)MonsterType.mProfessor:
                if (transform.gameObject.name == "mProfessor1") RightDownMove();
                if (transform.gameObject.name == "mProfessor2") LeftDownMove();
                break;
            case (int)MonsterType.mJogyo:
                BoxRotate();
                break;
            case (int)MonsterType.mGreen:
                if (transform.gameObject.name == "mGreen1") LeftRightMove();
                if (transform.gameObject.name == "mGreen2") UpDownMove();

                break;
            case (int)MonsterType.mYellow:
                BoxRotate();
                break;
            case (int)MonsterType.mPurple:
                PurpleMove();
                break;
            case (int)MonsterType.mBlue:
                BoxRotate();
                break;
        }

    }



    // 몬스터와 플레이어와의 충돌 처리 확인한다.
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            if (monsterFlag == 0 || monsterFlag == 1)
                GameManager.Instance.Damage2(stageNum, collision.tag);
            else
                GameManager.Instance.Damage1(stageNum, collision.tag);


            // Player1 부딪히면 원점으로
            if (collision.CompareTag("Player1"))
            {
                player1 = collision.gameObject;
                player1.transform.position = pos1;
                SoundManager2.Instance.PlaySound("Jab", 0.2f);
            }
            // Player2 부딪히면 원점으로
            if (collision.CompareTag("Player2"))
            {
                player2 = collision.gameObject;
                player2.transform.position = pos2;
                SoundManager2.Instance.PlaySound("Jab", 0.2f);
            }
        }
    }




    private void Awake()
    {
   
       

        switch (transform.tag)
        {
            case "mProfessor":
                monsterFlag = 0;
                break;
            case "mJogyo":
                monsterFlag = 1;
                break;
            case "mGreen":
                monsterFlag = 2;
                break;
            case "mYellow":
                monsterFlag = 3;
                break;
            case "mPurple":
                monsterFlag = 4;
                break;
            case "mBlue":
                monsterFlag = 5;

                break;
        }
        pos = transform.position;

        switch (transform.tag)
        {
            case "mProfessor":
                if (transform.gameObject.name == "mProfessor1") StartCoroutine(mLRMove(pixelTime * 5, 1));
                if (transform.gameObject.name == "mProfessor2") StartCoroutine(mLRMove(pixelTime * 5, 3));
                break;
            case "mJogyo":
                if (transform.gameObject.name == "mJogyo1") StartCoroutine(mBoxRightMove(pixelTime * 7, pixelTime *4, 1));
                if (transform.gameObject.name == "mJogyo2") StartCoroutine(mBoxRightMove(pixelTime * 7, pixelTime * 4, 3));
                break;
            case "mGreen":
                if (transform.gameObject.name == "mGreen1") StartCoroutine(mLRMove(pixelTime * 5, 2));
                if (transform.gameObject.name == "mGreen2") StartCoroutine(mLRMove(pixelTime * 5, 1));
                break;
            case "mYellow":
                if (transform.gameObject.name == "mYellow1") StartCoroutine(mBoxLeftMove(pixelTime, 1));
                if (transform.gameObject.name == "mYellow2") StartCoroutine(mBoxLeftMove(pixelTime, 2));
                if (transform.gameObject.name == "mYellow3") StartCoroutine(mBoxLeftMove(pixelTime, 3));
                if (transform.gameObject.name == "mYellow4") StartCoroutine(mBoxLeftMove(pixelTime, 4));

                break;
            case "mPurple":
                GameObject prefab = Resources.Load("Prefabs/soju") as GameObject;
                soju = new GameObject[4];
                sojuFlag = new int[4];
                Vector3 pos = transform.position;
                for (int i = 0; i < soju.Length; i++)
                {
                    soju[i] = Instantiate(prefab) as GameObject;
                    soju[i].AddComponent<BoxCollider2D>();
                    soju[i].GetComponent<BoxCollider2D>().isTrigger = true;
                    soju[i].AddComponent<Monster_Map3>();
                    switch (i)
                    {
                        case 0:
                            soju[i].transform.position = new Vector3(pos.x - 1, pos.y - 1, -1);
                            StartCoroutine(mBoxSojutMove(1f, 1, 0));

                            break;
                        case 1:
                            soju[i].transform.position = new Vector3(pos.x - 1, pos.y + 1, -1);
                            StartCoroutine(mBoxSojutMove(1f, 4, 1));
                            break;
                        case 2:
                            soju[i].transform.position = new Vector3(pos.x + 1, pos.y + 1, -1);
                            StartCoroutine(mBoxSojutMove(1f, 3, 2));
                            break;
                        case 3:
                            soju[i].transform.position = new Vector3(pos.x + 1, pos.y - 1, -1);
                            StartCoroutine(mBoxSojutMove(1f, 2, 3));
                            break;
                    }
                }

                break;

            case "mBlue":
                if (transform.gameObject.name == "-mBlue") StartCoroutine(mBoxRightMove(pixelTime * 3, 3));
                if (transform.gameObject.name == "mBlue") StartCoroutine(mBoxRightMove(pixelTime * 3, 1));
                if (transform.gameObject.name == "-mBlue-") StartCoroutine(mBoxRightMove(pixelTime * 3, 4));
                if (transform.gameObject.name == "mBlue-") StartCoroutine(mBoxRightMove(pixelTime * 3, 2));
                break;
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        stageNum = GameManager.Instance.getStageNum();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        pos1 = player1.gameObject.transform.position;
        pos2 = player2.gameObject.transform.position;
    }


    // Box 모양 움직이기 시계방향
    IEnumerator mBoxRightMove(float pixelTime, int flag)
    {

        movementFlag = flag;

        
        while (movementFlag < 5)
        {
            yield return new WaitForSeconds(pixelTime);
            movementFlag++;
        }
        movementFlag = 1;


        StartCoroutine(mBoxRightMove(pixelTime, movementFlag));
    }

    // Box 모양 움직이기 반시계방햐
    IEnumerator mBoxLeftMove(float pixelTime, int flag)
    {

        movementFlag = flag;


        while (movementFlag > 0)
        {
            yield return new WaitForSeconds(pixelTime);
            movementFlag--;
        }
        movementFlag = 4;


        StartCoroutine(mBoxLeftMove(pixelTime, movementFlag));
    }

    // Box 모양 움직이기 시계방ㅎ
    IEnumerator mBoxRightMove(float pixelTimeCol, float pixelTimeRow, int flag)
    {

        movementFlag = flag;


        while (movementFlag < 5)
        {
            if(movementFlag % 2 == 0)
            yield return new WaitForSeconds(pixelTimeCol);
            else
                yield return new WaitForSeconds(pixelTimeRow);
            movementFlag++;
        }
        movementFlag = 1;


        StartCoroutine(mBoxRightMove(pixelTimeCol, pixelTimeRow, movementFlag));
    }


    // Box 모양 움직이기 한꺼번에 여러개

    IEnumerator mBoxSojutMove(float pixelTime, int flag, int cases)
    {

        sojuFlag[cases] = flag;


        while (sojuFlag[cases] < 5)
        {
            yield return new WaitForSeconds(pixelTime);
            sojuFlag[cases]++;
        }
        sojuFlag[cases] = 1;

       
        StartCoroutine(mBoxSojutMove(1f, sojuFlag[cases], cases));
    }

    






    IEnumerator mLRMove(float pixelTime, int flag)
    {

        movementFlag = flag;

        while (movementFlag < 3)
        {
            yield return new WaitForSeconds(pixelTime);
            movementFlag++;
        }
        movementFlag = 1;


        StartCoroutine(mLRMove(pixelTime, movementFlag));
    }

    




    #region 움직임 제어 부분
    void BoxRotate()
    {

        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.up;
        }
        else if (movementFlag == 3)
        {
            moveVelocity = Vector3.right;
        }
        else if (movementFlag == 4)
        {
            moveVelocity = Vector3.down;
        }

        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    void UpDownMove()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (movementFlag == 1)
        {
            moveVelocity = Vector3.up;
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.down;
        }


        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    void LeftRightMove()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
        }


        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }



    #endregion

    void PurpleMove()
    {
        sojuRotate(0);
        sojuRotate(1);
        sojuRotate(2);
        sojuRotate(3);
    }

    void sojuRotate(int cases)
    {
        Vector3 moveVelocity = Vector3.zero;
        if (sojuFlag[cases] == 1)
        {
            moveVelocity = Vector3.right;
        }
        else if (sojuFlag[cases] == 2)
        {
            moveVelocity = Vector3.up;
        }
        else if (sojuFlag[cases] == 3)
        {
            moveVelocity = Vector3.left;
        }
        else if (sojuFlag[cases] == 4)
        {
            moveVelocity = Vector3.down;
        }

        soju[cases].transform.position += moveVelocity * 1f * Time.deltaTime;
    }

    




    void LeftDownMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = new Vector3(-1, -1, 0);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = new Vector3(1, 1, 0);
        }

        transform.position += moveVelocity * moveSpeed * Time.deltaTime;

    }

    void RightDownMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = new Vector3(1, -1, 0);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = new Vector3(-1, 1, 0);
        }

        transform.position += moveVelocity * moveSpeed * Time.deltaTime;


    }

}

