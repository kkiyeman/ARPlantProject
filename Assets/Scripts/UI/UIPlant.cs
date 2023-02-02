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
    public Image imgsWhatPlant;
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

    [SerializeField] GameObject bg;
    [SerializeField] Button Test1;
    [SerializeField] Button Test2;
    [SerializeField] Button Test3;
    [SerializeField] Button Test4;
    [SerializeField] Button Test5;
    [SerializeField] string[] arrPlants;

    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;
    MyPlantManager myplantmanager;

    UINotice uiNotice;
    void Start()
    {
        AudioManager.GetInstance().PlayBgm("Plant1");
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();
        myplantmanager = MyPlantManager.GetInstance();

        

        SetButton();

    }

    void Update()
    {
        SetPlayerData();
        if(myplantmanager.myPlantList.Count>0)
            SetStatus();
    }

    public void SetStatus()
    {
        int potIdx = plantmanager.potIdx;
        MyPlantList myplant = myplantmanager.myPlantList[potIdx];
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
        
        txtCurtime.text = DateTime.Now.ToString("M"+"�� "+"dd"+"��" + "\n" + "HH" + "�� " + "mm" + "��");
        curEnergy = gamemanager.curEnergy;
        totalEnergy = gamemanager.totalEnergy;
        Gold = gamemanager.curGameMoney;
        txtEnergy.text = $"{curEnergy}/{totalEnergy}";
        txtGold.text = $"{Gold}";
        sldEnergy.maxValue = totalEnergy;
        sldEnergy.value = curEnergy;

    }

    private void SetButton()
    {
        //btnSamplePlant.onClick.AddListener(OnClickBottomOn);
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
        btnSeed.onClick.AddListener(OnClickOpenChooseSeed);
        btnCloseChooseSeed.onClick.AddListener(OnClickCloseChooseSeed);
        btnCropSeed.onClick.AddListener(OnClickCropSpawn);
        btnOrnamentalSeed.onClick.AddListener(OnClickOrnSpawn);
        btnStatus.onClick.AddListener(OnClickStatusOn);
        btnCloseBottom.onClick.AddListener(OnClickBottomOff);
        btnWater.onClick.AddListener(OnClickWaterThePlant);
        btnPill.onClick.AddListener(OnClickNutritionSupplyPlant);
        btnComment.onClick.AddListener(OnClickPraisePlant);
        Test1.onClick.AddListener(() => { plantmanager.SproutOn(plantmanager.potIdx); });
        Test2.onClick.AddListener(() => { plantmanager.MiddleOn(plantmanager.potIdx); });
        Test3.onClick.AddListener(() => { plantmanager.GrownUpOn(plantmanager.potIdx); });
        Test4.onClick.AddListener(() => { plantmanager.DeadOn(plantmanager.potIdx); });
        Test5.onClick.AddListener(() => { plantmanager.removeplant(plantmanager.potIdx); });
    }

    private void OnClickStatusOn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        imgStatus.gameObject.SetActive(true);
    }

    private void OnClickStatusOff()
    {
        AudioManager.GetInstance().PlaySfx("��");
        imgStatus.gameObject.SetActive(false);
    }

    private void OnClickMemoOn()
    {
        AudioManager.GetInstance().PlaySfx("�޸�");
        imgMemo.gameObject.SetActive(true);
    }

    private void OnClickMemoOff()
    {
        AudioManager.GetInstance().PlaySfx("�޸�");
        imgMemo.gameObject.SetActive(false);
    }

    private void OnClickInputPlantNameOn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        inputPlantName.gameObject.SetActive(true);
    }

    private void OnClickInputPlantNameOff()
    {
        AudioManager.GetInstance().PlaySfx("��");
        txtPlantName.text = inputPlantName.textComponent.text;
        inputPlantName.gameObject.SetActive(false);
    }

    private void OnClickMemoChange()
    {
        AudioManager.GetInstance().PlaySfx("��");
        txtMemo.text = inputMemo.textComponent.text;
        inputMemo.gameObject.SetActive(false);
    }

    private void OnClickInputMemoOn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        inputMemo.gameObject.SetActive(true);
    }

    private void OnClickUIStoreOn()
    {
        AudioManager.GetInstance().PlaySfx("Money");
        var uistore = uimanager.GetUI("UIStore");
        uistore.gameObject.SetActive(true);
    }
    private void OnClickUIDictionaryOn()
    {
        AudioManager.GetInstance().PlaySfx("Dictionary");
        var UIDictionary = uimanager.GetUI("UIDictionary");
        UIDictionary.gameObject.SetActive(true);
    }
    private void OnClickUIOptionOn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        var UIOption = uimanager.GetUI("UIOption");
        UIOption.gameObject.SetActive(true);
    }
    private void OnClickUIInventoryOn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        var UIInventory = uimanager.GetUI("UIInventory").GetComponent<UIInventory>();
        UIInventory.gameObject.SetActive(true);
        UIInventory.ShowItemList(0);
    }

    public void OnClickOpenChooseSeed()
    {
        AudioManager.GetInstance().PlaySfx("��");
        if (plantmanager.croCount == 1 && plantmanager.ornCount == 1)
        {
            Debug.Log("�� �̻� ��ȯ �Ұ�");
        }
        else
        {
            plantmanager.onClickPlantBtn = true;
            bgChooseSeed.gameObject.SetActive(true);
        }
    }

    public void OnClickCropSpawn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        plantmanager.onClickCroBtn = true;
        bgChooseSeed.gameObject.SetActive(false);
    }

    public void OnClickOrnSpawn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        plantmanager.onClickOrnBtn = true;
        bgChooseSeed.gameObject.SetActive(false);
    }

    public void OnClickCloseChooseSeed()
    {
        AudioManager.GetInstance().PlaySfx("��");
        plantmanager.onClickPlantBtn = false;
        plantmanager.onClickCroBtn = false;
        plantmanager.onClickOrnBtn = false;
        bgChooseSeed.gameObject.SetActive(false);
    }

    public void OnClickBottomOn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        bottomButtons.SetActive(true);
    }

    private void OnClickBottomOff()
    {
        AudioManager.GetInstance().PlaySfx("��");
        bottomButtons.SetActive(false);
    }

    private void OnClickRightLayOutPop()
    {
        if (!isPoped)
            StartCoroutine("PopUp");
        else
            StartCoroutine("PopDown");
    }

    private void OnClickWaterThePlant()
    {
        AudioManager.GetInstance().PlaySfx("���Ѹ���");
        myplantmanager.isWaterThePlantOnClick = true;
        myplantmanager.WaterThePlant(plantmanager.potIdx);
    }

    private void OnClickNutritionSupplyPlant()
    {
        AudioManager.GetInstance().PlaySfx("������");
        myplantmanager.isEnergySupplyPlantOnClick = true;
        myplantmanager.NutritionSupplyPlant(plantmanager.potIdx);
    }

    private void OnClickPraisePlant()
    {
        AudioManager.GetInstance().PlaySfx("Growth1");
        myplantmanager.isPraisePlantOnClick = true;
        myplantmanager.PraisePlant(plantmanager.potIdx);
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
