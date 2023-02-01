using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnInvenItem : MonoBehaviour
{

    public Image imgItem;
    public Text txtItemCount;
    public string itemName;
    public int itemCount;
    public int itemPrice;
    public string itemInfo;
    public string itemType;
    bool isClicked;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ShowItemInfo);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowItemInfo()
    {
        var uiinventory = UIManager.GetInstance().GetUI("UIInventory").GetComponent<UIInventory>();
        uiinventory.txtItemName.text = itemName;
        uiinventory.txtItemTooltip.text = itemInfo;   
    }
}
