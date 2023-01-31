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
    [SerializeField] GameObject ItemGrid;
    [SerializeField] Text txtItemName;
    [SerializeField] Text txtItemTooltip;
    public List<BtnInvenItem> itemList = new List<BtnInvenItem>();


    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();
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
        int idx = i;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground Grey3");
        btnItemKinds[curItemKind].image.color = new Color32(180, 180, 180, 160);
        curItemKind = idx;
        btnItemKinds[curItemKind].image.sprite = Resources.Load<Sprite>("UIBackground/UIBackground LightGrey3");
        btnItemKinds[curItemKind].image.color = Color.white;
        if (itemList.Count > 0)
        {
            for (int d = 0; d < itemList.Count; d++)
            {
                Destroy(itemList[d].gameObject);
            }
            itemList.Clear();
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
