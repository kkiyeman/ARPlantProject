using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIStore : MonoBehaviour
{


    [Header("Upper Side")]
    [SerializeField] Button btnCloseStore;
    [SerializeField] Text txtEnergy;
    [SerializeField] Text txtGold;

    [Header("Left Side")]
    [SerializeField] Button[] btnItemKinds;
    private int curItemKind = 0;
    [SerializeField] Text[] txtItemKinds;

    [Header("Item List")]
    [SerializeField] List<BtnItem> btnItems = new List<BtnItem>();
    [SerializeField] Text[] txtItems;
    [SerializeField] Text[] txtItemPrices;
    [SerializeField] GameObject content;
    [SerializeField] Image imgItemReady;

    [Header("Item Buy PopUp")]
    [SerializeField] Image imgItemBuy;
    [SerializeField] Button btnCloseBuy;
    [SerializeField] Image imgItemName;
    [SerializeField] Text txtItemName;
    [SerializeField] Text txtItemPrice;
    [SerializeField] Text txtItemCount;
    private int curCount = 1;
    [SerializeField] Text txtTotalPrice;
    [SerializeField] InputField inputItemCount;
    [SerializeField] Button btnItemCountMinus;
    [SerializeField] Button btnItemCountPlus;
    [SerializeField] Button btnItemBuy;
    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;
    ItemManager itemmanager;

    void Start()
    {
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();
        itemmanager = ItemManager.GetInstance();
        GetItemList(0);
        ButtonSetting();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void ButtonSetting()
    {
        btnCloseStore.onClick.AddListener(OnClickCloseStore);
        btnCloseBuy.onClick.AddListener(OnClickCloseBuy);
        btnItemCountPlus.onClick.AddListener(OnClickPlusItemCount);
        btnItemCountMinus.onClick.AddListener(OnClickMinusItemCount);
        btnItemBuy.onClick.AddListener(OnClickBuy);
        BtnItemKindSet();
    }



    private void OnClickCloseStore()
    {
        gameObject.SetActive(false);
    }

    private void OnClickCloseBuy()
    {
        curCount = 1;
        SetItemBuy();
        imgItemBuy.gameObject.SetActive(false);
    }

    private void BtnItemsSetting()
    {
        for (int i = 0; i < btnItems.Count; i++)
        {
            int idx = i;
            Button btn = btnItems[idx].GetComponent<Button>();
            btn.onClick.AddListener(() => { OnClickOpenBuy(idx); });
        }
    }

    private void BtnItemKindSet()
    {
        for(int i = 0; i<btnItemKinds.Length; i++)
        {
            int idx = i;
            btnItemKinds[idx].onClick.AddListener(() => { ShowItemList(idx); });
        }
    }

    private void OnClickOpenBuy(int index)
    {
        int price = int.Parse(btnItems[index].itemPrice.text);
        imgItemBuy.gameObject.SetActive(true);
        txtItemName.text = btnItems[index].itemName.text;
        txtItemPrice.text = btnItems[index].itemPrice.text;
        txtItemCount.text = curCount.ToString();
        int totalprice = curCount * price;
        txtTotalPrice.text = totalprice.ToString();
        imgItemName.sprite = btnItems[index].imgItem.sprite;
    }

    private void OnClickPlusItemCount()
    {
        if(curCount>0)
        {
            curCount++;
            SetItemBuy();
        }
    }

    private void OnClickMinusItemCount()
    {
        if (curCount > 1)
        { 
            curCount--;
            SetItemBuy();
        }
    }

    private void SetItemBuy()
    {
        int price = int.Parse(txtItemPrice.text);
        txtItemCount.text = curCount.ToString();
        int totalprice = curCount * price;
        txtTotalPrice.text = totalprice.ToString();
    }

    private void ShowItemList(int i)
    {
        int idx = i;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground Grey3");
        btnItemKinds[curItemKind].image.color = new Color32(180, 180, 180, 160);
        curItemKind = idx;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground LightGrey3");
        btnItemKinds[curItemKind].image.color = Color.white;
        if (btnItems.Count > 0)
        {
            for (int d = 0; d < btnItems.Count; d++)
            {
                Destroy(btnItems[d].gameObject);
            }
            btnItems.Clear();
        }
        GetItemList(curItemKind);

    }

    public void SpriteChange()
    {
        for(int i = 0; i<btnItemKinds.Length; i++)
        {
            int idx = i;
            btnItemKinds[idx].image.sprite = Resources.Load<Sprite>("UIBackground Grey1");
        }
        
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground LightGrey1");
    }

    private void OnClickBuy()
    {
        var uiinventory = uimanager.GetUI("UIInventory").GetComponent<UIInventory>();
        var ob = Resources.Load<BtnInvenItem>("UI/btnInvenItem");
        var boughtItem = Instantiate(ob);
        boughtItem.itemName = txtItemName.text;
        boughtItem.imgItem.sprite = Resources.Load<Sprite>($"Image/Item/{boughtItem.itemName}");
        boughtItem.transform.SetParent(uiinventory.ItemGrid.transform);


    }

    private void GetItemList(int index)
    {
        if(index<=1)
        {
            imgItemReady.gameObject.SetActive(false);
            switch (index)
            {
                case 0:
                    var seeds = itemmanager.seedItemData;
                    for (int i = 0; i < seeds.Length; i++)
                    {
                        var ob = Resources.Load<BtnItem>("UI/btnItem");
                        var itemData = Instantiate(ob);
                        itemData.itemName.text = seeds[i].Itemname;
                        itemData.itemPrice.text = seeds[i].ItemPrice.ToString();
                        itemData.imgItem.sprite = Resources.Load<Sprite>($"Image/Item/{itemData.itemName.text}");
                        itemData.transform.SetParent(content.transform);
                        btnItems.Add(itemData);
                    }
                    break;
                case 1:
                    var tools = itemmanager.toolItemData;
                    for (int i = 0; i < tools.Length; i++)
                    {
                        var ob = Resources.Load<BtnItem>("UI/btnItem");
                        var itemData = Instantiate(ob);
                        itemData.itemName.text = tools[i].Itemname;
                        itemData.itemPrice.text = tools[i].ItemPrice.ToString();
                        itemData.imgItem.sprite = Resources.Load<Sprite>($"Image/Item/{itemData.itemName.text}");
                        itemData.transform.SetParent(content.transform);
                        btnItems.Add(itemData);
                    }
                    break;
            }
        }
        else
        {
            imgItemReady.gameObject.SetActive(true);
        }

        BtnItemsSetting();
    }

}
