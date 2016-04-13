using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* 
    Changes text on the item description box when selecting
    different items.

*/

public class ChangeItemText : MonoBehaviour,  ISelectHandler {

	Text itemName;
	Text itemDescription;
	public static int slot;
	Image HotKey1; //test
	string spriteString;


    /* If slot is not empty, replace the text according to the item */
    public void OnSelect (BaseEventData eventData) 
	{
		slot = int.Parse (this.name);
		slot--;
		itemName = GameObject.Find ("Item Name").GetComponent<Text> ();
		itemDescription = GameObject.Find ("Item Description").GetComponent<Text> ();

		if (ItemDB.inventoryItemsArray[slot] != null) {
			itemName.text = ItemDB.inventoryItemsArray [slot].itemName;

			itemDescription.text = ItemDB.inventoryItemsArray [slot].itemDescription;
		} else {
			itemName.text = "";
			itemDescription.text = "";
		}

		Debug.Log ("Slot Selected : " + slot);
	}
}
