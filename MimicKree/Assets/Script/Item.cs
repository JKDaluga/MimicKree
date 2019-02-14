using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item : MonoBehaviour {
    public Image image;
    public string itemName;
    private bool isclicked;
    private Vector3 mousePosition;

    private void Update()
    {
        if (isclicked)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) == true)
        {
            
        }
    }
}
