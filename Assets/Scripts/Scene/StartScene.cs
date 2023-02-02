using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    void Awake()
    {
        UIManager uimanager = UIManager.GetInstance();

        uimanager.OpenUI("UIStart");
        UIStart uistart = uimanager.GetUI("UIStart").GetComponent<UIStart>();
        UIOption uioption = uimanager.GetUI("UIOption").GetComponent<UIOption>();
        AudioManager soudnplayer = AudioManager.GetInstance();
        soudnplayer.PlayBgm("Start");

    }




}
