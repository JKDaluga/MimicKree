using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {
    //public string eventType;
    public bool hasAnimation;
    public bool hasDialogue;
    public bool hasSceneChange;
    public bool addAnEdge;
    public bool addsItem;
    public bool removesItem;
    public bool hasAnotherEvent;

    public Animation anim;

    public DialogueTrigger dialogueTrigger;

    public GameObject sceneOld;
    public GameObject sceneNew;
    public PathNode newSceneNode;

    public PathNode p1;
    public PathNode p2;

    public Item addedItem;
    public Item removedItem;

    public bool waitOnAnimation;

    public bool triggerOnce;
    public bool beenTriggered;

    public Event anotherEvent;

}
