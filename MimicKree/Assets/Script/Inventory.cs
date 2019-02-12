using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public GameObject inventoryCanvas;
    public List<InventorySlot> invSlots = new List<InventorySlot>();
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

    public void addItem()
    {
        if(slotNum < invSlots.Count)
        {
            //invSlots[slotNum] = 
            slotNum++;
        }
    }

    public void removeItem()
    {

    }
}
