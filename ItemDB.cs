using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

/* 
    Script used to extract items from an XML file and
    stores it into a data structure.

*/

public class ItemDB : MonoBehaviour {

    /* Public data structures used for access.
       Array refers to our in-game inventory (used for testing). */
    public static List<ItemObj> inventoryItemsList = new List<ItemObj>();
    public static ItemObj[] inventoryItemsArray = new ItemObj[9];

    /* XML document containing XML nodes */
    public TextAsset itemsXML;
    
    /* List of dictionaries representing item nodes */
    List<Dictionary<string, string>> listOfItemDictionary = new List<Dictionary<string, string>>();
    Dictionary<string, string> itemDictionary;

    
    /* Before the game starts, extract from the XML and store it into our data structures */
    void Awake()
    {
        ExtractFromXML();

        for (int i = 0; i < listOfItemDictionary.Count; i++)
        {
            inventoryItemsList.Add(new ItemObj(listOfItemDictionary[i]));
            inventoryItemsArray[i] = (new ItemObj(listOfItemDictionary[i]));
        }
               

    }

    /* Extracts data from an XML and stores it into a list of dictionaries/items */
    public void ExtractFromXML()
    {
        /* Open XML document and get all Items and store them into a XMLNodeList */
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(itemsXML.text);
        XmlNodeList itemsInXML = doc.GetElementsByTagName("Item");

        /* Goes through each node and extracts data */
        foreach(XmlNode itemNode in itemsInXML)
        {
            XmlNodeList itemData = itemNode.ChildNodes;
            itemDictionary = new Dictionary<string, string>();

            foreach (XmlNode dataNode in itemData)
            {
                switch (dataNode.Name)
                {
                    case "Name":
                        itemDictionary.Add("Name", dataNode.InnerText);
                        break;
                    case "ID":
                        itemDictionary.Add("ID", dataNode.InnerText);
                        break;
                    case "Type":
                        itemDictionary.Add("Type", dataNode.InnerText);
                        break;
                    case "Power":
                        itemDictionary.Add("Power", dataNode.InnerText);
                        break;
                    case "Description":
                        itemDictionary.Add("Description", dataNode.InnerText);
                        break;

                }
            }

            listOfItemDictionary.Add(itemDictionary);
        }


    }


}
