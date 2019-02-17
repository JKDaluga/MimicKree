using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Inventory : MonoBehaviour {
    public GameObject inventoryCanvas;
    public InventorySlot[] invSlots;
    public Sprite lockpick;
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
        if(slotNum < invSlots.Length)
        {
            //invSlots[slotNum] = 
            slotNum++;
        }
    }

    public void removeItem()
    {

    }
}
