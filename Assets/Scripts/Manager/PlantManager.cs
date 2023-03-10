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
    ARRaycastManager m_RaycastManager; // AR 레이캐스트매니저
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>(); // 터치하는 위치를 알아내는 것

    UIManager uimanager;

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

    public WaitForSecondsRealtime waitFor30Seconds = new WaitForSecondsRealtime(30);
    public WaitForSecondsRealtime waitFor10Seconds = new WaitForSecondsRealtime(10);
    public WaitForSecondsRealtime waitForHalfSeconds = new WaitForSecondsRealtime(0.5f);

    public bool onClickOrnBtn;                //관상식물 심기 버튼 클릭
    public bool onClickCroBtn;                //농작물 심기 버튼 클릭
    public bool onClickPlantBtn;              //심기 버튼 클릭

    public string plantsName;

    public int ornCount = 0;
    public int croCount = 0;

    public int curShelfCount;
    public int curCroCount;

    MyPlantManager myPlantManager;

    [SerializeField] private Camera arCamera;
    public bool objTouched;

    public int clickIdx;

    public int potIdx;
    [HideInInspector] public Transform potTrans;

    public GameObject selectPot;

    public string setPlantUserName;
    public string setPlantName;
    public int setGrowthRate;
    public int setHydration;
    public int setNutrition;
    public bool setIsSick;

    public bool[] isPlantSeed;

    public bool[] isSick;
    public bool[] isDie;

    public List<GameObject> seeds = new List<GameObject>();
    public List<GameObject> sprouts = new List<GameObject>();
    public List<GameObject> middles = new List<GameObject>();
    public List<GameObject> grownups = new List<GameObject>();
    public List<GameObject> deads = new List<GameObject>();
    public List<GameObject> sicks = new List<GameObject>();
    public List<GameObject> harvests = new List<GameObject>();


    //string path;
    //string filename = "save";

    public PlantBase[] plantDates = new PlantBase[]
{
        new FishBone("FishBone", "FishBone", "Ornamental", 0, 100, 100, false, false, 100, false),
        new Pileapepe("Pileapepe", "Pileapepe", "Ornamental", 0, 100, 100, false, false, 100, false),
        new Jade("Jade", "Jade", "Ornamental", 0, 100, 100, false, false, 100, false),
        new Palm("Palm", "Palm", "Ornamental", 0, 100, 100, false, false, 100, false),
        new Carrot("Carrot", "Carrot", "Crops", 0, 100, 100, false, false, 100, false),
        new CherryTomato("CherryTomato", "CherryTomato", "Crops", 0, 100, 100, false, false, 100, false),
};

    public List<PlantBase> MyPlants = new List<PlantBase>();

    private void Awake()
    {
        //path = Application.persistentDataPath + "/";
        instance = this;    // 현재 하이어라키에 있는 스폰매니저 속 스크립트를 사용하기 위해 인스턴스를 현재 생성되어 있는 걸로 지정한다.
        DontDestroyOnLoad(gameObject); // 스폰매니저를 DontDestroyOnLoad로 변경해준다.

        uimanager = UIManager.GetInstance();
    }

    void Start()
    {
        myPlantManager = MyPlantManager.GetInstance();
        var myPlantList = myPlantManager.myPlantList;
        spawnedObject = null;
        //DataManager.GetInstance().LoadData();

    }


    void Update()
    {
        curTime = GameManager.GetInstance().runningTime;
        allBtnUnclickAble = GameManager.GetInstance().isEnegyZero;
        PlantSpawn();
        SpawnSeed();
       // Save();
    }


