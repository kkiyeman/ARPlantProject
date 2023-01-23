using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScene : MonoBehaviour
{
    private void Start()
    {
        PlantManager plantmanager = PlantManager.GetInstance();
        UIManager uimanager = UIManager.GetInstance();
        SoundManager soundmanager = SoundManager.GetInstance();
        uimanager.OpenUI("UIPlant");
        uimanager.OpenUI("UIStore");
        
        

        UIStore uistore = uimanager.GetUI("UIStore").GetComponent<UIStore>();
        uistore.gameObject.SetActive(false);


        UIPlant uiplant = uimanager.GetUI("UIPlant").GetComponent<UIPlant>();
        

    }
}
