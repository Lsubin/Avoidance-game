using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ItemManager : MonoBehaviour
{
    public static int dataCollectionScore;
    public static int ppt;
    public static int annouce;
    enum ItemType
    {
        redItem = 0, // red
        blueItem = 1, // blue
        yellowItem = 2, // yellow
        purpleItem = 3, // friend4
    }

    int itemFlag = -1; // default
    int stageNum;


    // public static Player player;
    //  public static Monster monster;
    // Start is called before the first frame update


    void Awake()
    {

        //Monster obj = FindObjectOfType(typeof(Monster)) as Monster;
      //  Debug.Log(transform.tag);
        switch (transform.tag)
        {
            case "redItem":
                itemFlag = 0;
                break;
            case "blueItem":
                itemFlag = 1;
                break;
            case "yellowItem":
                itemFlag = 2;
                break;
            case "purpleItem":
                itemFlag = 3;
                break;
        }
    }

        void Start()
    {
        stageNum = GameManager.Instance.getStageNum();
    }

    // Update is called once per frame
    void Update()
    {
       
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {


        switch (itemFlag)
        {
            case (int)ItemType.redItem:
                if (collision.CompareTag("Player1"))
                {
                    GameManager.Instance.getItemYellow(stageNum, collision.tag);
                    Destroy(gameObject);
                }
                else { }
                break;

            case (int)ItemType.blueItem:
                if (collision.CompareTag("Player2"))
                {
                    GameManager.Instance.getItemYellow(stageNum, collision.tag);
                    Destroy(gameObject);
                }
                else { }
                break;

            case (int)ItemType.yellowItem:
                if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
                {
                    GameManager.Instance.getItemYellow(stageNum, collision.tag);
                    Destroy(gameObject);
                }
                else { }
                break;

            case (int)ItemType.purpleItem:
                if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
                {
                    GameManager.Instance.getItemPurple(stageNum);
                    Destroy(gameObject);
                }
                else { }
                break;

        }
       
    }



}
