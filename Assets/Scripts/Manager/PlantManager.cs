using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    public bool isWaterThePlantOnClick;       //���ֱ� ��ư Ŭ�� ����
    public bool isEnergySupplyPlantOnClick;   //������ ��ư Ŭ�� ����
    public bool isPraisePlantOnClick;         //Ī�� ��ư Ŭ�� ����
    public bool isHarvestPlantOnClick;        //��Ȯ�ϱ� ��ư Ŭ�� ����

    public bool btnPraiseClickAble = true;    //Ī�� ��ư Ŭ�� ���ɿ��� (�Ϸ翡 �� ����)

    public int GrowPlantReward;               //�Ĺ� ��Ȯ�� ��� ����

    [HideInInspector] public float curTime;                  //���� �ð� ����

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

    void Start()
    {
        spawnedObject = null;
    }


    void Update()
    {
        curTime += Time.realtimeSinceStartup;
        PlantSpawn();
    }

    public void WaterThePlant(int curhydration, int curEnergy)             //���ֱ� �Լ� (���ֱ� ��ư Ŭ�� �� ���з� 20 ���) , ������ 5�Ҹ�
    {
        if (isWaterThePlantOnClick)
        {
            curhydration += 20;
            curEnergy -= 5;
        }
        else
            return;
    }

    public void NutritionSupplyPlant(int nutrition, int curEnergy)             //����� ���� �Լ�(������ ��ư Ŭ�� �� ���絵 ����) , ������ 10�Ҹ�
    {
        if (isEnergySupplyPlantOnClick)
        {
            nutrition += 30;
            curEnergy -= 10;
        }
        else
            return;
    }

    public void MinusPlantStatus(int curhydration, int nutrition)  //�� �ð� ���з�, ���絵 ���� �Լ�(�ð��� 10 ����)       Update
    {
        if (curTime > 10)          //���з�, ���絵 ���� �ð�(�ϴ��� 10�ʷ�) ���� �Ϸ��� 3600�ʷ� ����
        {
            curhydration -= 10;
            nutrition -= 10;
            curTime = 0;
        }
        else
            return;
    }

    public void DieThePlant(int curhydration, int nutrition, Object plantName) //�Ĺ� �״� �Լ�(���е� 150�̻�, 30�̸�, ���絵 0����)       Update
    {
        if (curhydration >= 150 || curhydration < 30 || nutrition <= 0)
        {
            Destroy(plantName);
        }
        else
            return;
    }

    public void PlantDisease(int curhydration, int nutrition) //�Ĺ� ��Ȳ�� �����̻� �Լ�(���е� 120�ʰ� 150�̸�, ���絵 100�̻�, 20�̸�)       Update
    {
        if (120 < curhydration && curhydration < 150 || nutrition >= 100 || nutrition < 20)
        {
            //�Ĺ� ���� �̻�
        }
        else
            return;
    }

    public void GrowthRatePlant(int curGrowthRate)    //�Ĺ� ���� �Լ�       Update
    {
        if (curTime > 30)                 //�Ĺ� ���� �ð�(�ϴ��� 30�ʷ�) ���� �Ϸ��� 10,800�ʷ� ����
        {
            curGrowthRate += 1;
        }
        else
            return;
    }

    public void PraisePlant(int curGrowthRate, int curEnergy)   //�Ĺ� Ī���ϱ� �Լ� , ������ 20�Ҹ�     �Ϸ翡 �� ���� ����
    {
        if (isPraisePlantOnClick)
        {
            if (btnPraiseClickAble)
            {
                curGrowthRate += 2;
                curEnergy -= 20;
                btnPraiseClickAble = false;
            }
            else
                Debug.Log("�Ϸ� �� ���� ����");
        }
        else
            return;

        if (curTime >= 86400)
        {
            btnPraiseClickAble = true;
            curTime = 0;
        }
    }

    public void HarvestPlant(int curEnergy, int curGrowthRate, int TotalGrowthRate, int Reward)      //�Ĺ� ��Ȯ�� ��� ��ȭ �� �Һ� ������(������ ��Ȯ ���� �� �Ϻκи� ����)
    {
        if (isHarvestPlantOnClick)
        {
            curEnergy -= 5;
            if (curGrowthRate != TotalGrowthRate)
            {
                curEnergy -= 15;
                GrowPlantReward = Reward * (curGrowthRate / TotalGrowthRate);
            }
            else
                GrowPlantReward = Reward;
        }
        else
            return;
    }

    public void SpawnPrefab(Vector3 spawnPosition)
    {
        int ran = Random.Range(1, 6);
        Object ob = Resources.Load($"Plant/FishBone");
        spawnedObject = (GameObject)Instantiate(ob, spawnPosition, Quaternion.identity);
        spawnedObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
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
            }
        } 
    }
}