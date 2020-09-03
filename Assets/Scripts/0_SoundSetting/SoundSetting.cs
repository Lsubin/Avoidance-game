using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSetting : MonoBehaviour
{

    public Slider BackGroundMusic;
    public Slider SFX;
    
    // Start is called before the first frame update
    private void Start()
    {
        
       


        if (DataController.Instance.gameData.BGMSound == 0)
            BackGroundMusic.value = 0;
        else if (DataController.Instance.gameData.BGMSound == 1)
            BackGroundMusic.value = 1;

        if (DataController.Instance.gameData.EffectSound == 0)
            SFX.value = 0;
        else if (DataController.Instance.gameData.EffectSound == 1)
            SFX.value = 1;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {


        SoundManager2.Instance.SetVolumeBGM(BackGroundMusic.value);
            DataController.Instance.gameData.BGMSound = (int)BackGroundMusic.value;

        SoundManager2.Instance.SetVolumeSFX(SFX.value);
        DataController.Instance.gameData.EffectSound = (int)SFX.value;

        
    }
        
         

        //if (EffectSound.value == 0)
        //{
        //    DataController.Instance.gameData.EffectSound = 0;
        //}
        //else if (EffectSound.value == 1)
        //{
        //    DataController.Instance.gameData.EffectSound = 1;
        //}
    
}

