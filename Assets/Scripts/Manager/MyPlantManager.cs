using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlantManager : MonoBehaviour
{
    #region SingletoneMake
    public static MyPlantManager instance = null;
    public static MyPlantManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@MyPlantManager");
            instance = go.AddComponent<MyPlantManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion

    UIManager uimanager;
    UINotice uiNotice;
    Shelf shelf;

    public int myPlantIdx;

    public WaitForSecondsRealtime waitFor30Seconds = new WaitForSecondsRealtime(30);
    public WaitForSecondsRealtime waitFor10Seconds_GrowthRatePlant = new WaitForSecondsRealtime(10);
    public WaitForSecondsRealtime waitFor10Seconds_PlantStatus = new WaitForSecondsRealtime(10);
    public WaitForSecondsRealtime waitForHalfSeconds_PlantDisease = new WaitForSecondsRealtime(0.5f);
    public WaitForSecondsRealtime waitForHalfSeconds_DieThePlant = new WaitForSecondsRealtime(0.5f);

    public bool isWaterThePlantOnClick;       //물주기 버튼 클릭 여부
    public bool isEnergySupplyPlantOnClick;   //영양제 버튼 클릭 여부
    public bool isPraisePlantOnClick;         //칭찬 버튼 클릭 여부
    public bool isHarvestPlantOnClick;        //수확하기 버튼 클릭 여부

    public bool btnPraiseClickAble = true;    //칭찬 버튼 클릭 가능여부 (하루에 한 번만)

    public bool allBtnUnclickAble;       //물주기, 영양제, 수확, 칭찬 버튼 클릭 가능 여부(에너지 0일 시 클릭 불가)

    public int GrowPlantReward;               //식물 수확시 얻는 보상

    public List<MyPlantList> myPlantList = new List<MyPlantList>();

    private void Awake()
    {
        uimanager = UIManager.GetInstance();
    }
    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public void PlamtManagement()
    {
        StartCoroutine(GrowthRatePlant());
        StartCoroutine(MinusPlantStatus());
        StartCoroutine(PlantDisease());
        StartCoroutine(DieThePlant());
    }

    public IEnumerator GrowthRatePlant()            //식물 성장 함수
    {
        while(true)
        {
            yield return waitFor10Seconds_GrowthRatePlant;              //식물 성장 시간(일단은 10초로) 개발 완료후 10,800초로 변경

            for (int i = 0; i < myPlantList.Count; i++)
            {
                myPlantList[i].growthRate += 15;

                if (myPlantList[i].growthRate < 30 && myPlantList[i].growthRate >= 15)
                    PlantManager.GetInstance().SproutOn(i);

                if(myPlantList[i].growthRate < 45 && myPlantList[i].growthRate >= 30)
                    PlantManager.GetInstance().MiddleOn(i);

                if (myPlantList[i].growthRate < 60 && myPlantList[i].growthRate >= 45)
                    PlantManager.GetInstance().GrownUpOn(i);
            }
        }
    }

    public IEnumerator MinusPlantStatus() //매 시간 수분량, 영양도 감소 함수(시간당 10 감소)
    {
        while (true)
        {
            yield return waitFor10Seconds_PlantStatus;       //수분량, 영양도 감소 시간(일단은 10초로) 개발 완료후 3600초로 변경

            for (int i = 0; i < myPlantList.Count; i++)
            {
                myPlantList[i].hydration -= 10;
                myPlantList[i].nutrition -= 10;
            }
        }
    }

    public IEnumerator PlantDisease() //식물 상황별 상태이상 함수(수분도 120초과 150미만, 영양도 100초과, 20미만)
    {
        //shelf = GetComponent<Shelf>();
        //var sick = Resources.Load<GameObject>($"plant/Icon_FeelBad22");

        //bool isOrn = shelf.type == ShelfType.orn;
        //var potTrans = isOrn ? shelf.ornPots[PlantManager.GetInstance().potIdx].transform : shelf.corPot.transform;
        while (true)
        {
            yield return waitForHalfSeconds_PlantDisease;

            for(int i = 0; i < myPlantList.Count; i++)
            {
                if (120 < myPlantList[i].hydration && myPlantList[i].hydration <= 50 || myPlantList[i].nutrition > 100 || myPlantList[i].nutrition <= 50)
                {
                    if (!myPlantList[i].isSick)
                    {
                        myPlantList[i].isSick = true;
                        Debug.Log(myPlantList[i].plantUserName + "아프다~");

                        uiNotice = uimanager.GetUI("UINotice").GetComponent<UINotice>();
                        uiNotice.DiseaseNotice(myPlantList[i].plantUserName);
                        //var plantSick = Instantiate(sick, potTrans);
                    }
                }
            }
        }
    }

    public void WaterThePlant(int idx)             //물주기 함수 (물주기 버튼 클릭 시 수분량 20 상승) , 에너지 5소모
    {
        if (!allBtnUnclickAble)
        {
            if (isWaterThePlantOnClick)
            {
                if (GameManager.GetInstance().curEnergy >= 5)
                {
                    myPlantList[idx].hydration += 20;
                    GameManager.GetInstance().curEnergy -= 5;
                    isWaterThePlantOnClick = false;
                }
                else
                    return;
            }
            else
                return;
        }
        else
            return;
    }

    public void NutritionSupplyPlant(int idx)             //영양분 공급 함수(영양제 버튼 클릭 시 영양도 증가) , 에너지 10소모
    {
        if (!allBtnUnclickAble)
        {
            if (isEnergySupplyPlantOnClick)
            {
                if (GameManager.GetInstance().curEnergy >= 10)
                {
                    myPlantList[idx].nutrition += 30;
                    GameManager.GetInstance().curEnergy -= 10;
                    isEnergySupplyPlantOnClick = false;
                }
                else
                    return;
            }
            else
                return;
        }
        else
            return;
    }

    public void PraisePlant(int idx)   //식물 칭찬하기 함수 , 에너지 20소모     하루에 한 번만 가능
    {
        if (!allBtnUnclickAble)
        {
            if (isPraisePlantOnClick)
            {
                if (btnPraiseClickAble)
                {
                    if (GameManager.GetInstance().curEnergy >= 20)
                    {
                        myPlantList[idx].growthRate += 20;
                        GameManager.GetInstance().curEnergy -= 20;
                        btnPraiseClickAble = false;
                    }
                    else
                        return;
                }
                else
                    Debug.Log("하루 한 번만 가능");
            }
            else
                return;
        }
        else
            return;

        int curTime = GameManager.GetInstance().runningTime;
        if (curTime % 86400 == 0)
        {
            btnPraiseClickAble = true;
        }
    }

    public void HarvestPlant(int idx)      //식물 수확시 얻는 재화 및 소비 에너지(끝까지 수확 못할 시 일부분만 보상)
    {
        int curGrowthRate = myPlantList[idx].growthRate;
        int reward = myPlantList[idx].reward;

        if (!allBtnUnclickAble)
        {
            if (isHarvestPlantOnClick)
            {
                if (GameManager.GetInstance().curEnergy >= 5)
                {

                    if (curGrowthRate != 100 && curGrowthRate != 0)
                    {
                        if (GameManager.GetInstance().curEnergy >= 15)
                        {
                            GameManager.GetInstance().curEnergy -= 15;
                            GrowPlantReward = (int)reward /curGrowthRate;
                        }
                        else
                            return;
                    }
                    else if (curGrowthRate == 100)
                    {
                        GrowPlantReward = reward;
                        GameManager.GetInstance().curEnergy -= 5;
                    }

                    PlantManager.GetInstance().HarvestOn(idx, reward);
                    PlantManager.GetInstance().removeplant(idx);
                }
                else
                    return;
            }
            else
                return;
        }
        else
            return;
    }

    public IEnumerator DieThePlant() //식물 죽는 함수(수분도 150이상, 30미만, 영양도 0이하)
    {
        while (true)
        {
            yield return waitForHalfSeconds_DieThePlant;

            for(int i = 0; i < myPlantList.Count; i++)
            {
                if (myPlantList[i].hydration >= 150 || myPlantList[i].nutrition >= 150 || myPlantList[i].hydration <= 30 || myPlantList[i].nutrition <= 30)
                {
                    if (!myPlantList[i].isDie)
                    {
                        myPlantList[i].isDie = true;

                        Debug.Log(myPlantList[i].plantUserName + "죽었다");

                        uiNotice = uimanager.GetUI("UINotice").GetComponent<UINotice>();
                        uiNotice.DieNotice(myPlantList[i].plantUserName);

                        PlantManager.GetInstance().DeadOn(i);
                    }
                }
            }
        }
    }



}
