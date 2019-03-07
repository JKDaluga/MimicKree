﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour {

    private Image cursorImage;

    public Sprite defaultCursor;
    public Sprite movementCursor;
    public Sprite interactCursor;
    public Sprite dialogueCursor;
    public Sprite transitionCursor;


    // Use this for initialization
    void Start () {
        cursorImage = GetComponent<Image>();
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Input.mousePosition;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "MoveIcon":
                cursorImage.sprite = movementCursor;
                break;
            case "SceneChangeIcon":
                cursorImage.sprite = transitionCursor;
                break;
            case "DialogueIcon":
                cursorImage.sprite = dialogueCursor;
                break;
            case "InteractableIcon":
                cursorImage.sprite = interactCursor;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cursorImage.sprite = defaultCursor;
    }

    public void changeCursor(string icon)
    {
        switch (icon)
        {
            case "MoveIcon":
                cursorImage.sprite = movementCursor;
                break;
            case "SceneChangeIcon":
                cursorImage.sprite = transitionCursor;
                break;
            case "DialogueIcon":
                cursorImage.sprite = dialogueCursor;
                break;
            case "InteractableIcon":
                cursorImage.sprite = interactCursor;
                break;
            default:
                cursorImage.sprite = defaultCursor;
                break;
        }
    }
}