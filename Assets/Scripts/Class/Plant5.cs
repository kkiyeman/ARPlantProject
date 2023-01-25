using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Plant5 : PlantBase
{
    public Plant5(string plantName, string plantType, int growthRate, int hydration, int nutrition, bool isSick, bool isThirsty) : base(plantName, plantType, growthRate, hydration, nutrition, isSick, isThirsty)
    {
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
