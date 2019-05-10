using System.Collections;
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
    public Sprite EyeCursor;
    public Sprite GrabCursor;

    public Image itemImage;
    private Item item;
    private string itemID = "";

    public GameObject tooltip;
    public Text tooltipText;

    // Use this for initialization
    void Start () {
        cursorImage = GetComponent<Image>();
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Input.mousePosition;
        if(Input.GetMouseButtonDown(1))
        {
            dropItem();
        }
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
            case "EyeIcon":
                cursorImage.sprite = EyeCursor;
                break;
            case "GrabIcon":
                cursorImage.sprite = GrabCursor;
                break;
            default:
                cursorImage.sprite = defaultCursor;
                break;
        }
    }

    public void pickUpItem(Item itemPickedUp)
    {
        if (item != null) dropItem();
        item = itemPickedUp;
        item.gameObject.SetActive(false);
        itemImage.sprite = itemPickedUp.image.sprite;
        itemImage.gameObject.SetActive(true);
        itemID = itemPickedUp.itemName;
        turnOffTooltip();
    }

    public Item dropItem()
    {
        itemID = "";
        if(item != null)
        {
            itemImage.gameObject.SetActive(false);
            item.gameObject.SetActive(true);
            Item temp = item;
            item = null;
            return temp;
        }
        return null;
    }

    public string getItemID()
    {
        return itemID;
    }

    public void turnOnTooltip(string tip)
    {
        if (item == null)
        {
            tooltipText.text = tip;
            tooltip.SetActive(true);
        }
    }

    public void turnOffTooltip()
    {
        tooltip.SetActive(false);
    }

    public void InvalidDialogue()
    {
        item.triggerDialogue();
    }
}
