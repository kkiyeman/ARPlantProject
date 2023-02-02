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
    public GameObject itemPool;

    [Header("Item Buy PopUp")]
    [SerializeField] Image imgItemBuy;
    [SerializeField] Button btnCloseBuy;
    [SerializeField] Image imgItemName;
    [SerializeField] Text txtItemName;
    [SerializeField] Text txtItemPrice;
    [SerializeField] Text txtItemCount;
    string buyingitemKind;
    string buyingitemInfo;
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
        AudioManager.GetInstance().PlayBgm("Store");
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
        SetPlayerData();
    }

    private void SetPlayerData()
    {
        txtEnergy.text = $"{gamemanager.curEnergy}/{gamemanager.totalEnergy}";
        txtGold.text = gamemanager.curGameMoney.ToString();
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
        AudioManager.GetInstance().PlayBgm("Plant2");
        AudioManager.GetInstance().PlaySfx("»Ð");
        gameObject.SetActive(false);
    }

    private void OnClickCloseBuy()
    {
        curCount = 1;
        SetItemBuy();
        imgItemBuy.gameObject.SetActive(false);
        AudioManager.GetInstance().PlaySfx("»Ð");
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
        for (int i = 0; i < btnItemKinds.Length; i++)
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
        buyingitemKind = btnItems[index].itemKind;
        buyingitemInfo = btnItems[index].itemInfo;
        int totalprice = curCount * price;
        txtTotalPrice.text = totalprice.ToString();
        imgItemName.sprite = btnItems[index].imgItem.sprite;
        AudioManager.GetInstance().PlaySfx("»Ð");
    }

    private void OnClickPlusItemCount()
    {
        if (curCount > 0)
        {
            curCount++;
            SetItemBuy();
            AudioManager.GetInstance().PlaySfx("»Ð");
        }
    }

    private void OnClickMinusItemCount()
    {
        if (curCount > 1)
        {
            curCount--;
            SetItemBuy();
            AudioManager.GetInstance().PlaySfx("»Ð");
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
        AudioManager.GetInstance().PlaySfx("»Ð");
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
        for (int i = 0; i < btnItemKinds.Length; i++)
        {
            int idx = i;
            btnItemKinds[idx].image.sprite = Resources.Load<Sprite>("UIBackground Grey1");
        }

        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground LightGrey1");
    }

    private void OnClickBuy()
    {
        if (gamemanager.curGameMoney - int.Parse(txtTotalPrice.text) >= 0)
            gamemanager.curGameMoney -= int.Parse(txtTotalPrice.text);
        else
        {
            Debug.Log("µ· ºÎÁ·!!");
            return;
        }
        var uiinventory = uimanager.GetUI("UIInventory").GetComponent<UIInventory>();
        var ob = Resources.Load<BtnInvenItem>("UI/btnInvenItem");
        var item = Instantiate(ob);
        item.itemName = txtItemName.text;
        item.itemPrice = int.Parse(txtItemPrice.text);
        item.itemCount = int.Parse(txtItemCount.text);
        item.txtItemCount.text = txtItemCount.text;
        item.itemInfo = buyingitemInfo;
        item.itemType = buyingitemKind;
        item.imgItem.sprite = Resources.Load<Sprite>($"Image/Item/{item.itemName}");
        item.transform.SetParent(uiinventory.ItemGrid.transform);
        if (item.itemType == "¾¾¾Ñ")
        {
            uiinventory.seedItems.Add(item);
        }
        else if (item.itemType == "µµ±¸")
        {
            uiinventory.toolItems.Add(item);
        }
        else if (item.itemType == "¿µ¾çÁ¦")
        {
            uiinventory.nutItems.Add(item);
        }
        
        AudioManager.GetInstance().PlaySfx("Buy2");


    }

    private void GetItemList(int index)
    {
        if (index <= 3)
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
                        itemData.itemKind = seeds[i].ItemType;
                        itemData.itemInfo = seeds[i].ItemInfo;
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
                        itemData.itemKind = tools[i].ItemType;
                        itemData.itemInfo = tools[i].ItemInfo;
                        itemData.imgItem.sprite = Resources.Load<Sprite>($"Image/Item/{itemData.itemName.text}");
                        itemData.transform.SetParent(content.transform);
                        btnItems.Add(itemData);
                    }
                    break;
                case 3:
                    var nuts = itemmanager.nutItemData;
                    for (int i = 0; i < nuts.Length; i++)
                    {
                        var ob = Resources.Load<BtnItem>("UI/btnItem");
                        var itemData = Instantiate(ob);
                        itemData.itemName.text = nuts[i].Itemname;
                        itemData.itemPrice.text = nuts[i].ItemPrice.ToString();
                        itemData.itemKind = nuts[i].ItemType;
                        itemData.itemInfo = nuts[i].ItemInfo;
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
