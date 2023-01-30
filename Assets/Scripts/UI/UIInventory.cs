using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{

    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
