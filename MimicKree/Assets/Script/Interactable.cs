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
    private Component halo;
    public bool DestoryOnceUsed;

    // Use this for initialization
    void Start () {
        em = FindObjectOfType<EventManager>();
        gm = FindObjectOfType<GameManager>();
        halo = GetComponent("Halo");
        halo.GetComponent<Renderer>().sortingLayerName = "SceneItems";
        halo.GetComponent<Renderer>().sortingOrder = 2;
    }

    public void triggerEvent()
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

    private void triggerEvent(Event e)
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
        FindObjectOfType<CursorManager>().changeCursor("InteractableIcon");
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
        gm.walk(location);
    }
}
