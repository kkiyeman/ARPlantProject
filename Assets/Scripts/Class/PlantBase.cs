using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantBase
{
    public string plantName { get; set; }    //�Ĺ� �̸�
    public string plantType{ get; set; }     //�Ĺ� Ÿ��(ex. ���۹�, ����Ĺ�)

    public int growthRate;                   //���嵵
    public int hydration;                  //���е�
    public int nutrition;                  //���絵
    public bool isSick;                      //��������
    public bool isThirsty;                   //���к�������

    public abstract void Reward();
}
