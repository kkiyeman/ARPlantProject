using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    void Awake()
    {
        UIManager uimanager = UIManager.GetInstance();

        uimanager.OpenUI("UIStart");
        UIStart uistart = uimanager.GetUI("UIStart").GetComponent<UIStart>();
        AudioManager.GetInstance().PlayBgm("Start");
    }




}
