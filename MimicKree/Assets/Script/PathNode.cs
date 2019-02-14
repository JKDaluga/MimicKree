using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode: MonoBehaviour {
    public PathNode[] neighbors;
    public List<PathNode> history;
    private GameManager gm;
    public Event triggeredevent;
    private EventManager em;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        em = FindObjectOfType<EventManager>();
    }

    public void walk()
    {
        gm.walk(this);
    }

    public void triggerEvent()
    {
        if(!triggeredevent.triggerOnce || !triggeredevent.beenTriggered)
        {
            em.triggerEvent(triggeredevent);
            triggeredevent.beenTriggered = true;
        }
        if(triggeredevent.anotherEvent != null)
        {
            triggerEvent(triggeredevent.anotherEvent);
        }
    }

    private void triggerEvent(Event e)
    {
        print("thing");
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
}
