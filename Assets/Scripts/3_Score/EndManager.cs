using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndManager : MonoBehaviour
{
    
    int stageLengh = 3;
    int[] scoreP1, scoreP2;

    // Start is called before the first frame update
    void Start()
    {
      
        GameObject[] text1 = new GameObject[3];
        GameObject[] text2 = new GameObject[3];
        text1[0] = GameObject.Find("dataCollectionValue1");
        text1[1] = GameObject.Find("pptValue1");
        text1[2] = GameObject.Find("announceValue1");
        text2[0] = GameObject.Find("dataCollectionValue2");
        text2[1] = GameObject.Find("pptValue2");
        text2[2] = GameObject.Find("announceValue2");

        GameObject[] totalScoreText = new GameObject[2];

        totalScoreText[0] = GameObject.Find("totalScoreTextValue1");
        totalScoreText[1] = GameObject.Find("totalScoreTextValue2");

        scoreP1 = new int[stageLengh];
        scoreP2 = new int[stageLengh];

        scoreP1[0] = GameManager.Instance.getDataCollection("Player1");
        scoreP1[1] = GameManager.Instance.getPPT("Player1");
        scoreP1[2] = GameManager.Instance.getAnnounce("Player1");


        scoreP2[0] = GameManager.Instance.getDataCollection("Player2");
        scoreP2[1] = GameManager.Instance.getPPT("Player2");
        scoreP2[2] = GameManager.Instance.getAnnounce("Player2");





        for (int i = 0; i<stageLengh; i++)
        {
            
            text1[i].GetComponent<Text>().text =  scoreP1[i].ToString();
            text2[i].GetComponent<Text>().text = scoreP2[i].ToString();
        }


        string grade1, grade2;
        grade1 = getGrade(scoreP1[0], scoreP1[1], scoreP1[2]);
        grade2 = getGrade(scoreP2[0], scoreP2[1], scoreP2[2]);
        totalScoreText[0].GetComponent<Text>().text = grade1;
        totalScoreText[1].GetComponent<Text>().text = grade2;


    }

    // Update is called once per frame
    void Update()
    {
        
    }








    private string getGrade(int a, int p, int d)
    {
        string grade = "";

        // if로 조집니다.
        if (a >= 10 && p >= 10 && d >= 10) grade = "A+";
        else if (a >= 9 && p >= 9 && d >= 9) grade = "A";
        else if (a >= 8 && p >= 8 && d >= 8) grade = "B+";
        else if (a >= 7 && p >= 7 && d >= 7) grade = "B";
        else if ((a >= 7 && p >= 7) || (a >= 7 && d >= 7) || (p >= 7 && d >= 7)) grade = "C+";
        else if ((a >= 6 && p >= 6) || (a >= 6 && d >= 6) || (p >= 6 && d >= 6)) grade = "C";
        else if ((a >= 5 && p >= 5) || (a >= 5 && d >= 5) || (p >= 5 && d >= 5)) grade = "D+";
        if ((a < 5 && p < 5) || (a < 5 && d < 5) || (p < 5 && d < 5)) grade = "D";
        if ((a < 5 && p<5 && d < 5)) grade = "F";

        return grade;
    }
}
