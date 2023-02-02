using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class CherryTomato : PlantBase
{
    public CherryTomato(string plantUserName, string plantName, string plantType, int growthRate, int hydration, int nutrition, bool isSick, bool isThirsty, int reward, bool isDie)
    {
        this.plantUserName = plantUserName;
        this.plantName = plantName;
        this.plantType = plantType;
        this.growthRate = growthRate;
        this.hydration = hydration;
        this.nutrition = nutrition;
        this.isSick = isSick;
        this.isThirsty = isThirsty;
        this.reward = reward;
        this.isDie = isDie;
    }

    public override void Reward()
    {

    }
}
