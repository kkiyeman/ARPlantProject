using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIStore : MonoBehaviour
{


    [Header("Upper Side")]
    [SerializeField] Button btnCloseStore;
    [SerializeField] Text txtEnergy;
    [SerializeField] Text txtGold;

    [Header("Left Side")]
    [SerializeField] Button[] btnItemKinds;
    [SerializeField] Text[] txtItemKinds;

    [Header("Item List")]
    [SerializeField] Button[] btnItems;
    [SerializeField] Text[] txtItems;

    [Header("Item Buy PopUp")]
    [SerializeField] Button btnCloseBuy;
    [SerializeField] Image imgItemBuy;
    [SerializeField] Text txtItemBuy;
    [SerializeField] Text txtItemPrice;
    [SerializeField] Text txtItemCount;
    private int curCount = 1;
    [SerializeField] Text txtTotalPrice;
    [SerializeField] InputField inputItemCount;
    [SerializeField] Button btnItemCountMinus;
    [SerializeField] Button btnItemCountPlus;
    [SerializeField] Button btnItemBuy;
    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;

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
