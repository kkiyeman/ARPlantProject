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
        new SeedItem("��� ����", "����", 100),
        new SeedItem("�丶�� ����", "����" , 150),
        new SeedItem("�ʸ������� ����", "����" , 220),
        new SeedItem("�ǽ��� ����", "����" , 200),
        new SeedItem("�˷ο� ����", "����" , 250),
        new SeedItem("���̵彺Ÿ ����", "����" , 300)
    };

    public ItemBase[] ToolItemData = new ItemBase[]
    {
        new ToolItem("�ʱ� ���Ѹ���", "����", 300),
        new ToolItem("�߱� ���Ѹ���", "����", 400),
        new ToolItem("��� ���Ѹ���", "����", 500),
        new ToolItem("�ʱ� ȭ��", "����", 300),
        new ToolItem("�߱� ȭ��", "����", 500),
        new ToolItem("��� ȭ��", "����", 1000)
    };
}
