using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlantList
{
    public string plantUserName;
    public string plantName;
    public int growthRate;                   //���嵵
    public int hydration;                  //���е�
    public int nutrition;                  //���絵
    public bool isSick;                      //��������
    public int reward;
    public bool isDie;

    public MyPlantList(string plantusername, string plantname, int growthrate, int hydrationrate, int nutritionrate, bool issick, int reward, bool isDie)
    {
        plantUserName = plantusername;
        plantName = plantname;
        growthRate = growthrate;
        hydration = hydrationrate;
        nutrition = nutritionrate;
        isSick = issick;
        this.reward = reward;
        this.isDie = isDie;
    }

}
