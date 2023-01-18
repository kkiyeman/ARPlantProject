using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScene : MonoBehaviour
{
    private void Start()
    {
        PlantManager plantmanager = PlantManager.GetInstance();
        UIManager uimanager = UIManager.GetInstance();
        uimanager.OpenUI("UIPlant");

        UIPlant uiplant = uimanager.GetUI("UIPlant").GetComponent<UIPlant>();
        uiplant.gameObject.SetActive(false);

    }
}
