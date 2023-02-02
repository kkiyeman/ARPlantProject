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
    public Text txtItemName;
    public Text txtItemTooltip;
    public List<BtnInvenItem> seedItems = new List<BtnInvenItem>();
    public List<BtnInvenItem> toolItems = new List<BtnInvenItem>();
    public List<BtnInvenItem> nutItems = new List<BtnInvenItem>();



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
        SetPlayerData();
    }

    private void SetPlayerData()
    {
        txtCash.text = $"{gamemanager.curEnergy}/{gamemanager.totalEnergy}";
        txtGold.text = gamemanager.curGameMoney.ToString();
    }
    private void SetButton()
    {
        btnCloseInven.onClick.AddListener(OnClickCloseInven);
        BtnItemKindSet();
    }


    private void OnClickCloseInven()
    {
        AudioManager.GetInstance().PlaySfx("»Ð");
        gameObject.SetActive(false);
    }

    public void ShowItemList(int i)
    {
        AudioManager.GetInstance().PlaySfx("»Ð");
        int idx = i;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground Grey3");
        btnItemKinds[curItemKind].image.color = new Color32(180, 180, 180, 160);
        curItemKind = idx;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground LightGrey3");
        btnItemKinds[curItemKind].image.color = Color.white;


        switch (curItemKind)
        {
             case 0:
                for (int j = 0; j < seedItems.Count; j++)
                {
                     var item = seedItems[j];
                    item.gameObject.SetActive(true);
                }
                for(int k = 0; k< toolItems.Count; k++)
                {
                    var item2 = toolItems[k];
                    item2.gameObject.SetActive(false);
                }
                for(int m = 0; m<nutItems.Count; m++)
                {
                    var item3 = nutItems[m];
                    item3.gameObject.SetActive(false);
                }
                break;
            case 1:
                for (int j = 0; j < seedItems.Count; j++)
                {
                    var item = seedItems[j];
                    item.gameObject.SetActive(false);
                }
                for (int k = 0; k < toolItems.Count; k++)
                {
                    var item2 = toolItems[k];
                    item2.gameObject.SetActive(false);
                }
                for (int m = 0; m < nutItems.Count; m++)
                {
                    var item3 = nutItems[m];
                    item3.gameObject.SetActive(true);
                }
                break;
            case 2:
                for (int j = 0; j < seedItems.Count; j++)
                {
                    var item = seedItems[j];
                    item.gameObject.SetActive(false);
                }
                for (int k = 0; k < toolItems.Count; k++)
                {
                    var item2 = toolItems[k];
                    item2.gameObject.SetActive(true);
                }
                for (int m = 0; m < nutItems.Count; m++)
                {
                    var item3 = nutItems[m];
                    item3.gameObject.SetActive(false);
                }
                break;
            case 3:
                for (int j = 0; j < seedItems.Count; j++)
                {
                    var item = seedItems[j];
                    item.gameObject.SetActive(false);
                }
                for (int k = 0; k < toolItems.Count; k++)
                {
                    var item2 = toolItems[k];
                    item2.gameObject.SetActive(false);
                }
                for (int m = 0; m < nutItems.Count; m++)
                {
                    var item3 = nutItems[m];
                    item3.gameObject.SetActive(false);
                }
                break;
        }

        //if (btnInvenItems.Count > 0)
        //{
        //    for (int d = 0; d < btnInvenItems.Count; d++)
        //    {
        //        Destroy(btnInvenItems[d].gameObject);
        //    }
        //    btnInvenItems.Clear();
        //}

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
