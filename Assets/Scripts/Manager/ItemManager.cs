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
        new SeedItem("당근 씨앗", "씨앗", 100, "당근을 심을 수 있는 씨앗"),
        new SeedItem("방울토마토 씨앗", "씨앗" , 150,"방울토마토를 심을 수 있는 씨앗"),
        new SeedItem("필리아페페 씨앗", "씨앗" , 220,"필리아페페를 심을 수 있는 씨앗"),
        new SeedItem("피쉬본 씨앗", "씨앗" , 200,"피쉬본을 심을 수 있는 씨앗"),
        new SeedItem("알로에 씨앗", "씨앗" , 250,"알로에를 심을 수 있는 씨앗"),
        new SeedItem("여인초 씨앗", "씨앗" , 300,"여인초를 심을 수 있는 씨앗")
    };

    public ItemBase[] toolItemData = new ItemBase[]
    {
        new ToolItem("초급 물뿌리개", "도구", 300, "식물들에게 적당한 물을 줄 수 있는 도구"),
        new ToolItem("중급 물뿌리개", "도구", 400, "식물들에게 좋은 물을 줄 수 있는 도구"),
        new ToolItem("고급 물뿌리개", "도구", 500, "식물들에게 최고의 물을 줄 수 있는 도구."),
        new ToolItem("초급 화분", "도구", 300, "식물을 심을 수 있는 보통 화분"),
        new ToolItem("중급 화분", "도구", 500, "식물을 심을 수 있는 좋은 화분"),
        new ToolItem("고급 화분", "도구", 1000, "식물을 심을 수 있는 최고의 화분 ")
    };

    public List<BtnInvenItem> seedItemList = new List<BtnInvenItem>();
    public List<BtnInvenItem> toolItemList = new List<BtnInvenItem>();

    private void Awake()
    {
    }
}
