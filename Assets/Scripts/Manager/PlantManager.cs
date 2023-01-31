using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class PlantManager : MonoBehaviour
{
    #region SingletoneMake
    public static PlantManager instance = null;
    public static PlantManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@PlantManager");
            instance = go.AddComponent<PlantManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion

    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    UIManager uimanager;

    [SerializeField]
    GameObject spawnablePrefab;
    GameObject spawnedObject;

    public bool isWaterThePlantOnClick;       //���ֱ� ��ư Ŭ�� ����
    public bool isEnergySupplyPlantOnClick;   //������ ��ư Ŭ�� ����
    public bool isPraisePlantOnClick;         //Ī�� ��ư Ŭ�� ����
    public bool isHarvestPlantOnClick;        //��Ȯ�ϱ� ��ư Ŭ�� ����

    public bool btnPraiseClickAble = true;    //Ī�� ��ư Ŭ�� ���ɿ��� (�Ϸ翡 �� ����)

    public bool allBtnUnclickAble;       //���ֱ�, ������, ��Ȯ, Ī�� ��ư Ŭ�� ���� ����(������ 0�� �� Ŭ�� �Ұ�)

    public int GrowPlantReward;               //�Ĺ� ��Ȯ�� ��� ����

    [HideInInspector] public float curTime;   //���� �ð� ����

    public WaitForSecondsRealtime waitFor30Seconds = new WaitForSecondsRealtime(30);
    public WaitForSecondsRealtime waitFor10Seconds = new WaitForSecondsRealtime(10);
    public WaitForSecondsRealtime waitForHalfSeconds = new WaitForSecondsRealtime(0.5f);

    public bool onClickOrnBtn;                //����Ĺ� �ɱ� ��ư Ŭ��
    public bool onClickCroBtn;                //���۹� �ɱ� ��ư Ŭ��
    public bool onClickPlantBtn;              //�ɱ� ��ư Ŭ��

    public string plantsName;

    public int OrnCount = 0;
    public int CroCount = 0;

    MyPlantManager myPlantManager;

    [SerializeField] private Camera arCamera;
    public bool objTouched;

    public int clickIdx;

    public int potIdx;
    [HideInInspector] public Transform potTrans;

    //string path;
    //string filename = "save";

    public PlantBase[] plantDates = new PlantBase[]
{
        new FishBone("FishBone", "FishBone", "Ornamental", 0, 100, 100, false, false),
        new Pileapepe("Pileapepe", "Pileapepe", "Ornamental", 0, 100, 100, false, false),
        new Jade("Jade", "Jade", "Ornamental", 0, 100, 100, false, false),
        new Palm("Palm", "Palm", "Ornamental", 0, 100, 100, false, false),
        new Carrot("Carrot", "Carrot", "Crops", 0, 100, 100, false, false),
        new CherryTomato("CherryTomato", "CherryTomato", "Crops", 0, 100, 100, false, false),
};

    public List<PlantBase> MyPlants = new List<PlantBase>();

    private void Awake()
    {
        //path = Application.persistentDataPath + "/";
        instance = this;
        DontDestroyOnLoad(gameObject);

        uimanager = UIManager.GetInstance();
    }

    void Start()
    {
        myPlantManager = MyPlantManager.GetInstance();
        var myPlantList = myPlantManager.myPlantList;
        spawnedObject = null;
        //DataManager.GetInstance().LoadData();

        //StartCoroutine(MinusPlantStatus(myPlantList[myPlantManager.myPlantIdx].hydration, myPlantList[myPlantManager.myPlantIdx].nutrition));
        //StartCoroutine(DieThePlant(myPlantList[myPlantManager.myPlantIdx].hydration, myPlantList[myPlantManager.myPlantIdx].nutrition));
        //StartCoroutine(PlantDisease(myPlantList[myPlantManager.myPlantIdx].hydration, myPlantList[myPlantManager.myPlantIdx].nutrition));
        //StartCoroutine(GrowthRatePlant(myPlantList[myPlantManager.myPlantIdx].growthRate));
    }


    void Update()
    {
        curTime = GameManager.GetInstance().runningTime;
        allBtnUnclickAble = GameManager.GetInstance().isEnegyZero;
        //PlantSpawn();
        SpawnSeed();
       // Save();
    }

    public void WaterThePlant(int curhydration, int curEnergy)             //���ֱ� �Լ� (���ֱ� ��ư Ŭ�� �� ���з� 20 ���) , ������ 5�Ҹ�
    {
        if (!allBtnUnclickAble)
        {
            if (isWaterThePlantOnClick)
            {
                if (curEnergy >= 5)
                {
                    curhydration += 20;
                    curEnergy -= 5;
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

    public void NutritionSupplyPlant(int nutrition, int curEnergy)             //����� ���� �Լ�(������ ��ư Ŭ�� �� ���絵 ����) , ������ 10�Ҹ�
    {
        if (!allBtnUnclickAble)
        {
            if (isEnergySupplyPlantOnClick)
            {
                if (curEnergy >= 10)
                {
                    nutrition += 30;
                    curEnergy -= 10;
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

/*    public void MinusPlantStatus(int curhydration, int nutrition)  //�� �ð� ���з�, ���絵 ���� �Լ�(�ð��� 10 ����)       Update
    {
        if (curTime % 10 == 0)          //���з�, ���絵 ���� �ð�(�ϴ��� 10�ʷ�) ���� �Ϸ��� 3600�ʷ� ����
        {
            curhydration -= 10;
            nutrition -= 10;
        }
        else
            return;
    }*/

    IEnumerator MinusPlantStatus(int curhydration, int nutrition) //�� �ð� ���з�, ���絵 ���� �Լ�(�ð��� 10 ����)
    {
        while (true)
        {
            yield return waitFor10Seconds;       //���з�, ���絵 ���� �ð�(�ϴ��� 10�ʷ�) ���� �Ϸ��� 3600�ʷ� ����

                curhydration -= 10;
                nutrition -= 10;
        }
    }


    IEnumerator DieThePlant(int curhydration, int nutrition) //�Ĺ� �״� �Լ�(���е� 150�̻�, 30�̸�, ���絵 0����)
    {
        var myPlantList = myPlantManager.myPlantList;
        int idx = myPlantManager.myPlantIdx;
        while (true)
        {
            yield return waitForHalfSeconds;      //���з�, ���絵 ���� �ð�

            if (curhydration >= 150 || curhydration < 30 || nutrition <= 0)
            {
                myPlantList.RemoveAt(idx);
                Destroy(gameObject);
            }
        }
    }
    /*public void DieThePlant(int curhydration, int nutrition, Object plantName) //�Ĺ� �״� �Լ�(���е� 150�̻�, 30�̸�, ���絵 0����)       Update
    {
        if (curhydration >= 150 || curhydration < 30 || nutrition <= 0)
        {
            Destroy(plantName);
        }
        else
            return;
    }*/

    IEnumerator PlantDisease(int curhydration, int nutrition) //�Ĺ� ��Ȳ�� �����̻� �Լ�(���е� 120�ʰ� 150�̸�, ���絵 100�̻�, 20�̸�)
    {
        var myPlantList = myPlantManager.myPlantList;
        int idx = myPlantManager.myPlantIdx;
        while (true)
        {
            yield return waitForHalfSeconds;

            if (120 < curhydration && curhydration < 150 || nutrition >= 100 || nutrition < 20)
            {
                myPlantList[idx].isSick = true;
            }
        }
    }
    /*public void PlantDisease(int curhydration, int nutrition) //�Ĺ� ��Ȳ�� �����̻� �Լ�(���е� 120�ʰ� 150�̸�, ���絵 100�̻�, 20�̸�)       Update
    {
        if (120 < curhydration && curhydration < 150 || nutrition >= 100 || nutrition < 20)
        {
            //�Ĺ� ���� �̻�
        }
        else
            return;
    }*/

    IEnumerator GrowthRatePlant(int curGrowthRate) //�Ĺ� ���� �Լ�
    {
        while (true)
        {
            yield return waitFor30Seconds;         //�Ĺ� ���� �ð�(�ϴ��� 30�ʷ�) ���� �Ϸ��� 10,800�ʷ� ����

                curGrowthRate += 1;

        }
    }
/*    public void GrowthRatePlant(int curGrowthRate)    //�Ĺ� ���� �Լ�       Update
    {
        if (curTime % 30 == 0)                 //�Ĺ� ���� �ð�(�ϴ��� 30�ʷ�) ���� �Ϸ��� 10,800�ʷ� ����
        {
            curGrowthRate += 1;
        }
        else
            return;
    }*/

    public void PraisePlant(int curGrowthRate, int curEnergy)   //�Ĺ� Ī���ϱ� �Լ� , ������ 20�Ҹ�     �Ϸ翡 �� ���� ����
    {
        if (!allBtnUnclickAble)
        {
            if (isPraisePlantOnClick)
            {
                if (btnPraiseClickAble)
                {
                    if (curEnergy >= 20)
                    {
                        curGrowthRate += 2;
                        curEnergy -= 20;
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

        if (curTime >= 86400)
        {
            btnPraiseClickAble = true;
            curTime = 0;
        }
    }

    public void HarvestPlant(int curEnergy, int curGrowthRate, int TotalGrowthRate, int Reward, Object plantName)      //�Ĺ� ��Ȯ�� ��� ��ȭ �� �Һ� ������(������ ��Ȯ ���� �� �Ϻκи� ����)
    {
        if (!allBtnUnclickAble)
        {
            if (isHarvestPlantOnClick)
            {
                if (curEnergy >= 5)
                {

                    if (curGrowthRate != TotalGrowthRate)
                    {
                        if (curEnergy >= 15)
                        {
                            curEnergy -= 15;
                            GrowPlantReward = Reward * (curGrowthRate / TotalGrowthRate);
                            Destroy(plantName);
                        }
                        else
                            return;
                    }
                    else if (curGrowthRate == TotalGrowthRate)
                    {
                        GrowPlantReward = Reward;
                        curEnergy -= 5;
                        Destroy(plantName);
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

/*    public void SpawnPrefab(Vector3 spawnPosition)
    {
        
        int ran = Random.Range(1, 3);
        var ob = Resources.Load<GameObject>($"plant/Pileapepe{ran}");
        var Plantdata = Instantiate(ob, spawnPosition, Quaternion.identity);
        Plantdata.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }*/

    public void SpawnPrefab(Vector3 spawnPosition)
    {
        int ranCrops = Random.Range(0, 2);
        if (onClickPlantBtn)
        {
            if (onClickCroBtn)
            {

                if (CroCount < 2)
                {
                    plantsName = "plant/cropot";
                    onClickCroBtn = false;

                    var ob = Resources.Load<GameObject>(plantsName);
                    var Plantdata = Instantiate(ob, spawnPosition, Quaternion.identity);
                    Plantdata.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

                    CroCount++;
                }
                else
                {
                    Debug.Log("2�� �̻� ��ȯ �Ұ�");
                    onClickCroBtn = false;
                }
            }
            else if (onClickOrnBtn)
            {
                if (OrnCount < 2)
                {
                    plantsName = "Shelf/Shelf_On_Pot";
                    onClickOrnBtn = false;

                    var ob = Resources.Load<GameObject>(plantsName);
                    var Plantdata = Instantiate(ob, spawnPosition, Quaternion.identity);
                    Plantdata.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

                    OrnCount++;
                }
                else
                {
                    Debug.Log("2�� �̻� ��ȯ �Ұ�");
                    onClickOrnBtn = false;
                }
            }
            onClickPlantBtn = false;

        }
    }

    public void EraseSpawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlantSpawn()
    {

        if (Input.touchCount == 0)
             return;
        else
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            else
            {
                if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        SpawnPrefab(m_Hits[0].pose.position);
                        SpawnSeed();
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
                    {
                        spawnedObject.transform.position = m_Hits[0].pose.position;
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        spawnedObject = null;
                    }
                }
                //ARRenderManager.GetInstance().PlaneOff();
            }
        }
    }

    /*    public void SpawnSeed()
        {
            Touch touch = Input.GetTouch(0);

            Ray ray;
            RaycastHit hitobj;

            ray = arCamera.ScreenPointToRay(touch.position);

            if (Input.touchCount == 0)
                return;

            else
            {
                if(Physics.Raycast(ray,out hitobj))
                {
                    if(hitobj.collider.tag == "Orn")
                    {
                        potTrans = hitobj.collider.gameObject.transform;
                        var SpawnOrn = uimanager.GetUI("UIOrnSpawn");
                        SpawnOrn.SetActive(true);
                    }
                    else if (hitobj.collider.tag == "Cro")
                    {
                        potTrans = hitobj.collider.gameObject.transform;
                        var SpawnCro = uimanager.GetUI("UICroSpawn");
                        SpawnCro.SetActive(true);
                    }
                }
            }
        }*/

        public void SpawnSeed()
        {
            if(Input.GetMouseButton(0))
            {
                RaycastHit hitobj;

                if (Physics.Raycast(arCamera.ScreenPointToRay(Input.mousePosition),out hitobj))
                {
                    if(hitobj.collider.tag == "Orn")
                    {
                        potTrans = hitobj.collider.gameObject.transform;
                        var SpawnOrn = uimanager.GetUI("UIOrnSpawn");
                        SpawnOrn.SetActive(true);
                    }
                    else if (hitobj.collider.tag == "Cro")
                    {
                        potTrans = hitobj.collider.gameObject.transform;
                        var SpawnCro = uimanager.GetUI("UICroSpawn");
                        SpawnCro.SetActive(true);
                    }
                }
            }
    }

    public void SetIdx(int idx)
    {
        clickIdx = idx;
    }
    

    public void SetPotIdx(int idx)
    {
        potIdx = idx;
    }

    public void Save()
    {
        if (curTime % 5 == 0)
            DataManager.GetInstance().SaveData();        
    }

    /*    public void SaveData()
        {
            PlantList plantList = new PlantList();
            plantList.plants = plantDates;

            string jsonPlantData = JsonUtility.ToJson(plantList);            //Json���� ��ȯ
            Debug.Log(jsonPlantData);
            File.WriteAllText(path + filename, jsonPlantData);
        }

        public void LoadData()
        {
            string jsonPlantData = File.ReadAllText(path + filename);
            plantDates = JsonUtility.FromJson<PlantBase[]>(jsonPlantData);                   //Json�� �ڵ�� ��ȯ
        }*/
}