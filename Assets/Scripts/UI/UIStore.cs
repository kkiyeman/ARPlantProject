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
    [SerializeField] Button[] btnItems;
    [SerializeField] Text[] txtItems;
    [SerializeField] Text[] txtItemPrices;

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

    void Start()
    {
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();

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
        BtnItemsSetting();
        BtnItemKindSet();
    }



    private void OnClickCloseStore()
    {
        gameObject.SetActive(false);
    }

    private void OnClickCloseBuy()
    {
        imgItemBuy.gameObject.SetActive(false);
    }

    private void BtnItemsSetting()
    {
        for (int i = 0; i < btnItems.Length; i++)
        {
            int idx = i;
            btnItems[idx].onClick.AddListener(() => { OnClickOpenBuy(idx); });
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
        imgItemBuy.gameObject.SetActive(true);
        txtItemName.text = txtItems[index].text;
        txtItemPrice.text = txtItemPrices[index].text;
    }

    private void ShowItemList(int i)
    {
        int idx = i;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground Grey3");
        btnItemKinds[curItemKind].image.color = new Color32(180, 180, 180, 160);
        curItemKind = idx;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground LightGrey3");
        btnItemKinds[curItemKind].image.color = Color.white;

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
}
