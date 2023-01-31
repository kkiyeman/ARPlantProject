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

    private void Start()
    {
        
    }

    private void Update()
    {

        if (myPlantList.Count > 0)
        {
   
            CheckMyPlantsIdx();
            
        }
    }

    public void CheckMyPlantsIdx()
    {
        for(int i = 0; i < myPlantList.Count; i++)
        {
            i = myPlantIdx;
        }
    }

    public IEnumerator GrowthRatePlant(int idx)
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(10);
            myPlantList[idx].growthRate++;
        }
    }

}
