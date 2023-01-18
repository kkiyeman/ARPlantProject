using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UIPlant : MonoBehaviour
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
    [SerializeField] Image weather;
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
    [SerializeField] Slider sldNutrition;
    [SerializeField] Slider sldHumidity;
    [SerializeField] Image imgSick;
    [SerializeField] Image imgThirsty;

    [Header("Test")]
    [SerializeField] Button btnSamplePlant;


    void Start()
    {
        ButtonSetting();
    }

    void Update()
    {
        TextSetting();
        SliderSetting();
    }

    private void TextSetting()
    {
        txtCurtime.text = DateTime.Now.ToString();
        curEnergy = 50;
        totalEnergy = 100;
        Gold = 1000;
        txtEnergy.text = $"{curEnergy}/{totalEnergy}";
        txtGold.text = $"{Gold}";
    }

    private void SliderSetting()
    {
        sldEnergy.maxValue = totalEnergy;
        sldEnergy.value = curEnergy;
        sldGrowth.maxValue = 100;
        sldGrowth.value = 50;
        sldNutrition.maxValue = 100;
        sldNutrition.value = 55;
        sldHumidity.maxValue = 100;
        sldHumidity.value = 45;

    }
    private void ButtonSetting()
    {
        btnSamplePlant.onClick.AddListener(OnClickStatusOn);
        btnCloseStatus.onClick.AddListener(OnClickStatusOff);
        btnMemo.onClick.AddListener(OnClickMemoOn);
        btnCloseMemo.onClick.AddListener(OnClickMemoOff);
        btnPlantName.onClick.AddListener(OnClickInputPlantNameOn);
        btnClosePlantInputfield.onClick.AddListener(OnClickInputPlantNameOff);
        btnCompleteMemoInput.onClick.AddListener(OnClickMemoChange);
        btnOnInputfield.onClick.AddListener(OnClickInputMemoOn);
    }

    private void OnClickStatusOn()
    {
        imgStatus.gameObject.SetActive(true);
    }

    private void OnClickStatusOff()
    {
        imgStatus.gameObject.SetActive(false);
    }

    private void OnClickMemoOn()
    {
        imgMemo.gameObject.SetActive(true);
    }

    private void OnClickMemoOff()
    {
        imgMemo.gameObject.SetActive(false);
    }

    private void OnClickInputPlantNameOn()
    {
        inputPlantName.gameObject.SetActive(true);
    }

    private void OnClickInputPlantNameOff()
    { 
        txtPlantName.text = inputPlantName.textComponent.text;
        inputPlantName.gameObject.SetActive(false);
    }

    private void OnClickMemoChange()
    {
        txtMemo.text = inputMemo.textComponent.text;
        inputMemo.gameObject.SetActive(false);
    }

    private void OnClickInputMemoOn()
    {
        inputMemo.gameObject.SetActive(true);
    }
}
