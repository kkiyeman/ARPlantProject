using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("Upper Side")]
    [SerializeField] Text txtCash;
    [SerializeField] Text txtGold;
    [SerializeField] Button btnCloseInven;

    [Header("Left Side")]
    [SerializeField] Button[] btnItemKinds;
    private int curItemKind = 0;
    [SerializeField] Text[] txtItemKinds;

    [Header("itemList")]
    public GameObject ItemGrid;
    [SerializeField] Text txtItemName;
    [SerializeField] Text txtItemTooltip;
    [SerializeField] List<BtnInvenItem> btnInvenItems = new List<BtnInvenItem>();



    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;
    ItemManager itemmanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();
        itemmanager = ItemManager.GetInstance();
        SetButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetButton()
    {
        btnCloseInven.onClick.AddListener(OnClickCloseInven);
        BtnItemKindSet();
    }


    private void OnClickCloseInven()
    {
        gameObject.SetActive(false);
    }

    public void ShowItemList(int i)
    {
        int idx = i;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground Grey3");
        btnItemKinds[curItemKind].image.color = new Color32(180, 180, 180, 160);
        curItemKind = idx;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground LightGrey3");
        btnItemKinds[curItemKind].image.color = Color.white;

        if (curItemKind <= 1)
        {
            //imgItemReady.gameObject.SetActive(false);
            switch (curItemKind)
            {
                case 0:
                    var itemlist = itemmanager.seedItemList;
                    for (int j = 0; j < itemlist.Count; j++)
                    {
                        var item = itemlist[j];
                        item.transform.SetParent(ItemGrid.transform);
                        btnInvenItems.Add(item);
                    }
                    break;
                case 2:
                    var itemlist2 = itemmanager.toolItemList;
                    for (int j = 0; j < itemlist2.Count; j++)
                    {
                        var item = Instantiate(itemlist2[j]);
                        item.transform.SetParent(ItemGrid.transform);
                        btnInvenItems.Add(item);
                    }
                    break;
            }
        }
        else
        {
            //imgItemReady.gameObject.SetActive(true);
        }
        if (btnInvenItems.Count > 0)
        {
            for (int d = 0; d < btnInvenItems.Count; d++)
            {
                Destroy(btnInvenItems[d].gameObject);
            }
            btnInvenItems.Clear();
        }

    }

    private void BtnItemKindSet()
    {
        for (int i = 0; i < btnItemKinds.Length; i++)
        {
            int idx = i;
            btnItemKinds[idx].onClick.AddListener(() => { ShowItemList(idx); });
        }
    }

}
