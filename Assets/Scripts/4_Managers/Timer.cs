using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    /*
    public float time;
    public Text timeText;

    private void Start()
    {
        time = 150f;
    }

    private void Update()
    {
        if ((int)time == 0)
        {
            timeText.text = "다음 씬 넘기기";
            time = 0;
        }
        else
        {
            time -= Time.deltaTime;
            timeText.text = "남은 시간 : " + string.Format("{0:f0}", time) + " 초";
        }
    }*/

    public Text timeText;
    Slider slTimer;
    float fSliderBarTime;
    public int stageNum;
    public GameObject TimeOver;

    void Start()
    {
        slTimer = GetComponent<Slider>();
        stageNum = GameManager.Instance.getStageNum();
        TimeOver.gameObject.SetActive(false);
    }

    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            slTimer.value -= Time.deltaTime;
            timeText.text = string.Format("{0:f0}", slTimer.value) + " 초";
        }
        // 타이머가 0초가 되면 3초 후 게임신 다시 시작!
        else
        {
            TimeOver.gameObject.SetActive(true);
            Invoke("startScene", 3f);
        }
    }

    public void startScene()
    {
        TimeOver.gameObject.SetActive(false);

        switch (stageNum)
        {
            case 0:
                SceneManager.LoadScene("Map1");
                GameManager.Instance.restart(stageNum);
                break;
            case 1:
                SceneManager.LoadScene("Map2");
                GameManager.Instance.restart(stageNum);
                break;
            case 2:
                SceneManager.LoadScene("Map3");
                GameManager.Instance.restart(stageNum);
                break;

        }

        

    }
}
