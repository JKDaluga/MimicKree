using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarSection : MonoBehaviour {

    private CursorManager cursor;

	// Use this for initialization
	void Start () {
        cursor = FindObjectOfType<CursorManager>();
	}

    private void OnMouseOver()
    {
        cursor.changeCursor("GrabIcon");
    }

    private void OnMouseExit()
    {
        cursor.changeCursor("");
    }
}
