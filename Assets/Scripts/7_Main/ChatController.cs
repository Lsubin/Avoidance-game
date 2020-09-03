using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatController : MonoBehaviour
{
    public Text ChatText;
    string writerText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("이번 학기 성적평가는 \n팀프로젝트로 진행합니다."));
    }


    IEnumerator NormalChat(string narration)
    {
        int a = 0;
        writerText = "";

        for (a = 0; a <narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
