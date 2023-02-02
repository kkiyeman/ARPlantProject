using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantBase
{
    public string plantUserName { get; set; }//������ ���� �Ĺ� �̸�
    public string plantName { get; set; }    //�Ĺ� �̸�
    public string plantType { get; set; }     //�Ĺ� Ÿ��(ex. ���۹�, ����Ĺ�)

    public int growthRate;                   //���嵵
    public int hydration;                  //���е�
    public int nutrition;                  //���絵
    public bool isSick;                      //��������
    public bool isThirsty;                   //���к�������
    public int reward;
    public bool isDie;

    public abstract void Reward();


    public PlantData ToData()
    {
        var data = new PlantData();
        data.plantUserName = plantUserName;
        data.plantName = plantName;
        data.plantType = plantType;
        data.growthRate = growthRate;
        data.hydration = hydration;
        data.nutrition = nutrition;
        data.isSick = isSick;
        data.isThirsty = isThirsty;
        data.reward = reward;
        data.isDie = isDie;

        return data;
    }
}