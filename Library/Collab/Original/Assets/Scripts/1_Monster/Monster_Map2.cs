using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Map2 : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    int stageNum;
    int monsterFlag = 0;
    int movementFlag = 0;


    float moveSpeed = 2f;
    float pixelTime = 0.5f;
    Vector3 pos;


    // 플레이어의 시작 위치 제공
    Vector3 pos1, pos2;

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
                if (transform.gameObject.name == "-mProfessor")
                {
                    RightDownMove();
                }
                else { LeftDownMove(); }

                break;
            case (int)MonsterType.mJogyo:
                TimeRotate();
                break;
            case (int)MonsterType.mGreen:

                LRMove();
                break;
            case (int)MonsterType.mYellow:
                TimeRotate();
                break;
            case (int)MonsterType.mPurple:

                break;
            case (int)MonsterType.mBlue:

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

    void Awake()
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


                StartCoroutine(mLRMove(pixelTime * 10, 1));
                break;
            case "mJogyo":
                StartCoroutine("mJogyoMove", pixelTime);
                break;
            case "mGreen":

                if (transform.gameObject.name == "-mGreen")
                {
                    StartCoroutine(mLRMove(pixelTime * 5, 2));
                }
                else
                    StartCoroutine(mLRMove(pixelTime * 5, 1));
                break;
            case "mYellow":
                StartCoroutine(mBoxMove(pixelTime * 3, 2));
                break;
            case "mPurple":

                break;
            case "mBlue":

                break;
        }

    }






    // Start is called before the first frame update
    void Start()
    {

        stageNum = GameManager.Instance.getStageNum();
        pos1 = player1.gameObject.transform.position;
        pos2 = player2.gameObject.transform.position;
        //  MonsterCreate();
    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator mJogyoMove(float pixelTime)
    {

        movementFlag = 1;
        yield return new WaitForSeconds(pixelTime);

        movementFlag = 2;

        yield return new WaitForSeconds(pixelTime * 10);

        movementFlag = 3;

        yield return new WaitForSeconds(pixelTime);

        movementFlag = 4;

        yield return new WaitForSeconds(pixelTime * 10);
        StartCoroutine("mJogyoMove", 0.5f);
    }

    IEnumerator mBoxMove(float pixelTime, int flag)
    {

        movementFlag = flag;

        while (movementFlag < 5)
        {
            yield return new WaitForSeconds(pixelTime);
            movementFlag++;
        }
        movementFlag = 1;


        StartCoroutine(mBoxMove(pixelTime, movementFlag));
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







    void TimeRotate()
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

    void LRMove()
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




    // GameObject[] mGreen;

    //void MonsterCreate()
    //{
    //    GameObject prefab = Resources.Load("Prefabs/mGreen") as GameObject;
    //     mGreen = new GameObject[2];
    //    for(int i = 0; i< 2; i++){
    //        mGreen[i] = Instantiate(prefab) as GameObject;
    //        mGreen[i].AddComponent<BoxCollider2D>();
    //        mGreen[i].GetComponent<BoxCollider2D>().isTrigger = true;
    //        mGreen[i].AddComponent<Monster_Map2>();
    //        mGreen[i].gameObject.name = "-mGreen";
    //    }



    //    mGreen[0].transform.position = new Vector3(-1.75f, 0.75f, -1);
    //    mGreen[1].transform.position = new Vector3(-1.75f, -0.27f, -1);


    //}



    public float moveSpeed2 = 0.5f;
    public float a = 1f;
    void LeftDownMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = new Vector3(-a, -a, 0);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = new Vector3(a, a, 0);
        }

        transform.position += moveVelocity * moveSpeed2 * Time.deltaTime;

    }

    void RightDownMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = new Vector3(a, -a, 0);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = new Vector3(-a, a, 0);
        }

        transform.position += moveVelocity * moveSpeed2 * Time.deltaTime;

    }


}