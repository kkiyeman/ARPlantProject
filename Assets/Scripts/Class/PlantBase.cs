using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase
{
    public string plantName { get; set; }
    public string plantType{ get; set; }

    public float hydration;         //수분도
    public float nutrition;         //영양도
    public int growthRate;          //성장도
}