/*    public void SpawnPrefab(Vector3 spawnPosition)
    {
        
        int ran = Random.Range(1, 3);
        var ob = Resources.Load<GameObject>($"plant/Pileapepe{ran}");
        var Plantdata = Instantiate(ob, spawnPosition, Quaternion.identity);
        Plantdata.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }*/

    /// <summary>
    /// 선반 , 농작물 선택후 2개이상 생성안되도록 만든 함수.
    /// </summary>
    /// <param name="spawnPosition"></param>
    public void SpawnPrefab(Vector3 spawnPosition)
    {
        int ranCrops = Random.Range(0, 2);
        if (onClickPlantBtn)
        {
            if (onClickCroBtn)
            {

                if (croCount < 2)
                {
                    plantsName = "plant/cropot";
                    onClickCroBtn = false;

                    var rotation = Quaternion.Euler(0, 180, 0);
                    var ob = Resources.Load<GameObject>(plantsName);
                    var Plantdata = Instantiate(ob, spawnPosition, rotation);
                    Plantdata.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

                    croCount += 1;

                    curCroCount = croCount;
                }
                else
                {
                    Debug.Log("2개 이상 소환 불가");
                    onClickCroBtn = false;
                }
            }
            else if (onClickOrnBtn)
            {
                if (ornCount < 2)
                {
                    plantsName = "Shelf/Shelf_On_Pot";
                    onClickOrnBtn = false;

                    var rotation = Quaternion.Euler(0, 180, 0);
                    var ob = Resources.Load<GameObject>(plantsName);
                    var Plantdata = Instantiate(ob, spawnPosition, rotation);
                    Plantdata.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

                    ornCount += 1;

                    curShelfCount = ornCount;
                }
                else
                {
                    Debug.Log("2개 이상 소환 불가");
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
    /// <summary>
    /// 뒷부분이 클릭 안되게 만들어주고 클릭 위치에 선반, 화분 위치시키는 것
    /// </summary>
    public void PlantSpawn()
    {

        if (Input.touchCount == 0) // 터치 카운트가 0이면
             return;        // 리턴
        else
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // 뒷부분이 안눌리게
                return;
            else
            {
                if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began) // 터치를 시작했을 때
                    {
                        SpawnPrefab(m_Hits[0].pose.position); // 스폰프리펩(선반, 화분)을 해당 포지션에 생성
                        
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null) // 손을 안 뗀 상태에서 스폰드오브젝트가 널이 아니고 터치 위치가 움직이면 

                    {
                        spawnedObject.transform.position = m_Hits[0].pose.position; // 그 터치 위치로 스폰드오브젝트를 옮겨준다.
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Ended) // 손을 떼면
                    {
                        spawnedObject = null; // 스폰오브젝트의 값을 null로 초기화 시켜준다.
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
        if (Input.touchCount == 0)
            return;
        else
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            else
            {
                RaycastHit hitobj;
                if (Physics.Raycast(arCamera.ScreenPointToRay(Input.mousePosition), out hitobj))
                {
                    var shelf = hitobj.collider.GetComponentInParent<Shelf>();
                    potTrans = hitobj.collider.gameObject.transform.parent;
                    Debug.Log("potTrans : " + potTrans.name);

                    bool isOrn = shelf.type == ShelfType.orn; // shelf.type == ShelfType.orn이 true면 isOrn 도 true, false면 false
                    potIdx = isOrn ? potTrans.GetSiblingIndex() + (shelf.shelfIdx * 4) : potTrans.GetSiblingIndex() + (shelf.potIdx) + 4; // 

                    Debug.Log("potIdx : " + potIdx);

                    // potTrans.GetSiblingIndex() + (shelf.potIdx) + 8

                    if (!isPlantSeed[potIdx])
                    {
                        GameObject targetUI = isOrn ? uimanager.GetUI("UIOrnSpawn") : uimanager.GetUI("UICroSpawn");
                        targetUI.SetActive(true);
                    }
                    else
                    {
                        var uiplant = uimanager.GetUI("UIPlant").GetComponent<UIPlant>();
                        uiplant.OnClickBottomOn();
                    }

                    selectPot = hitobj.collider.gameObject;
                }
                
            }
            ARRenderManager armanager = ARRenderManager.GetInstance();
                armanager.PlaneOff();
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

    public void SpawnMyPlant(string plantName)
    {

        plantName = plantDates[clickIdx].plantName;
        var seedob = Resources.Load<GameObject>($"plant/{plantName}/Seed");
        var sproutob = Resources.Load<GameObject>($"plant/{plantName}/Sprout");
        var middleob = Resources.Load<GameObject>($"plant/{plantName}/{plantName}_M");
        var grownupob = Resources.Load<GameObject>($"plant/{plantName}/{plantName}_L");
        var deadob = Resources.Load<GameObject>($"plant/{plantName}/Dead_Plant");
        var sickob = Resources.Load<GameObject>($"plant/Icon_FeelBad22");
        var harvestob = Resources.Load<GameObject>($"plant/Icon_Take22");
        //var seed = Resources.Load<GameObject>($"plant/Seed");
        Debug.Log("123123");
        Debug.Log("potTrans : " + potTrans.name);
        var seed = Instantiate(seedob, potTrans);
        var sprout = Instantiate(sproutob, potTrans);
        var middle = Instantiate(middleob, potTrans);
        var grownup = Instantiate(grownupob, potTrans);
        var dead = Instantiate(deadob, potTrans);
        var sick = Instantiate(sickob, potTrans);
        var harvest = Instantiate(harvestob, potTrans);
        seeds.Add(seed);        //리스트를 일일이 만들어줌.
        sprouts.Add(sprout);
        middles.Add(middle);
        grownups.Add(grownup);
        deads.Add(dead);
        sicks.Add(sick);
        harvests.Add(harvest);
        sprout.gameObject.SetActive(false);
        middle.gameObject.SetActive(false);
        grownup.gameObject.SetActive(false);
        dead.gameObject.SetActive(false);
        sick.gameObject.SetActive(false);
        harvest.gameObject.SetActive(false);
        isPlantSeed[potIdx] = true;
        var uiplant = UIManager.GetInstance().GetUI("UIPlant").GetComponent<UIPlant>();
        uiplant.imgsWhatPlant.sprite = Resources.Load<Sprite>($"Image/Spawn/PlantStatus/Seed");

        MyPlantList myPlant = new MyPlantList(
            setPlantUserName,
            plantDates[clickIdx].plantName,
            plantDates[clickIdx].growthRate,
            plantDates[clickIdx].hydration,
            plantDates[clickIdx].nutrition,
            false,
            plantDates[clickIdx].reward,
            plantDates[clickIdx].isDie
            );
        myPlantManager.myPlantList.Add(myPlant);

        PlantManagement();
    }

    public void SetPlantInfo(int idx)
    {
        setPlantName = plantDates[idx].plantName;
        setGrowthRate = plantDates[idx].growthRate;
        setHydration = plantDates[idx].hydration;
        setNutrition = plantDates[idx].nutrition;
        setIsSick = plantDates[idx].isSick;
    }

    public void PlantManagement()
    {
        MyPlantManager.GetInstance().PlamtManagement();
    }

    public void SproutOn(int idx)
    {
        seeds[idx].gameObject.SetActive(false);
        sprouts[idx].gameObject.SetActive(true);
        middles[idx].gameObject.SetActive(false);
        grownups[idx].gameObject.SetActive(false);
        deads[idx].gameObject.SetActive(false);
        var uiplant = UIManager.GetInstance().GetUI("UIPlant").GetComponent<UIPlant>();
        uiplant.imgsWhatPlant.sprite = Resources.Load<Sprite>($"Image/Spawn/PlantStatus/Sprout");
    }

    public void MiddleOn(int idx)
    {
        seeds[idx].gameObject.SetActive(false);
        sprouts[idx].gameObject.SetActive(false);
        middles[idx].gameObject.SetActive(true);
        grownups[idx].gameObject.SetActive(false);
        deads[idx].gameObject.SetActive(false);
        var uiplant = UIManager.GetInstance().GetUI("UIPlant").GetComponent<UIPlant>();
        string name = MyPlantManager.GetInstance().myPlantList[idx].plantName;
        uiplant.imgsWhatPlant.sprite = Resources.Load<Sprite>($"Image/Spawn/PlantStatus/{name}_M");
    }
    public void GrownUpOn(int idx)
    {
        seeds[idx].gameObject.SetActive(false);
        sprouts[idx].gameObject.SetActive(false);
        middles[idx].gameObject.SetActive(false);
        grownups[idx].gameObject.SetActive(true);
        deads[idx].gameObject.SetActive(false);
        var uiplant = UIManager.GetInstance().GetUI("UIPlant").GetComponent<UIPlant>();
        string name = MyPlantManager.GetInstance().myPlantList[idx].plantName;
        uiplant.imgsWhatPlant.sprite = Resources.Load<Sprite>($"Image/Spawn/PlantStatus/{name}_L");
    }
    public void DeadOn(int idx)
    {
        seeds[idx].gameObject.SetActive(false);
        sprouts[idx].gameObject.SetActive(false);
        middles[idx].gameObject.SetActive(false);
        grownups[idx].gameObject.SetActive(false);
        deads[idx].gameObject.SetActive(true);
        var uiplant = UIManager.GetInstance().GetUI("UIPlant").GetComponent<UIPlant>();
        uiplant.imgsWhatPlant.sprite = Resources.Load<Sprite>($"Image/Spawn/PlantStatus/dead");
    }
    public void HarvestOnClick(int idx, int reward)
    {
        seeds[idx].gameObject.SetActive(false);
        sprouts[idx].gameObject.SetActive(false);
        middles[idx].gameObject.SetActive(false);
        grownups[idx].gameObject.SetActive(false);
        deads[idx].gameObject.SetActive(false);
        harvests[idx].gameObject.SetActive(false);
        var uiplant = UIManager.GetInstance().GetUI("UIPlant").GetComponent<UIPlant>();
        uiplant.imgsWhatPlant.sprite = Resources.Load<Sprite>($"Image/Spawn/PlantStatus/Empty");
        GameManager.GetInstance().curGameMoney += reward;
    }

    public void HarvestAble(int idx)
    {
        harvests[idx].gameObject.SetActive(true);
    }

    public void HarvestOff(int idx)
    {
        harvests[idx].gameObject.SetActive(false);
    }

    public void DiseaseOn(int idx)
    {
        sicks[idx].gameObject.SetActive(true);
        harvests[idx].gameObject.SetActive(false);
    }

    public void DiseaseOff(int idx)
    {
        sicks[idx].gameObject.SetActive(false);
    }

    public void removeplant(int idx)
    {
        Destroy(seeds[idx].gameObject);
        Destroy(sprouts[idx].gameObject);
        Destroy(middles[idx].gameObject);
        Destroy(grownups[idx].gameObject);
        Destroy(deads[idx].gameObject);

        myPlantManager.myPlantList.RemoveAt(idx);
        isPlantSeed[idx] = false;
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