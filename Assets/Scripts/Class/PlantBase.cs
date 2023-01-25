using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class PlantBase
{
    public string plantName { get; set; }    //식물 이름
    public string plantType{ get; set; }     //식물 타입(ex. 농작물, 관상식물)

    public int growthRate;                   //성장도
    public int hydration;                  //수분도
    public int nutrition;                  //영양도
    public bool isSick;                      //질병여부
    public bool isThirsty;                   //수분부족여부

    public PlantBase(string plantName, string plantType, int growthRate, int hydration, int nutrition, bool isSick, bool isThirsty)
    { }

    public abstract void Reward();
}

[Serializable]
public class PlantList
{
    public List<PlantBase> plants;
}