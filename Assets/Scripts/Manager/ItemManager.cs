using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region SingletoneMake
    public static ItemManager instance = null;
    public static ItemManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ItemManager");
            instance = go.AddComponent<ItemManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion

    public ItemBase[] seedItemData = new ItemBase[]
    {
        new SeedItem("´ç±Ù ¾¾¾Ñ", "¾¾¾Ñ", 100),
        new SeedItem("Åä¸¶Åä ¾¾¾Ñ", "¾¾¾Ñ" , 150),
        new SeedItem("ÇÊ¸®¾ÆÆäÆä ¾¾¾Ñ", "¾¾¾Ñ" , 220),
        new SeedItem("ÇÇ½¬º» ¾¾¾Ñ", "¾¾¾Ñ" , 200),
        new SeedItem("¾Ë·Î¿¡ ¾¾¾Ñ", "¾¾¾Ñ" , 250),
        new SeedItem("Á¦ÀÌµå½ºÅ¸ ¾¾¾Ñ", "¾¾¾Ñ" , 300)
    };

    public ItemBase[] ToolItemData = new ItemBase[]
    {
        new ToolItem("ÃÊ±Þ ¹°»Ñ¸®°³", "µµ±¸", 300),
        new ToolItem("Áß±Þ ¹°»Ñ¸®°³", "µµ±¸", 400),
        new ToolItem("°í±Þ ¹°»Ñ¸®°³", "µµ±¸", 500),
        new ToolItem("ÃÊ±Þ È­ºÐ", "µµ±¸", 300),
        new ToolItem("Áß±Þ È­ºÐ", "µµ±¸", 500),
        new ToolItem("°í±Þ È­ºÐ", "µµ±¸", 1000)
    };
}
