using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedItem : ItemBase
{

    public SeedItem(string itemName, string itemType, int itemPrice)
    {
        this.Itemname = itemName;
        this.ItemType = itemType;
        this.ItemPrice = itemPrice;
    }

    public override void UseItem()
    {
        
    }
}
