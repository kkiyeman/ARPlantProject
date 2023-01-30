using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScene : MonoBehaviour
{
    private void Start()
    {
        PlantManager plantmanager = PlantManager.GetInstance();
        UIManager uimanager = UIManager.GetInstance();

        MyPlantManager myplantmanager = MyPlantManager.GetInstance();
        
        uimanager.OpenUI("UIPlant");
        uimanager.OpenUI("UIStore");
        uimanager.OpenUI("UIDictionary");
        uimanager.OpenUI("UIOption");
        uimanager.OpenUI("UIInventory");

        UIPlant uiplant = uimanager.GetUI("UIPlant").GetComponent<UIPlant>();

        UIStore uistore = uimanager.GetUI("UIStore").GetComponent<UIStore>();
        uistore.gameObject.SetActive(false);

        UIOption uioption = uimanager.GetUI("UIOption").GetComponent<UIOption>();
        uioption.gameObject.SetActive(false);

        UIDictionary uidictionary = uimanager.GetUI("UIDictionary").GetComponent<UIDictionary>();
        uidictionary.gameObject.SetActive(false);

        UIInventory uiinventory = uimanager.GetUI("UIInventory").GetComponent<UIInventory>();
        uiinventory.gameObject.SetActive(false);

        AudioManager audiomanager = AudioManager.GetInstance();
        audiomanager.PlayBgm("PlantBgm");

    }
}
