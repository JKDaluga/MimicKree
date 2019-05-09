using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public PathNode location;
    public bool isActivated;
    //public bool isRepeatable;
    public string itemRequired;
    public DialogueTrigger wrongItemDialogue;
    public Event triggeredevent;
    private EventManager em;
    private GameManager gm;
    public bool DestoryOnceUsed;
    public bool visualOnly;
    private Player player;
    private CursorManager cursor;

    // Use this for initialization
    void Start () {
        em = FindObjectOfType<EventManager>();
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        cursor = FindObjectOfType<CursorManager>();
    }

    public virtual void triggerEvent()
    {
        if (!triggeredevent.triggerOnce || !triggeredevent.beenTriggered)
        {
            em.triggerEvent(triggeredevent);
            triggeredevent.beenTriggered = true;
        }
        if (triggeredevent.anotherEvent != null)
        {
            triggerEvent(triggeredevent.anotherEvent);
        }
    }

    protected void triggerEvent(Event e)
    {
        if (!e.triggerOnce || !e.beenTriggered)
        {
            em.triggerEvent(e);
            e.beenTriggered = true;
        }
        if (e.anotherEvent != null)
        {
            triggerEvent(e.anotherEvent);
        }
    }

    private void OnMouseEnter()
    {
        if(visualOnly) cursor.changeCursor("EyeIcon");
        else cursor.changeCursor("InteractableIcon");
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            walk();
            if(isValidItem(cursor.getItemID()))
            {
                StartCoroutine("waitForTrigger");
                cursor.dropItem();
            }
            else
            {
                cursor.dropItem();
                if (wrongItemDialogue != null && player.selectedItem == false)
                {
                    StartCoroutine("waitForWrongDialogue");
                    
                }
            }
        }
    }

    private void OnMouseExit()
    {
        cursor.changeCursor("");
    }

    IEnumerator waitForTrigger()
    {
        Player p = FindObjectOfType<Player>();
        while(p.walking)
        {
            yield return null;
        }
        if (p.location == location)
        {
            triggerEvent();
            if (DestoryOnceUsed)
            {
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator waitForWrongDialogue()
    {
        Player p = FindObjectOfType<Player>();
        while (p.walking)
        {
            yield return null;
        }
        if (p.location == location)
        {
            wrongItemDialogue.TriggerDialogue();
        }
    }

    public void walk()
    {
        if(location != FindObjectOfType<Player>().location)
        {
            gm.walk(location);
        }
    }

    public bool isValidItem(string item)
    {
        if (item.Equals(itemRequired)) return true;
        return false;
    }
}
