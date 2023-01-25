using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region SingletoneMake
    public static InventoryManager instance = null;
    public static InventoryManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@InventoryManager");
            instance = go.AddComponent<InventoryManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion
}
