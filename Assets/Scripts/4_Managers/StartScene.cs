using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Button startBtn;

    // Start is called before the first frame update
    void Start()
    {
        startBtn = this.transform.GetComponent<Button>();
        startBtn.onClick.AddListener(OnClickStartButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 시작 버튼 누르면 맵1 화면으로 이동
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Map1");
    }
}
