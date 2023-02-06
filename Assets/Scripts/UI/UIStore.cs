using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// <summary>
    /// 플레이어의 데이터를 표시해주는 함수
    /// </summary>
    private void SetPlayerData()
    {
        txtEnergy.text = $"{gamemanager.curEnergy}/{gamemanager.totalEnergy}";
        txtGold.text = gamemanager.curGameMoney.ToString();
    }
    /// <summary>
    /// 온클릭 함수를 넣어주는 기능
    /// </summary>
    private void ButtonSetting()
    {
        btnCloseStore.onClick.AddListener(OnClickCloseStore);
        btnCloseBuy.onClick.AddListener(OnClickCloseBuy);
        btnItemCountPlus.onClick.AddListener(OnClickPlusItemCount);
        btnItemCountMinus.onClick.AddListener(OnClickMinusItemCount);
        btnItemBuy.onClick.AddListener(OnClickBuy);
        BtnItemKindSet();
    }


    /// <summary>
    /// 상점 닫으면서 BGM 랜덤변경
    /// </summary>
    private void OnClickCloseStore()
    {
        int i = Random.Range(1, 4);
        AudioManager.GetInstance().PlayBgm($"Plant{i}");
        AudioManager.GetInstance().PlaySfx("뿅");
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 구매창 끄는 버튼
    /// </summary>
    private void OnClickCloseBuy()
    {
        curCount = 1;
        SetItemBuy();
        imgItemBuy.gameObject.SetActive(false);
        AudioManager.GetInstance().PlaySfx("뿅");
    }
    /// <summary>
    /// 아이템에 온클릭을 달아주는 함수
    /// </summary>
    private void BtnItemsSetting()
    {
        for (int i = 0; i < btnItems.Count; i++)
        {
            int idx = i;
            Button btn = btnItems[idx].GetComponent<Button>();
            btn.onClick.AddListener(() => { OnClickOpenBuy(idx); });
        }
    }

    /// <summary>
    /// 버튼 아이템 종류를 정해주는 함수
    /// </summary>
    private void BtnItemKindSet()
    {
        for (int i = 0; i < btnItemKinds.Length; i++)
        {
            int idx = i;
            btnItemKinds[idx].onClick.AddListener(() => { ShowItemList(idx); });
        }
    }
    /// <summary>
    /// 구매창이 뜨게 하고 인덱스에 맞는 정보를 넣어주는 함수
    /// </summary>
    /// <param name="index"></param>
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
        AudioManager.GetInstance().PlaySfx("뿅");
    }
    /// <summary>
    /// 카운트 업
    /// </summary>
    private void OnClickPlusItemCount()
    {
        if (curCount > 0)
        {
            curCount++;
            SetItemBuy();
            AudioManager.GetInstance().PlaySfx("뿅");
        }
    }
    /// <summary>
    /// 카운트 다운
    /// </summary>
    private void OnClickMinusItemCount()
    {
        if (curCount > 1)
        {
            curCount--;
            SetItemBuy();
            AudioManager.GetInstance().PlaySfx("뿅");
        }
    }
    /// <summary>
    /// 구매창 안에 가격 계산 문자로 출력
    /// </summary>
    private void SetItemBuy()
    {
        int price = int.Parse(txtItemPrice.text);
        txtItemCount.text = curCount.ToString();
        int totalprice = curCount * price;
        txtTotalPrice.text = totalprice.ToString();
    }
    /// <summary>
    /// 왼쪽탭 선택시 색깔변경, 스프라이트 변경, 포문으로 아이템 제거 / 리스트 제거
    /// </summary>
    /// <param name="i"></param>
    private void ShowItemList(int i)
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        int idx = i;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground Grey3");
        btnItemKinds[curItemKind].image.color = new Color32(180, 180, 180, 160);
        txtItemKinds[curItemKind].color = new Color32(50, 50, 50, 100);
        curItemKind = idx;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground LightGrey3");
        btnItemKinds[curItemKind].image.color = Color.white;
        txtItemKinds[curItemKind].color = new Color32(50, 50, 50, 255);
        if (btnItems.Count > 0) // 1개라도 있으면 전부 삭제하고 리스트 초기화
        {
            for (int d = 0; d < btnItems.Count; d++)
            {
                Destroy(btnItems[d].gameObject);
            }
            btnItems.Clear();
        }
        GetItemList(curItemKind); // 다시 채워준다.

    }
    /// <summary>
    /// 안쓴 함수 배경 변경
    /// </summary>
    public void SpriteChange()
    {
        for (int i = 0; i < btnItemKinds.Length; i++)
        {
            int idx = i;
            btnItemKinds[idx].image.sprite = Resources.Load<Sprite>("UIBackground Grey1");
        }

        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground LightGrey1");
    }
    /// <summary>
    /// 구매조건과 종류에 따라 구매시 인벤으로 들어감
    /// </summary>
    private void OnClickBuy()
    {
        if (gamemanager.curGameMoney - int.Parse(txtTotalPrice.text) >= 0)
            gamemanager.curGameMoney -= int.Parse(txtTotalPrice.text);
        else
        {
            Debug.Log("돈 부족!!");
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
        if (item.itemType == "씨앗")
        {
            uiinventory.seedItems.Add(item);
        }
        else if (item.itemType == "도구")
        {
            uiinventory.toolItems.Add(item);
        }
        else if (item.itemType == "영양제")
        {
            uiinventory.nutItems.Add(item);
        }
        
        AudioManager.GetInstance().PlaySfx("Money");


    }
    /// <summary>
    /// 아이템리스트를 index에 맞게 가져오는 함수
    /// 여기서 인덱스는 아이템 왼쪽 종류 탭
    /// 탭에 맞춰 아이템 리스트를 가져가도록
    /// </summary>
    /// <param name="index"></param>
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
                        itemData.transform.SetParent(content.transform);
                        itemData.itemName.text = seeds[i].Itemname;
                        itemData.itemPrice.text = seeds[i].ItemPrice.ToString();
                        itemData.itemKind = seeds[i].ItemType;
                        itemData.itemInfo = seeds[i].ItemInfo;
                        itemData.imgItem.sprite = Resources.Load<Sprite>($"Image/Item/{itemData.itemName.text}");
                        btnItems.Add(itemData);
                    }
                    break;
                case 1:
                    var tools = itemmanager.toolItemData;
                    for (int i = 0; i < tools.Length; i++)
                    {
                        var ob = Resources.Load<BtnItem>("UI/btnItem");
                        var itemData = Instantiate(ob);
                        itemData.transform.SetParent(content.transform);
                        itemData.itemName.text = tools[i].Itemname;
                        itemData.itemPrice.text = tools[i].ItemPrice.ToString();
                        itemData.itemKind = tools[i].ItemType;
                        itemData.itemInfo = tools[i].ItemInfo;
                        itemData.imgItem.sprite = Resources.Load<Sprite>($"Image/Item/{itemData.itemName.text}");
                        btnItems.Add(itemData);
                    }
                    break;
                case 2:

                        imgItemReady.gameObject.SetActive(true);
                    
                    break;
                case 3:
                    var nuts = itemmanager.nutItemData;
                    for (int i = 0; i < nuts.Length; i++)
                    {
                        var ob = Resources.Load<BtnItem>("UI/btnItem");
                        var itemData = Instantiate(ob);
                        itemData.transform.SetParent(content.transform);
                        itemData.itemName.text = nuts[i].Itemname;
                        itemData.itemPrice.text = nuts[i].ItemPrice.ToString();
                        itemData.itemKind = nuts[i].ItemType;
                        itemData.itemInfo = nuts[i].ItemInfo;
                        itemData.imgItem.sprite = Resources.Load<Sprite>($"Image/Item/{itemData.itemName.text}");
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
