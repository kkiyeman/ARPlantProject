using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class PlantBase
{
    public string plantName { get; set; }    //�Ĺ� �̸�
    public string plantType{ get; set; }     //�Ĺ� Ÿ��(ex. ���۹�, ����Ĺ�)

    public int growthRate;                   //���嵵
    public int hydration;                  //���е�
    public int nutrition;                  //���絵
    public bool isSick;                      //��������
    public bool isThirsty;                   //���к�������

    public PlantBase(string plantName, string plantType, int growthRate, int hydration, int nutrition, bool isSick, bool isThirsty)
    { }

    public abstract void Reward();
}

[Serializable]
public class PlantList
{
    public List<PlantBase> plants;
}