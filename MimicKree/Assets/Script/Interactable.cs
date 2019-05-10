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
    protected EventManager em;
    protected GameManager gm;
    public bool DestoryOnceUsed;
    public bool visualOnly;
    public bool grabOnly;
    public bool destroyScript;
    protected Player player;
    protected CursorManager cursor;
    private Item item;

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
        else if(grabOnly) cursor.changeCursor("GrabIcon");
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
                item = cursor.dropItem();
                if (wrongItemDialogue != null || item != null)
                {
                    StartCoroutine("waitForWrongDialogue");
                }
            }
        }
    }

    private void OnMouseExit()
    {
        if(cursor != null)
        {
            cursor.changeCursor("");
        }
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
            if(destroyScript)
            {
                Destroy(this);
            }
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
            if (wrongItemDialogue != null) wrongItemDialogue.TriggerDialogue();
            else if (item != null)
            {
                item.triggerDialogue();
            }

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
