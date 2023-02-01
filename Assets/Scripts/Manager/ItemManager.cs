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
        new SeedItem("��� ����", "����", 100, "����� ���� �� �ִ� ����"),
        new SeedItem("����丶�� ����", "����" , 150,"����丶�並 ���� �� �ִ� ����"),
        new SeedItem("�ʸ������� ����", "����" , 220,"�ʸ������並 ���� �� �ִ� ����"),
        new SeedItem("�ǽ��� ����", "����" , 200,"�ǽ����� ���� �� �ִ� ����"),
        new SeedItem("�˷ο� ����", "����" , 250,"�˷ο��� ���� �� �ִ� ����"),
        new SeedItem("������ ����", "����" , 300,"�����ʸ� ���� �� �ִ� ����")
    };

    public ItemBase[] toolItemData = new ItemBase[]
    {
        new ToolItem("�ʱ� ���Ѹ���", "����", 300, "�Ĺ��鿡�� ������ ���� �� �� �ִ� ����"),
        new ToolItem("�߱� ���Ѹ���", "����", 400, "�Ĺ��鿡�� ���� ���� �� �� �ִ� ����"),
        new ToolItem("��� ���Ѹ���", "����", 500, "�Ĺ��鿡�� �ְ��� ���� �� �� �ִ� ����."),
        new ToolItem("�ʱ� ȭ��", "����", 300, "�Ĺ��� ���� �� �ִ� ���� ȭ��"),
        new ToolItem("�߱� ȭ��", "����", 500, "�Ĺ��� ���� �� �ִ� ���� ȭ��"),
        new ToolItem("��� ȭ��", "����", 1000, "�Ĺ��� ���� �� �ִ� �ְ��� ȭ�� ")
    };

    public List<BtnInvenItem> seedItemList = new List<BtnInvenItem>();
    public List<BtnInvenItem> toolItemList = new List<BtnInvenItem>();

    private void Awake()
    {
    }
}
