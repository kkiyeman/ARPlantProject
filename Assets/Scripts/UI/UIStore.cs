using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIStore : MonoBehaviour
{
    [Header("Right Side")]
    [SerializeField] Button btnTemp;
    [SerializeField] Button btnStore;

    [Header("Bottom Side")]
    [SerializeField] GameObject bottomButtons;
    [SerializeField] Button btnWater;
    [SerializeField] Button btnPill;
    [SerializeField] Button btnComment;
    [SerializeField] Button btnSeed;

    [Header("Upper Side")]
    [SerializeField] Button btnCloseStore;
    [SerializeField] Text txtCurtime;
    [SerializeField] Text txtEnergy;
    [SerializeField] Text txtGold;
    [HideInInspector] public float totalEnergy = 100;
    [HideInInspector] public float curEnergy = 50;
    [HideInInspector] public int Gold = 1000;
    [SerializeField] Slider sldEnergy;

    [Header("Status")]
    [SerializeField] Image imgStatus;
    [SerializeField] Button btnCloseStatus;
    [SerializeField] Button btnPlantName;
    [SerializeField] Text txtPlantName;
    string plantName = "FishBone";
    [SerializeField] InputField inputPlantName;
    [SerializeField] Button btnClosePlantInputfield;
    [SerializeField] Image imgsWhatPlant;
    [SerializeField] Button btnMemo;
    [SerializeField] Image imgMemo;
    [SerializeField] Text txtMemo;
    [SerializeField] Button btnCloseMemo;
    [SerializeField] InputField inputMemo;
    [SerializeField] Button btnOnInputfield;
    [SerializeField] Button btnCompleteMemoInput;
    [SerializeField] Slider sldGrowth;
    [SerializeField] Text txtGrowth;
    [SerializeField] Slider sldNutrition;
    [SerializeField] Text txtNutrition;
    [SerializeField] Slider sldHumidity;
    [SerializeField] Text txtHumidity;
    [SerializeField] Image imgSick;
    [SerializeField] Image imgThirsty;

    [Header("Test")]
    [SerializeField] Button btnSamplePlant;

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
