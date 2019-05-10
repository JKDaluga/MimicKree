using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item : MonoBehaviour {
    public Vector3 origPos;
    public Image image;
    private BoxCollider2D boxCol;
    public string itemName;
    private bool isclicked = false;
    private Vector3 mousePosition;
    public bool isInSlot;
    private bool onInteractable;
    public string InvalidDialogue;
    private DialogueTrigger dt;

    private Player player;
    private CursorManager cursor;

    public string tooltipText;

    private void Start()
    {
        image = GetComponent<Image>();
        origPos = transform.position;
        player = FindObjectOfType<Player>();
        cursor = FindObjectOfType<CursorManager>();
        boxCol = GetComponent<BoxCollider2D>();
        dt = GameObject.FindGameObjectWithTag("IndivDialogueThing").GetComponent<DialogueTrigger>();
        if (isInSlot)
        {
            GetComponent<Image>().enabled = true;
            if(boxCol != null)
            {
                boxCol.enabled = true;
            }
        }
        else
        {
            GetComponent<Image>().enabled = false;
            if (boxCol != null)
            {
                boxCol.enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {

    }

    //used for pickin up items
    void OnMouseOver()
    {
        tooltip();
        if (Input.GetMouseButtonDown(0) == true && isInSlot && !isclicked)
        {
            pickUp();
        }
    }

    private void OnMouseExit()
    {
        offTooltip();
    }

    public void activate()
    {
        isInSlot = true;
        image.enabled = true;
        if (boxCol != null)
        {
            boxCol.enabled = true;
        }
    }

    public void deactivate()
    {
        isInSlot = false;
        image.enabled = false;
        if (boxCol != null)
        {
            boxCol.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isclicked && Input.GetMouseButtonDown(0))
        {
            Interactable inter = collision.gameObject.GetComponent<Interactable>();
            if(inter != null)
            {
                if(inter.itemRequired == itemName)
                {
                    isclicked = false;
                    Invoke("deselectItem", .1f);
                    transform.position = origPos;
                    inter.walk();
                    inter.StartCoroutine("waitForTrigger");
                }
                else
                {
                    if(inter.wrongItemDialogue != null)
                    {
                        inter.wrongItemDialogue.TriggerDialogue();
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("dialoguething").GetComponent<DialogueTrigger>().TriggerDialogue();
                    }
                    isclicked = false;
                    Invoke("deselectItem", .1f);
                    transform.position = origPos;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Interactable>() != null)
        {
            onInteractable = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Interactable>() != null)
        {
            onInteractable = false;
        }
    }

    private void deselectItem()
    {
        player.selectedItem = false;
    }

    public void pickUp()
    {
        cursor.pickUpItem(this);
    }

    public void tooltip()
    {
        cursor.turnOnTooltip(tooltipText);
    }

    public void offTooltip()
    {
        cursor.turnOffTooltip();
    }

    public void triggerDialogue()
    {
        dt.dialogue.dialogues[0] = InvalidDialogue;
        dt.TriggerDialogue();
    }
}
