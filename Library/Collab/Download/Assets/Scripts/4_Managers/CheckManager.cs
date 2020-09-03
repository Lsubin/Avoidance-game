using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckManager : MonoBehaviour
{
    public Image image;
    public static bool  [] Flag;
    public int stageNum;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Flag = new bool[2] { false, false };
        image.gameObject.SetActive(false);
        stageNum = GameManager.Instance.getStageNum();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag[0] == true && Flag[1] == true)
        {
            Debug.Log(Flag[0]);
            Debug.Log(Flag[1]);
            image.gameObject.SetActive(true);

            nextScene();
            
        }
    }
    
    public void nextScene()
    {
        switch(stageNum)
        {
            case 0:
                Invoke("goMap", 3.00f);
                break;
            case 1:
                Invoke("goMap", 3.00f);
                break;
            case 2:
                Invoke("goEnd", 3.00f);
                break;
        }
            
    }

    public void goMap()
    {
        int num = stageNum + 2;
        SceneManager.LoadScene("Map" + num.ToString());
    }

    public void goEnd()
    {
        SceneManager.LoadScene("EndScene");
    }



    public void OnTriggerEnter2D(Collider2D col)
    {   if (transform.name == "redGoal")
        {
            if (col.tag == "Player1")
            {
                Debug.Log("redGoal");
                Flag[0] = true;
            }
            else { }
        }
        if (transform.name == "blueGoal")
        {
            if (col.tag == "Player2")
            {
                Debug.Log("blueGoal");
                Flag[1] = true;
            }
            else { }

        }

    }
}
