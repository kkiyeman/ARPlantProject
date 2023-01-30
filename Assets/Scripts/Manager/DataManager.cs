using System.Collections;
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
    string filename = "save.text";

    private void Awake()
    {
        //path = Application.persistentDataPath + "/";
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SaveData()
    {
        var plantDates = PlantManager.GetInstance().plantDates;
        PlantList plantList = new PlantList(plantDates);
        
        var test = JsonUtility.ToJson(plantDates[0]);            //Json���� ��ȯ

        string jsonPlantData = JsonUtility.ToJson(plantList);            //Json���� ��ȯ
        Debug.Log(jsonPlantData);
        File.WriteAllText(path + filename, jsonPlantData);
    }

    public void LoadData()
    {
        var plantDates = PlantManager.GetInstance().plantDates;
        string jsonPlantData = File.ReadAllText(path + filename);
        plantDates = JsonUtility.FromJson<PlantBase[]>(jsonPlantData);                   //Json�� �ڵ�� ��ȯ
    }
}
