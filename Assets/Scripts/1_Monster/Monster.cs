using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;


// 몬스터 클래스입니다 ^^
public class Monster : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public static int dataCollectionScore;
    
    int stageNum;

    enum MonsterType
    {
        mProfessor = 0, // cha_gyosu
        mJogyo = 1, // cha_jogyo
        mGreen = 2, // friend2
        mYellow = 3, // friend4
        mPurple = 4, // friend1
        mBlue = 5 // friend 3

    }

    
    float pixelTime = 0.5f;
    Vector3 pos;
    float delta = 2.0f;
    int movementFlag = 0; // 0: Idle, 1: Right, 2: Up, 3: Left, 4: Down
    int[] sojuFlag;
    int monsterFlag = 0; // 0:
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    GameObject[] soju;

    // 현재 스테이지가 어떤 스테이지인지 확인한다.
    private void Start()
    {
        stageNum = GameManager.Instance.getStageNum();
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
            dataCollectionScore = GameManager.Instance.getDataCollection(collision.tag);

            Debug.Log(dataCollectionScore);
            
            // Player1 부딪히면 원점으로
            if (collision.CompareTag("Player1"))
            {
                SoundManager2.Instance.PlaySound("Jab", 0.2f);
                player1 = collision.gameObject;
                player1.transform.position = new Vector3(-3.49f, 6.51f, -1.00f);
            }
            // Player2 부딪히면 원점으로
            if (collision.CompareTag("Player2"))
            {
                SoundManager2.Instance.PlaySound("Jab", 0.2f);
                player2 = collision.gameObject;
                player2.transform.position = new Vector3(-1.51f, 6.51f, -1.00f);
            }
        }

        
    }


    




    void Awake()
    {

        
        Debug.Log(transform.tag);
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
                StartCoroutine("ChangeMovement2");
                break;
            case "mJogyo":
                StartCoroutine("ChangeMovement4", 0.5f);
                break;
            case "mGreen":
              //  StartCoroutine("ChangeMovement2");
                break;
            case "mYellow":
                StartCoroutine("ChangeMovement");
                break;
            case "mPurple":
                //monsterFlag = 4;
                GameObject prefab = Resources.Load("Prefabs/soju") as GameObject;
                soju = new GameObject[4];
                sojuFlag = new int[4];
                Vector3 pos = transform.position;
                for (int i = 0; i< soju.Length; i++)
                {
                    soju[i] = Instantiate(prefab) as GameObject;
                    soju[i].AddComponent<BoxCollider2D>();
                    soju[i].GetComponent<BoxCollider2D>().isTrigger = true;
                    soju[i].AddComponent<Monster>();
                    switch (i)
                    {
                        case 0:
                            soju[i].transform.position = new Vector3(pos.x - 1, pos.y - 1, -1);
                            StartCoroutine(ChangeMovement3(1f, 1, 0));
                            
                            break;
                        case 1:
                            soju[i].transform.position = new Vector3(pos.x - 1, pos.y + 1, -1);
                            StartCoroutine(ChangeMovement3(1f, 4, 1));
                            break;
                        case 2:
                            soju[i].transform.position = new Vector3(pos.x + 1, pos.y + 1, -1);
                            StartCoroutine(ChangeMovement3(1f, 3, 2));
                            break;
                        case 3:
                            soju[i].transform.position = new Vector3(pos.x + 1, pos.y - 1, -1);
                            StartCoroutine(ChangeMovement3(1f, 2, 3));
                            break;
                    }
                    
                }

                
                
                
                

                
                break;
            case "mBlue":
               // monsterFlag = 5;
                break;
        }


    }

     void FixedUpdate()
    {

        switch (monsterFlag)
        {
            case (int) MonsterType.mProfessor:
                LeftDownMove();
                break;
            case (int)MonsterType.mJogyo:
                TimeRotate();
                // monsterFlag = 1;
                break;
            case (int) MonsterType.mGreen:
                LeftRightMove();
                break;
            case (int) MonsterType.mYellow:
                RotationMove();
                // monsterFlag = 3;
                break;
            case (int)MonsterType.mPurple:
                PurpleMove();
                break;
            case (int)MonsterType.mBlue:
                // monsterFlag = 5;
                break;
        }
        //  RotationMove();
        //LeftRightMove();
       // LeftDownMove();
    }

    IEnumerator ChangeMovement()
    {

        movementFlag = 1;
        yield return new WaitForSeconds(pixelTime);

        movementFlag = 2;

        yield return new WaitForSeconds(pixelTime);

        movementFlag = 3;

        yield return new WaitForSeconds(pixelTime);

        movementFlag = 4;

        yield return new WaitForSeconds(pixelTime);
       StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement2()
    {
        movementFlag = 1;
        yield return new WaitForSeconds(pixelTime * 4);
        movementFlag = 2;
        yield return new WaitForSeconds(pixelTime * 4);
        StartCoroutine("ChangeMovement2");
    }

   
    // Purple
    public IEnumerator ChangeMovement3(float pixelTime, int flag, int cases)
    {
        
        sojuFlag[cases] = flag;

        while (sojuFlag[cases] < 5)
        {
            yield return new WaitForSeconds(pixelTime);
            sojuFlag[cases]++;
        }
        sojuFlag[cases] = 1;

        StartCoroutine(ChangeMovement3(1f, sojuFlag[cases], cases));
    }



    // JoGyo
    IEnumerator ChangeMovement4(float pixelTime)
    {

        movementFlag = 1;
        yield return new WaitForSeconds(pixelTime);

        movementFlag = 2;

        yield return new WaitForSeconds(pixelTime * 4);

        movementFlag = 3;

        yield return new WaitForSeconds(pixelTime);

        movementFlag = 4;

        yield return new WaitForSeconds(pixelTime * 4);
        StartCoroutine("ChangeMovement4", 0.5f);
    }




    void RotationMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(movementFlag == 1)
        {
            moveVelocity = Vector3.right;
         
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.up;
        }
        else if (movementFlag == 3)
        {
            moveVelocity = Vector3.left;
        }
        else if (movementFlag == 4)
        {
            moveVelocity = Vector3.down;
        }

        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    void LeftRightMove()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * moveSpeed);
        transform.position = v;
    }


    void LeftDownMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(movementFlag == 1)
        {
            moveVelocity = new Vector3(-1, -1, 0); 
        }
        else if (movementFlag == 2)
        {
            moveVelocity = new Vector3(1, 1, 0);
        }

        transform.position += moveVelocity  * 0.5f * Time.deltaTime;

    }



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





}
