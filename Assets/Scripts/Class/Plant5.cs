using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant5 : PlantBase
{
    public Plant5(string plantName, string plantType, int growthRate, float hydration, float nutrition, bool isSick, bool isThirsty)
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
