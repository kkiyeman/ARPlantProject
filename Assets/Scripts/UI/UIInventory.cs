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

    private void ShowItemList(int i)
    {
        List<BtnInvenItem> itemlist = new List<BtnInvenItem>();
        int idx = i;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground Grey3");
        btnItemKinds[curItemKind].image.color = new Color32(180, 180, 180, 160);
        curItemKind = idx;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground LightGrey3");
        btnItemKinds[curItemKind].image.color = Color.white;
        if (curItemKind == 0)
            itemlist = itemmanager.seedItemList;
        else if (curItemKind == 2)
            itemlist = itemmanager.toolItemList;
        if (itemlist.Count > 0)
        {
            for (int d = 0; d < itemlist.Count; d++)
            {
                Destroy(itemlist[d].gameObject);
            }
            itemlist.Clear();
        }
        else
        {

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
