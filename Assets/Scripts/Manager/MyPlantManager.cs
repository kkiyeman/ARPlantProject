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

    public bool isWaterThePlantOnClick;       //���ֱ� ��ư Ŭ�� ����
    public bool isEnergySupplyPlantOnClick;   //������ ��ư Ŭ�� ����
    public bool isPraisePlantOnClick;         //Ī�� ��ư Ŭ�� ����
    public bool isHarvestPlantOnClick;        //��Ȯ�ϱ� ��ư Ŭ�� ����

    public bool btnPraiseClickAble = true;    //Ī�� ��ư Ŭ�� ���ɿ��� (�Ϸ翡 �� ����)

    public bool allBtnUnclickAble;       //���ֱ�, ������, ��Ȯ, Ī�� ��ư Ŭ�� ���� ����(������ 0�� �� Ŭ�� �Ұ�)

    public int GrowPlantReward;               //�Ĺ� ��Ȯ�� ��� ����

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

    public IEnumerator GrowthRatePlant()            //�Ĺ� ���� �Լ�
    {
        while(true)
        {
            yield return waitFor10Seconds_GrowthRatePlant;              //�Ĺ� ���� �ð�(�ϴ��� 10�ʷ�) ���� �Ϸ��� 10,800�ʷ� ����

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

    public IEnumerator MinusPlantStatus() //�� �ð� ���з�, ���絵 ���� �Լ�(�ð��� 10 ����)
    {
        while (true)
        {
            yield return waitFor10Seconds_PlantStatus;       //���з�, ���絵 ���� �ð�(�ϴ��� 10�ʷ�) ���� �Ϸ��� 3600�ʷ� ����

            for (int i = 0; i < myPlantList.Count; i++)
            {
                myPlantList[i].hydration -= 10;
                myPlantList[i].nutrition -= 10;
            }
        }
    }

    public IEnumerator PlantDisease() //�Ĺ� ��Ȳ�� �����̻� �Լ�(���е� 120�ʰ� 150�̸�, ���絵 100�ʰ�, 20�̸�)
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
                        Debug.Log(myPlantList[i].plantUserName + "������~");

                        uiNotice = uimanager.GetUI("UINotice").GetComponent<UINotice>();
                        uiNotice.DiseaseNotice(myPlantList[i].plantUserName);
                        //var plantSick = Instantiate(sick, potTrans);
                    }
                }
            }
        }
    }

    public void WaterThePlant(int idx)             //���ֱ� �Լ� (���ֱ� ��ư Ŭ�� �� ���з� 20 ���) , ������ 5�Ҹ�
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

    public void NutritionSupplyPlant(int idx)             //����� ���� �Լ�(������ ��ư Ŭ�� �� ���絵 ����) , ������ 10�Ҹ�
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

    public void PraisePlant(int idx)   //�Ĺ� Ī���ϱ� �Լ� , ������ 20�Ҹ�     �Ϸ翡 �� ���� ����
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
                    Debug.Log("�Ϸ� �� ���� ����");
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

    public void HarvestPlant(int idx)      //�Ĺ� ��Ȯ�� ��� ��ȭ �� �Һ� ������(������ ��Ȯ ���� �� �Ϻκи� ����)
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

    public IEnumerator DieThePlant() //�Ĺ� �״� �Լ�(���е� 150�̻�, 30�̸�, ���絵 0����)
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

                        Debug.Log(myPlantList[i].plantUserName + "�׾���");

                        uiNotice = uimanager.GetUI("UINotice").GetComponent<UINotice>();
                        uiNotice.DieNotice(myPlantList[i].plantUserName);

                        PlantManager.GetInstance().DeadOn(i);
                    }
                }
            }
        }
    }



}
