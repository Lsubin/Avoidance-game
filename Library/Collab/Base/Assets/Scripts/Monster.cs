using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Monster : MonoBehaviour
{
   // public Text dcScoreText;
    public static int dataCollectionScore;
    //public GameObject[] mProf;
    //public GameObject[] mGreen;
    //public GameObject mPurple, mJoGyo, mYellow;


    enum MonsterType
    {
        mProfessor = 0, // cha_gyosu
        mJogyo = 1, // cha_jogyo
        mGreen = 2, // friend2
        mYellow = 3, // friend4
        mPurple = 4, // friend1
        mBlue = 5 // friend 3

    }


    //  static Player player;
    float pixelTime = 0.5f;
    Vector3 pos;
    float delta = 2.0f;
    int movementFlag = 0; // 0: Idle, 1: Right, 2: Up, 3: Left, 4: Down
    int monsterFlag = 0; // 0:
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    //Monster obj;

  


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
           
            GameManager.Instance.Damage1(0, collision.tag);
            dataCollectionScore = GameManager.Instance.getDataCollection(collision.tag);

            Debug.Log(dataCollectionScore);
           // ShowScoreText();
        }

        
    }
   

    void Awake()
    {
        
        //Monster obj = FindObjectOfType(typeof(Monster)) as Monster;
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
               // monsterFlag = 1;
                break;
            case "mGreen":
              //  StartCoroutine("ChangeMovement2");
                break;
            case "mYellow":
                StartCoroutine("ChangeMovement");
                break;
            case "mPurple":
                //monsterFlag = 4;
                break;
            case "mBlue":
               // monsterFlag = 5;
                break;
        }



       // StartCoroutine("ChangeMovement2");
    }

     void FixedUpdate()
    {

        switch (monsterFlag)
        {
            case (int) MonsterType.mProfessor:
                LeftDownMove();
                break;
            case (int)MonsterType.mJogyo:
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
        yield return new WaitForSeconds(pixelTime);
        movementFlag = 2;
        yield return new WaitForSeconds(pixelTime);
        StartCoroutine("ChangeMovement2");
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
            moveVelocity = new Vector3(-2, -2, 0); 
        }
        else if (movementFlag == 2)
        {
            moveVelocity = new Vector3(2, 2, 0);
        }

        transform.position += moveVelocity * moveSpeed * Time.deltaTime;

    }



    void PurpleMove()
    {
        GameObject prefab = Resources.Load("Prefabs/soju") as GameObject;
        GameObject soju = Instantiate(prefab) as GameObject;

        soju.transform.position = new Vector3(1.5f, 2.0f, 0);
    }








}
