using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene : MonoBehaviour
{
    
    void Awake()
    {
        UIManager uimanager = UIManager.GetInstance();

        uimanager.OpenUI("UITutorial");
        UITutorial uitutorial = uimanager.GetUI("UITutorial").GetComponent<UITutorial>();

    }
}
