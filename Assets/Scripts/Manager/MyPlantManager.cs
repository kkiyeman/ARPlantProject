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

    public List<MyPlantList> myPlantList = new List<MyPlantList>();

}
