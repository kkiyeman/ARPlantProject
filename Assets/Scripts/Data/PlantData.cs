using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class PlantData
{
    public string plantUserName;
    public string plantName;
    public string plantType;

    public int growthRate;
    public int hydration;
    public int nutrition;
    public bool isSick;
    public bool isThirsty;
    public int reward;
}

[Serializable]
public class PlantList
{
    public List<PlantData> plants;

    public PlantList(PlantBase[] plantArray)
    {
        plants = new List<PlantData>();

        for (int i = 0; i < plantArray.Length; i++)
            plants.Add(plantArray[i].ToData());
    }
}