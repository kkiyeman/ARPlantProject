using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolItem : ItemBase
{
    public ToolItem(string itemName, string itemType, int itemPrice)
    {
        this.Itemname = itemName;
        this.ItemType = itemType;
        this.ItemPrice = itemPrice;
    }

    public override void UseItem()
    {

    }
}
