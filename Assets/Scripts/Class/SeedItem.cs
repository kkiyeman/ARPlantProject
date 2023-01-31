using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedItem : ItemBase
{

    public SeedItem(string itemName, string itemType, int itemPrice, string itemInfo)
    {
        this.Itemname = itemName;
        this.ItemType = itemType;
        this.ItemPrice = itemPrice;
        this.ItemInfo = itemInfo;
    }

    public override void UseItem()
    {
        
    }
}
