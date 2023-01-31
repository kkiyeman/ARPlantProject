using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Palm : PlantBase
{
    public Palm(string plantUserName, string plantName, string plantType, int growthRate, int hydration, int nutrition, bool isSick, bool isThirsty)
    {
        this.plantUserName = plantUserName;
        this.plantName = plantName;
        this.plantType = plantType;
        this.growthRate = growthRate;
        this.hydration = hydration;
        this.nutrition = nutrition;
        this.isSick = isSick;
        this.isThirsty = isThirsty;
    }

    public override void Reward()
    {

    }
}
