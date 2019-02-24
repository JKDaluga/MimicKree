﻿using System.Collections;
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
    public bool isInSlot;

    private void Start()
    {
        image = GetComponent<Image>();
        origPos = transform.position;
        if(isInSlot)
        {
            GetComponent<Image>().enabled = true;
        }
        else
        {
            GetComponent<Image>().enabled = false;
        }
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

    //used for pickin up items
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) == true && isInSlot && !isclicked)
        {
            isclicked = true;
        }
    }

    public void activate()
    {
        isInSlot = true;
        image.enabled = true;
    }

    public void deactivate()
    {
        isInSlot = false;
        image.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isclicked && Input.GetMouseButtonDown(0))
        {
            Interactable inter = collision.gameObject.GetComponent<Interactable>();
            if(inter != null)
            {
                if(inter.itemRequired == "" || inter.itemRequired == itemName)
                {
                    inter.triggerEvent();
                }
            }
        }
    }
}
