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

    public int myPlantIdx;

    public WaitForSecondsRealtime waitFor30Seconds = new WaitForSecondsRealtime(30);
    public WaitForSecondsRealtime waitFor10Seconds = new WaitForSecondsRealtime(10);
    public WaitForSecondsRealtime waitForHalfSeconds = new WaitForSecondsRealtime(0.5f);

    public bool isWaterThePlantOnClick;       //물주기 버튼 클릭 여부
    public bool isEnergySupplyPlantOnClick;   //영양제 버튼 클릭 여부
    public bool isPraisePlantOnClick;         //칭찬 버튼 클릭 여부
    public bool isHarvestPlantOnClick;        //수확하기 버튼 클릭 여부

    public bool btnPraiseClickAble = true;    //칭찬 버튼 클릭 가능여부 (하루에 한 번만)

    public bool allBtnUnclickAble;       //물주기, 영양제, 수확, 칭찬 버튼 클릭 가능 여부(에너지 0일 시 클릭 불가)

    public int GrowPlantReward;               //식물 수확시 얻는 보상

    public List<MyPlantList> myPlantList = new List<MyPlantList>();

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public void CheckMyPlantsIdx()
    {
        for(int i = 0; i < myPlantList.Count; i++)
        {
                i = myPlantIdx;
        }
    }

    public IEnumerator GrowthRatePlant(int idx)            //식물 성장 함수
    {
        while(true)
        {
            yield return waitFor10Seconds;                 //식물 성장 시간(일단은 10초로) 개발 완료후 10,800초로 변경
            myPlantList[idx].growthRate++;
        }
    }

    public IEnumerator MinusPlantStatus(int idx) //매 시간 수분량, 영양도 감소 함수(시간당 10 감소)
    {
        while (true)
        {
            yield return waitFor10Seconds;       //수분량, 영양도 감소 시간(일단은 10초로) 개발 완료후 3600초로 변경

            myPlantList[idx].hydration -= 10;
            myPlantList[idx].nutrition -= 10;
        }
    }

    public IEnumerator PlantDisease(int idx) //식물 상황별 상태이상 함수(수분도 120초과 150미만, 영양도 100이상, 20미만)
    {
        while (true)
        {
            yield return waitForHalfSeconds;

            if (120 < myPlantList[idx].hydration && myPlantList[idx].hydration < 150 || myPlantList[idx].nutrition >= 100 || myPlantList[idx].nutrition < 20)
            {
                myPlantList[idx].isSick = true;
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
                        myPlantList[idx].growthRate += 2;
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

                    if (curGrowthRate != 100)
                    {
                        if (GameManager.GetInstance().curEnergy >= 15)
                        {
                            GameManager.GetInstance().curEnergy -= 15;
                            GrowPlantReward = reward * (curGrowthRate / 100);
                            myPlantList.RemoveAt(idx);
                            Destroy(gameObject);
                        }
                        else
                            return;
                    }
                    else if (curGrowthRate == 100)
                    {
                        GrowPlantReward = reward;
                        GameManager.GetInstance().curEnergy -= 5;
                        myPlantList.RemoveAt(idx);
                        Destroy(gameObject);
                    }
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

    public IEnumerator DieThePlant(int idx) //식물 죽는 함수(수분도 150이상, 30미만, 영양도 0이하)
    {
        while (true)
        {
            yield return waitForHalfSeconds;

            if (myPlantList[idx].hydration >= 150 || myPlantList[idx].hydration < 30 || myPlantList[idx].nutrition <= 0)
            {
                myPlantList.RemoveAt(idx);
                Destroy(gameObject);
            }
        }
    }



}
