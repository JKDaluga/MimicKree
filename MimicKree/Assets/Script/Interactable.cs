using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public PathNode location;
    public bool isActivated;
    //public bool isRepeatable;
    public string itemRequired;
    public Event triggeredevent;
    private EventManager em;
    private GameManager gm;
    public bool DestoryOnceUsed;
    public bool visualOnly;

    // Use this for initialization
    void Start () {
        em = FindObjectOfType<EventManager>();
        gm = FindObjectOfType<GameManager>();
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
        if(visualOnly) FindObjectOfType<CursorManager>().changeCursor("EyeIcon");
        else FindObjectOfType<CursorManager>().changeCursor("InteractableIcon");
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            walk();
            if(itemRequired == "")
            {
                StartCoroutine("waitForTrigger");
            }
        }
    }

    private void OnMouseExit()
    {
        FindObjectOfType<CursorManager>().changeCursor("");
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

    public void walk()
    {
        if(location != FindObjectOfType<Player>().location)
        {
            print("or this");
            gm.walk(location);
        }
        else
        {
            print("this");
        }
        
        
    }
}
