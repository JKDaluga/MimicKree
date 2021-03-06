﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Inventory : MonoBehaviour {
    public GameObject inventoryCanvas;
    public InventorySlot[] invSlots;

    public CursorManager cursor;

	// Use this for initialization
	void Start () {
        cursor = FindObjectOfType<CursorManager>();
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
                inv.item.tooltipText = item.tooltipText;
                inv.item.InvalidDialogue = item.InvalidDialogue;
                inv.item.activate();
                return true;
            }
        }
        return false;
    }

    public bool removeItem(Item item)
    {
        foreach (InventorySlot inv in invSlots)
        {
            if (inv.item != null && inv.item.isInSlot && inv.item.itemName.Equals(item.itemName))
            {
                inv.item.image.sprite = null;
                inv.item.itemName = "";
                inv.item.deactivate();
                return true;
            }
        }
        return false;
    }

    public bool contains(string itemName)
    {
        foreach (InventorySlot inv in invSlots)
        {
            if (inv.item != null && inv.item.isInSlot && inv.item.itemName.Equals(itemName))
            {
                return true;
            }
        }
        return false;
    }

    public void turnOnInv()
    {
        inventoryCanvas.SetActive(true);
    }

    public void turnOffInv()
    {
        inventoryCanvas.SetActive(false);
        cursor.dropItem();
    }
}
