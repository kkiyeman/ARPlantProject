using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

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

    public bool isWaterThePlantOnClick;    //���ֱ� ��ư Ŭ�� ����
    public bool isEnergySupplyPlantOnClick;    //������ ��ư Ŭ�� ����

    [HideInInspector]public float curTime;                  //���� �ð� ����

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

    void Start()
    {
        spawnedObject = null;
    }


    void Update()
    {
        PlantSpawn();
    }

    public void WaterThePlant(int curhydration)             //���ֱ� �Լ� (���ֱ� ��ư Ŭ�� �� ���з� 20 ���)
    {
        if (isWaterThePlantOnClick)
        {
            curhydration += 20;
        }
        else
            return;
    }

    public void NutritionSupplyPlant(int nutrition)             //����� ���� �Լ�(������ ��ư Ŭ�� �� ���絵 ����)
    {
        if (isEnergySupplyPlantOnClick)
        {
            nutrition += 30;
        }
        else
            return;
    }

    public void MinusPlantStatus(int curhydration, int nutrition)  //�� �ð� ���з�, ���絵 ���� �Լ�(�ð��� 10 ����)
    {
        curTime += Time.realtimeSinceStartup;

        if (curTime > 10)          //���з�, ���絵 ���� �ð�(�ϴ��� 10�ʷ�) ���� �Ϸ��� 3600�ʷ� ����
        {
            curhydration -= 10;
            nutrition -= 10;
            curTime = 0;
        }
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
