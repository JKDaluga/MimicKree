using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {
    public string eventType;
    public GameObject obj;
    public bool triggerOnce;
    public bool beenTriggered;
    public Event anotherEvent;

    public GameObject sceneOld;
    public GameObject sceneNew;

    public PathNode p1;
    public PathNode p2;
}
