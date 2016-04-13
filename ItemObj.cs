using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
   Blueprint used to create items

*/

[System.Serializable]
public class ItemObj  {

    private string name;
    private string description;
    private int id;
    private int power;
    private ItemType type;


    public enum ItemType
    {
        EQUIPMENT,
        WEAPON,
        CONSUMABLE,
        BOTTLE
    }

    public ItemObj(Dictionary<string, string> itemDictionary)
    {
        name = itemDictionary["Name"];
        id = int.Parse (itemDictionary["ID"]);
        type = (ItemType)System.Enum.Parse(typeof(ItemObj.ItemType), itemDictionary["Type"].ToString());
        power = int.Parse(itemDictionary["Power"]);
        description = itemDictionary["Description"];
    }

    public string itemName
    {
        get { return name; }
        set { name = value; }
    }

    public string itemDescription
    {
        get { return description; }
        set { description = value; }
    }

    public int itemID
    {
        get { return id; }
        set { id = value;  }
    }

    public int itemPower
    {
        get { return power; }
        set { id = value; }
    }

    public ItemType itemGetType()
    {
        return type;
    }



}
