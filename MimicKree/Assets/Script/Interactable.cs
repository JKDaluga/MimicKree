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
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }

    private void OnMouseExit()
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }
}
