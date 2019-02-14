using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item : MonoBehaviour {
    public Vector3 origPos;
    public Image image;
    public string itemName;
    private bool isclicked = false;
    private Vector3 mousePosition;

    private void Start()
    {
        origPos = transform.position;
    }

    private void Update()
    {
        if (isclicked)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y,0);
            
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            isclicked = !isclicked;
            if(isclicked == false)
            {
                transform.position = origPos;
            }
        }
    }
}
