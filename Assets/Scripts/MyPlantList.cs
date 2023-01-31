using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlantList : MonoBehaviour
{
    public string plantUserName;
    public string plantName;
    public int growthRate;                   //성장도
    public int hydration;                  //수분도
    public int nutrition;                  //영양도
    public bool isSick;                      //질병여부
    public int reward;

    public MyPlantList(string plantusername, string plantname, int growthrate, int hydrationrate, int nutritionrate, bool issick, int reward)
    {
        plantUserName = plantusername;
        plantName = plantname;
        growthRate = growthrate;
        hydration = hydrationrate;
        nutrition = nutritionrate;
        isSick = issick;
        this.reward = reward;
    }

}
