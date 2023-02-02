using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShelfType
{
    orn,
    cro
}
public class Shelf : MonoBehaviour
{
    public GameObject[] ornPots;
    public GameObject corPot;

    public int shelfIdx = PlantManager.GetInstance().ornCount;

    public int potIdx = PlantManager.GetInstance().croCount;

    public ShelfType type = ShelfType.cro;

    //public string[] pots;


}
