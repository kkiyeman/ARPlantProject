using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;


public class UIPlant : MonoBehaviour
{
    [Header("Right Side")]
    [SerializeField] GameObject rightSideObjects;
    [SerializeField] Button btnRightLayOutPop;
    [SerializeField] Button btnSeed;
    [SerializeField] Button btnStore;
    [SerializeField] Button btnDictionary;
    [SerializeField] Button btnInventory;
    [SerializeField] Text txtArrow;
    public bool isPoped;

    [Header("Bottom Side")]
    [SerializeField] GameObject bottomButtons;
    [SerializeField] Button btnWater;
    [SerializeField] Button btnPill;
    [SerializeField] Button btnComment;
    [SerializeField] Button btnStatus;
    [SerializeField] Button btnCloseBottom;
    [SerializeField] Text txtBottomPlantName;

    [Header("Upper Side")]
    [SerializeField] Image weather;
    [SerializeField] Text txtCurtime;
    [SerializeField] Text txtEnergy;
    [SerializeField] Text txtGold;
    [HideInInspector] public float totalEnergy = 100;
    [HideInInspector] public float curEnergy = 50;
    [HideInInspector] public int Gold = 1000;
    [SerializeField] Slider sldEnergy;
    [SerializeField] Button btnOption;

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

    [Header("ChooseSeed")]
    [SerializeField] Image bgChooseSeed;
    [SerializeField] Button btnCloseChooseSeed;
    [SerializeField] Button btnOrnamentalSeed;
    [SerializeField] Button btnCropSeed;

    [Header("Test")]
    [SerializeField] Button btnSamplePlant;

    [SerializeField] GameObject bg;
    [SerializeField] string[] arrPlants;

    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;

    void Start()
    {
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();
        SetButton();
    }

    void Update()
    {
        SetPlayerData();
        SetStatus();
    }

    private void SetStatus()
    {
        MyPlantList myplant = MyPlantManager.GetInstance().myPlantList[0];
        string _plantuserName = myplant.plantUserName;
        string _plantName = myplant.plantName;
        int _plantgrowth = myplant.growthRate;
        int _plantNut = myplant.nutrition;
        int _plantwater = myplant.hydration;
        sldGrowth.maxValue = 100;
        sldNutrition.maxValue = 100;
        sldHumidity.maxValue = 100;
        sldGrowth.value = _plantgrowth;
        sldNutrition.value = _plantNut;
        sldHumidity.value = _plantwater;
        txtGrowth.text = $"{_plantgrowth}/100";
        txtNutrition.text = $"{_plantNut}/100";
        txtHumidity.text = $"{_plantwater}/100";
        txtPlantName.text = _plantuserName;

    }

    private void SetPlayerData()
    {
        
        txtCurtime.text = DateTime.Now.ToString("M"+"월 "+"dd"+"일" + "\n" + "HH" + "시 " + "mm" + "분");
        curEnergy = 50;
        totalEnergy = 100;
        Gold = 1000;
        txtEnergy.text = $"{curEnergy}/{totalEnergy}";
        txtGold.text = $"{Gold}";
        sldEnergy.maxValue = totalEnergy;
        sldEnergy.value = curEnergy;

    }

    private void SetButton()
    {
        btnSamplePlant.onClick.AddListener(OnClickBottomOn);
        btnCloseStatus.onClick.AddListener(OnClickStatusOff);
        btnMemo.onClick.AddListener(OnClickMemoOn);
        btnCloseMemo.onClick.AddListener(OnClickMemoOff);
        btnPlantName.onClick.AddListener(OnClickInputPlantNameOn);
        btnClosePlantInputfield.onClick.AddListener(OnClickInputPlantNameOff);
        btnCompleteMemoInput.onClick.AddListener(OnClickMemoChange);
        btnOnInputfield.onClick.AddListener(OnClickInputMemoOn);
        btnStore.onClick.AddListener(OnClickUIStoreOn);
        btnDictionary.onClick.AddListener(OnClickUIDictionaryOn);
        btnOption.onClick.AddListener(OnClickUIOptionOn);
        btnInventory.onClick.AddListener(OnClickUIInventoryOn);
        btnRightLayOutPop.onClick.AddListener(OnClickRightLayOutPop);
        btnSeed.onClick.AddListener(OnClickOpenChooseSeed);
        btnCloseChooseSeed.onClick.AddListener(OnClickCloseChooseSeed);
        btnCropSeed.onClick.AddListener(OnClickCropSpawn);
        btnOrnamentalSeed.onClick.AddListener(OnClickOrnSpawn);
        btnStatus.onClick.AddListener(OnClickStatusOn);
        btnCloseBottom.onClick.AddListener(OnClickBottomOff);
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

    private void OnClickUIStoreOn()
    {
        var uistore = uimanager.GetUI("UIStore");
        uistore.gameObject.SetActive(true);
    }
    private void OnClickUIDictionaryOn()
    {
        var UIDictionary = uimanager.GetUI("UIDictionary");
        UIDictionary.gameObject.SetActive(true);
    }
    private void OnClickUIOptionOn()
    {
        var UIOption = uimanager.GetUI("UIOption");
        UIOption.gameObject.SetActive(true);
    }
    private void OnClickUIInventoryOn()
    {
        var UIInventory = uimanager.GetUI("UIInventory");
        UIInventory.gameObject.SetActive(true);
    }

    public void OnClickOpenChooseSeed()
    {

        if(plantmanager.CroCount == 1 && plantmanager.OrnCount == 1)
        {
            Debug.Log("더 이상 소환 불가");
        }
        else
        {
            plantmanager.onClickPlantBtn = true;
            bgChooseSeed.gameObject.SetActive(true);
        }
    }

    public void OnClickCropSpawn()
    {
        plantmanager.onClickCroBtn = true;
        bgChooseSeed.gameObject.SetActive(false);
    }

    public void OnClickOrnSpawn()
    {
        plantmanager.onClickOrnBtn = true;
        bgChooseSeed.gameObject.SetActive(false);
    }

    public void OnClickCloseChooseSeed()
    {
        plantmanager.onClickPlantBtn = false;
        plantmanager.onClickCroBtn = false;
        plantmanager.onClickOrnBtn = false;
        bgChooseSeed.gameObject.SetActive(false);
    }

    private void OnClickBottomOn()
    {
        bottomButtons.SetActive(true);
    }

    private void OnClickBottomOff()
    {
        bottomButtons.SetActive(false);
    }

    private void OnClickRightLayOutPop()
    {
        if (!isPoped)
            StartCoroutine("PopUp");
        else
            StartCoroutine("PopDown");
    }

    private IEnumerator PopUp()
    {
        txtArrow.text = ">";
        for (float i = 1220; i >= 1080; i = i -2f)
        {
            rightSideObjects.transform.position = new Vector3(i, rightSideObjects.transform.position.y, rightSideObjects.transform.position.z);
              yield return Time.deltaTime / 200f;
        }
        yield return new WaitForSeconds(0.01f);
        isPoped = true;
    }

    private IEnumerator PopDown()
    {
        txtArrow.text = "<";
        Vector3 vector = rightSideObjects.transform.position;
        for (float j = 1080; j <= 1220; j = j + 2f)
        {
            rightSideObjects.transform.position = new Vector3(j, vector.y, vector.z);
             yield return Time.deltaTime / 200f;
        }
        yield return new WaitForSeconds(0.01f);
        isPoped = false;
    }
}
