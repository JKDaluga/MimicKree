using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Inventory : MonoBehaviour {
    public GameObject inventoryCanvas;
    public InventorySlot[] invSlots;
    private int slotNum = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleInventory()
    {
        inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);
    }

    public bool addItem(Item item)
    {
        foreach(InventorySlot inv in invSlots)
        {
            if(!inv.item.isInSlot)
            {
                inv.item.image.sprite = item.image.sprite;
                inv.item.itemName = item.itemName;
                inv.item.activate();
                return true;
            }
        }
        print("I don't have room for that");
        return false;
    }

    public bool removeItem(Item item)
    {
        foreach (InventorySlot inv in invSlots)
        {
            if (inv.item.isInSlot && inv.item.itemName.Equals(item.itemName))
            {
                inv.item.image.sprite = null;
                inv.item.itemName = "";
                inv.item.deactivate();
                return true;
            }
        }
        return false;
    }
}
