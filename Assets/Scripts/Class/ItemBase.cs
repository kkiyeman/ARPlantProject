using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase 
{
    public string Itemname { get; set; }
    public string ItemType { get; set; }
    public int ItemPrice { get; set; }



    public abstract void UseItem();

    public ItemData Clone()
    {
        var itemdata = new ItemData();
        itemdata.itemName = Itemname;
        itemdata.itemType = ItemType;
        itemdata.itemPrice = ItemPrice;

        return itemdata;
    }
}
