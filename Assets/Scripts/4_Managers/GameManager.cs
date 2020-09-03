using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Vector2 speed_vec;
    public int speed = 5; //스피드

    [SerializeField]
    public  GameObject player1;
    [SerializeField]
    public  GameObject player2;
    PlayerData p1, p2;
    public int stageNum;
 

    public static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null) Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

   
    


    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(this);
            return;
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(this);
        
        
        
        
    }

    // 플레이어 포인트
    struct PlayerData
    {
        public int dataCollection;
        public int ppt;
        public int announce;
    }

    
    


    // 스테이지 값
    enum Stage
    {
        DATACOLLECTION = 0,
        PPT = 1,
        ANNOUNCE = 2,
        STAGECOUNT = 3
    }


    // -1 닿았을 때
     public void Damage1(int stageNum, string tag)
    {
        if (tag == "Player1")
        {
            switch (stageNum)
            {
                case (int)Stage.DATACOLLECTION:
                    p1.dataCollection -= 1;
                    break;
                case (int)Stage.PPT:
                    p1.ppt -= 1;
                    break;
                case (int)Stage.ANNOUNCE:
                    p1.announce -= 1;
                    break;
            }
        }
        else if (tag == "Player2"){
            switch (stageNum)
            {
                case (int)Stage.DATACOLLECTION:
                    p2.dataCollection -= 1;
                    break;
                case (int)Stage.PPT:
                    p2.ppt -= 1;
                    break;
                case (int)Stage.ANNOUNCE:
                    p2.announce -= 1;
                    break;
            }
        }
    }



    // -2 닿았을 때
   public  void Damage2(int stageNum, string tag)
    {
        if (tag == "Player1")
        {
            switch (stageNum)
            {
                case (int)Stage.DATACOLLECTION:
                    p1.dataCollection -= 2;
                    break;
                case (int)Stage.PPT:
                    p1.ppt -= 2;
                    break;
                case (int)Stage.ANNOUNCE:
                    p1.announce -= 2;
                    break;
            }
        }
        else if (tag == "Player2")
        {
            switch (stageNum)
            {
                case (int)Stage.DATACOLLECTION:
                    p2.dataCollection -= 2;
                    break;
                case (int)Stage.PPT:
                    p2.ppt -= 2;
                    break;
                case (int)Stage.ANNOUNCE:
                    p2.announce -= 2;
                    break;
            }
        }
    }



    public void getItemYellow(int stageNum, string tag)
    {
        if (tag == "Player1")
        {
            switch (stageNum)
            {
                case (int)Stage.DATACOLLECTION:
                    p1.dataCollection += 1;
                    break;
                case (int)Stage.PPT:
                    p1.ppt += 1;
                    break;
                case (int)Stage.ANNOUNCE:
                    p1.announce += 1;
                    break;
            }
        }
        else if (tag == "Player2")
        {
            switch (stageNum)
            {
                case (int)Stage.DATACOLLECTION:
                    p2.dataCollection += 1;
                    break;
                case (int)Stage.PPT:
                    p2.ppt += 1;
                    break;
                case (int)Stage.ANNOUNCE:
                    p2.announce += 1;
                    break;
            }
        }
    }


    public void getItemPurple(int stageNum)
    {
            switch (stageNum)
            {
                case (int)Stage.DATACOLLECTION:
                    p1.dataCollection += 2;
                p2.dataCollection += 2;
                break;
                case (int)Stage.PPT:
                    p1.ppt += 2;
                p2.ppt += 2;
                break;
                case (int)Stage.ANNOUNCE:
                    p1.announce += 2;
                p2.announce += 2;
                break;
            }
       
        
    }

    public void setGame(GameObject player)
    {
        if (player.gameObject.tag == "Player1")
        {
            player1 = player;
        }
        if (player.gameObject.tag == "Player2")
        {
            player2 = player;
        }
    }

    

    


    Vector3 pos1, pos2;

    void Start()
    {
        p1.dataCollection = 3;
        p1.announce = 3;
        p1.ppt = 3;
        p2.dataCollection = 3;
        p2.announce = 3;
        p2.ppt = 3;
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        pos1 = player1.gameObject.transform.position;
        pos2 = player2.gameObject.transform.position;
        

    }

    

    

    void Update()
    {

        if (SceneManager.GetActiveScene().name != "EndScene")
        {
            moveASDW();
            moveArrow();
        }
        notOut();
       
        

    }

    public int getStageNum()
    {
        CheckStage();
        return stageNum;
    }


    public void CheckStage()
    {
        string scene = SceneManager.GetActiveScene().name;
        
        switch (scene)
        {
            case "Map1":
                stageNum = 0;
                break;
            case "Map2":
                stageNum = 1;
                break;
            case "Map3":
                stageNum = 2;
                break;

        }

        Debug.Log("StageNumber is : "+stageNum);
    }




    // Player1 이동
    public void moveASDW()
    {
        speed_vec = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
            speed_vec.x += speed;
        else if (Input.GetKey(KeyCode.A))
            speed_vec.x -= speed;
        if (Input.GetKey(KeyCode.W))
            speed_vec.y += speed;
        else if (Input.GetKey(KeyCode.S))
            speed_vec.y -= speed;

        player1.GetComponent<Rigidbody2D>().velocity = speed_vec;
    }

    // Player2 이동
    public void moveArrow()
    {
        speed_vec = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
            speed_vec.x += speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            speed_vec.x -= speed;
        if (Input.GetKey(KeyCode.UpArrow))
            speed_vec.y += speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            speed_vec.y -= speed;

        player2.GetComponent<Rigidbody2D>().velocity = speed_vec;
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



    //// 데이터 전달
    public int getDataCollection(string tag)
    {
        if (tag == "Player1")
            return p1.dataCollection;
        else if (tag == "Player2")
            return p2.dataCollection;
        else
            return 0;
    }

    //// 데이터 전달
    public int getPPT(string tag)
    {
        if (tag == "Player1")
            return p1.ppt;
        else if (tag == "Player2")
            return p2.ppt;
        else
            return 0;
    }

    //// 데이터 전달
    public int getAnnounce(string tag)
    {
        if (tag == "Player1")
            return p1.announce;
        else if (tag == "Player2")
            return p2.announce;
        else
            return 0;
    }


    public void restart(int stageNum)
    {
        switch (stageNum)
        {
            case 0:
                p1.dataCollection = 3; p2.dataCollection = 3;
                break;
            case 1:
                p1.ppt = 3; p2.ppt = 3;
                break;
            case 2:
                p1.announce = 3;p2.announce = 3;
                break;
        }

        
       
        

        player1.gameObject.transform.position = pos1;
        player2.gameObject.transform.position = pos1;
    }



    public void resetValue()
    {
        p1.dataCollection = 3; p2.dataCollection = 3;
        p1.ppt = 3; p2.ppt = 3;
        p1.announce = 3; p2.announce = 3;

    }
}
