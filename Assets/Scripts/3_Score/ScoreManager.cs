using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager: MonoBehaviour
{

    public Text Player1Score;
    public Text Player2Score;

    int stageNum = 0;
    private void Start()
    {
        stageNum = GameManager.Instance.getStageNum();

    }


    private void Update()
    {
        ShowScoreText();
    }
    void setScore(Player player)
    {
        //int a = player.getAnnounce();
        //int p = player.getPpt();
        //int d = player.getDataCollection();


       // string grade = getGrade(a, p, d);


        // grade 값 주기
       // Debug.Log(grade);
    }

    public void ShowScoreText()
    {
        if (stageNum == 0)
        {
            Player1Score.text = "점수: " + string.Format("{0}", GameManager.Instance.getDataCollection("Player1")) + " 점";
            Player2Score.text = "점수: " + string.Format("{0}", GameManager.Instance.getDataCollection("Player2")) + " 점";
        }
        else if (stageNum == 1)
        {
            Player1Score.text = "점수: " + string.Format("{0}", GameManager.Instance.getPPT("Player1") + " 점");
            Player2Score.text = "점수: " + string.Format("{0}", GameManager.Instance.getPPT("Player2") + " 점");
        }
        else if (stageNum == 2)
        {
            Player1Score.text = "점수: " + string.Format("{0}", GameManager.Instance.getAnnounce("Player1")) + " 점";
            Player2Score.text = "점수: " + string.Format("{0}", GameManager.Instance.getAnnounce("Player2")) + " 점";
        }
    }


    private string getGrade(int a, int p, int d) {
        string grade = "";

        // if로 조집니다.
        if (a >= 10 && p >= 10 && d >= 10) grade = "A+";
        else if (a >= 9 && p >= 9 && d >= 9) grade = "A";
        else if (a >= 8 && p >= 8 && d >= 8) grade = "B+";
        else if (a >= 7 && p >= 7 && d >= 7) grade = "B";
        else if ((a >= 7 && p >= 7) || (a >= 7 && d >= 7) || (p >= 7 && d >= 7)) grade = "C+";
        else if ((a >= 6 && p >= 6) || (a >= 6 && d >= 6) || (p >= 6 && d >= 6)) grade = "C";
        else if ((a >= 5 && p >= 5) || (a >= 5 && d >= 5) || (p >= 5 && d >= 5)) grade = "D+";
        else if ((a < 5 && p < 5 && d < 5)) grade = "F";
        else if ((a < 5 && p < 5) || (a < 5 && d < 5) || (p < 5 && d < 5)) grade = "D";
        

        return grade;
    }
       
    
}
