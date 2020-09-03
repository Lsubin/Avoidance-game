using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public GameObject panelSetting, FreeTalk;
    public GameObject HowtoBtn;
     
    // Start is called before the first frame update
    void Start()
    {
        panelSetting.SetActive(false);
        FreeTalk.SetActive(false);
        HowtoBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingBtnOn()
    {
        panelSetting.SetActive(true);
    }

    public void SettingBtnExit()
    {
        panelSetting.SetActive(false);
    }

    public void FreeTalkBtnOn()
    {
        FreeTalk.SetActive(true);
    }
    public void FreeTalkBtnExit()
    {
        FreeTalk.SetActive(false);
    }

    public void HowtoBtnOn()
    {
        HowtoBtn.SetActive(true);
    }
    public void HowtoBtnExit()
    {
        HowtoBtn.SetActive(false);
    }
}
