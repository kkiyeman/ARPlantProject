/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    #region SingletoneMake
    public static DataManager instance = null;
    public static DataManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@DataManager");
            instance = go.AddComponent<DataManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion

    string path;
    string filename = "save";

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
        path = Application.persistentDataPath + "/";
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SaveData()
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
    }
}*/
