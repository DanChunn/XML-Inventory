using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/*
    Assigns art and text relevant to the item in the inventory

*/

public class ItemManager : MonoBehaviour {

    GameObject[] buttonSlot;
    GameObject[] itemSlot;
    Image HotKey1; //test

    /* Loads data into the inventory at game start */
    void Start()
    {

        /* Inventory slots available to the player */
        GameObject[] itemSlot = new GameObject[9];
        GameObject[] buttonSlot = GameObject.FindGameObjectsWithTag("InventorySlotSprite"); //buttons from the GUI
        Array.Sort(buttonSlot, CompareObjNames);


        /* Loads sprites onto the inventory GUI from the resources folder */
        for (int i = 0; i < ItemDB.inventoryItemsArray.Length; i++)
        {

            if (ItemDB.inventoryItemsArray[i] != null)
            {
                string spriteString = "ItemSprite_" + ItemDB.inventoryItemsList[i].itemID;
                //Debug.Log ("sprite string : " + spriteString);
                Image oldSprite = buttonSlot[i].GetComponentInChildren<Image>();
                Sprite newSprite = Resources.Load<Sprite>(spriteString);
                oldSprite.sprite = newSprite;
            }

        }
    }


    void Update()
    {

        //TODO: To be used as a way to swap items from the hand to inventory...
        if (Input.GetButtonDown("HotKey1"))
        {

            if (ItemDB.inventoryItemsArray[ChangeItemText.slot] != null)
            {

                HotKey1 = GameObject.Find("Image_Up").GetComponent<Image>();

                string spriteString = "ItemSprite_" + ItemDB.inventoryItemsList[ChangeItemText.slot].itemID;
                HotKey1.sprite = Resources.Load<Sprite>(spriteString);

            }
        }
    }

    /* Compares names of objects */
    int CompareObjNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

}
