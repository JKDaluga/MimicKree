using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

    public CursorManager cursor;

	// Use this for initialization
	void Start () {
        cursor = FindObjectOfType<CursorManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            cursor.dropItem();
        }
    }
}
