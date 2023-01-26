using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
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

    [SerializeField]
    GameObject spawnablePrefab;
    GameObject spawnedObject;

    public bool isWaterThePlantOnClick;       //물주기 버튼 클릭 여부
    public bool isEnergySupplyPlantOnClick;   //영양제 버튼 클릭 여부
    public bool isPraisePlantOnClick;         //칭찬 버튼 클릭 여부
    public bool isHarvestPlantOnClick;        //수확하기 버튼 클릭 여부

    public bool btnPraiseClickAble = true;    //칭찬 버튼 클릭 가능여부 (하루에 한 번만)

    public bool allBtnUnclickAble;       //물주기, 영양제, 수확, 칭찬 버튼 클릭 가능 여부(에너지 0일 시 클릭 불가)

    public int GrowPlantReward;               //식물 수확시 얻는 보상

    [HideInInspector] public float curTime;   //진행 시간 변수

    public WaitForSecondsRealtime waitFor10Seconds = new WaitForSecondsRealtime(10);
    public WaitForSecondsRealtime waitForHalfSeconds = new WaitForSecondsRealtime(0.5f);

    //string path;
    //string filename = "save";

    public PlantBase[] plantDates = new PlantBase[]
{
        new Plant1("Plant1", "Ornamental", 0, 100, 100, false, false),
        new Plant2("Plant2", "Ornamental", 0, 100, 100, false, false),
        new Plant3("Plant3", "Ornamental", 0, 100, 100, false, false),
        new Plant4("Plant4", "Ornamental", 0, 100, 100, false, false),
        new Plant5("Plant5", "Crops", 0, 100, 100, false, false),
        new Plant6("Plant6", "Crops", 0, 100, 100, false, false),
        new Plant7("Plant7", "Crops", 0, 100, 100, false, false),
        new Plant8("Plant8", "Crops", 0, 100, 100, false, false)
};

    public List<PlantBase> MyPlants = new List<PlantBase>();

    private void Awake()
    {
        //path = Application.persistentDataPath + "/";
    }

    void Start()
    {
        spawnedObject = null;
        DataManager.GetInstance().LoadData();
    }


    void Update()
    {
        curTime = GameManager.GetInstance().runningTime;
        allBtnUnclickAble = GameManager.GetInstance().isEnegyZero;
        PlantSpawn();
        Save();
    }

    public void WaterThePlant(int curhydration, int curEnergy)             //물주기 함수 (물주기 버튼 클릭 시 수분량 20 상승) , 에너지 5소모
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

    public void NutritionSupplyPlant(int nutrition, int curEnergy)             //영양분 공급 함수(영양제 버튼 클릭 시 영양도 증가) , 에너지 10소모
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

/*    public void MinusPlantStatus(int curhydration, int nutrition)  //매 시간 수분량, 영양도 감소 함수(시간당 10 감소)       Update
    {
        if (curTime % 10 == 0)          //수분량, 영양도 감소 시간(일단은 10초로) 개발 완료후 3600초로 변경
        {
            curhydration -= 10;
            nutrition -= 10;
        }
        else
            return;
    }*/

    IEnumerator MinusPlantStatus(int curhydration, int nutrition) //매 시간 수분량, 영양도 감소 함수(시간당 10 감소)
    {
        while (true)
        {
            yield return waitFor10Seconds;       //수분량, 영양도 감소 시간(일단은 10초로) 개발 완료후 3600초로 변경

            if (curTime % 10 == 0)          //수분량, 영양도 감소 시간(일단은 10초로) 개발 완료후 3600초로 변경
            {
                curhydration -= 10;
                nutrition -= 10;
            }
        }
    }


    IEnumerator DieThePlant(int curhydration, int nutrition, Object plantName) //식물 죽는 함수(수분도 150이상, 30미만, 영양도 0이하)       Update
    {
        while (true)
        {
            yield return waitForHalfSeconds;      //수분량, 영양도 감소 시간(일단은 10초로) 개발 완료후 3600초로 변경

            if (curhydration >= 150 || curhydration < 30 || nutrition <= 0)
            {
                Destroy(plantName);
            }
        }
    }
    /*public void DieThePlant(int curhydration, int nutrition, Object plantName) //식물 죽는 함수(수분도 150이상, 30미만, 영양도 0이하)       Update
    {
        if (curhydration >= 150 || curhydration < 30 || nutrition <= 0)
        {
            Destroy(plantName);
        }
        else
            return;
    }*/

    public void PlantDisease(int curhydration, int nutrition) //식물 상황별 상태이상 함수(수분도 120초과 150미만, 영양도 100이상, 20미만)       Update
    {
        if (120 < curhydration && curhydration < 150 || nutrition >= 100 || nutrition < 20)
        {
            //식물 상태 이상
        }
        else
            return;
    }

    public void GrowthRatePlant(int curGrowthRate)    //식물 성장 함수       Update
    {
        if (curTime % 30 == 0)                 //식물 성장 시간(일단은 30초로) 개발 완료후 10,800초로 변경
        {
            curGrowthRate += 1;
        }
        else
            return;
    }

    public void PraisePlant(int curGrowthRate, int curEnergy)   //식물 칭찬하기 함수 , 에너지 20소모     하루에 한 번만 가능
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
                    Debug.Log("하루 한 번만 가능");
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

    public void HarvestPlant(int curEnergy, int curGrowthRate, int TotalGrowthRate, int Reward, Object plantName)      //식물 수확시 얻는 재화 및 소비 에너지(끝까지 수확 못할 시 일부분만 보상)
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

    public void SpawnPrefab(Vector3 spawnPosition)
    {
        int ran = Random.Range(1, 6);
        var ob = Resources.Load<GameObject>($"Plant/FishBone");
        var Plantdata = Instantiate(ob, spawnPosition, Quaternion.identity);
        Plantdata.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
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
                ARRenderManager.GetInstance().PlaneOff();
            }
        }

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

            string jsonPlantData = JsonUtility.ToJson(plantList);            //Json으로 변환
            Debug.Log(jsonPlantData);
            File.WriteAllText(path + filename, jsonPlantData);
        }

        public void LoadData()
        {
            string jsonPlantData = File.ReadAllText(path + filename);
            plantDates = JsonUtility.FromJson<PlantBase[]>(jsonPlantData);                   //Json을 코드로 변환
        }*/
}