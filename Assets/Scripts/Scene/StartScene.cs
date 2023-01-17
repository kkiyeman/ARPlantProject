using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    
    void Start()
    {
        UIManager uimanager = UIManager.GetInstance();
        uimanager.OpenUI("UIStart");

        UIStart uistart = uimanager.GetUI("UIStart").GetComponent<UIStart>();

    }


}
