using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shelf : MonoBehaviour
{
    [SerializeField]private GameObject[] pots;
    public int idx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIdx(int idx)
    {
        this.idx = idx;
        PlantManager.GetInstance().SetPotIdx(idx);
    }


}
