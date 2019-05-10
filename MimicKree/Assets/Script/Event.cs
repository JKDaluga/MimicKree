using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {

    [Header("Animation Settings")]
    public bool hasAnimation;
    public Animation anim;
    public bool waitOnAnimation;

    [Header("Dialogue Settings")]
    public bool hasDialogue;
    public DialogueTrigger dialogueTrigger;

    [Header("Scene Change Settings")]
    public bool hasSceneChange;
    public GameObject sceneOld;
    public GameObject sceneNew;
    public PathNode newSceneNode;

    [Header("Add/Remove Edge Settings")]
    public bool addAnEdge;
    public bool removeAnEdge;
    public PathNode p1;
    public PathNode p2;

    [Header("Add/Remove Item Settings")]
    public bool addsItem;
    public bool removesItem;
    public Item addedItem;
    public Item removedItem;

    [Header("Toggle Sprite")]
    public bool istoggleSprite;
    public bool on;
    public GameObject toggleSprite;

    [Header("Extra Event Settings")]
    public bool hasAnotherEvent;
    public Event anotherEvent;
    public bool triggerOnce;
    public bool beenTriggered;

    [Header("Audio Settings")]
    public bool hasAudio;
    public AudioClip sfx;

    [Header("Special Settings")]
    public AxePuzzle ap;
    public int axeNum;

    public GameObject door;
    public GameObject door2;
    public GameObject button;
    public Sprite sprite;

    public Event ev;

    public bool isSwitch;
    public Animator animator;

    [Header("Prologue End Settings")]
    public bool end;
    public GameObject invIcon;

    [Header("Destroy Settings")]
    public bool destory;
    public GameObject destroyObj;
}
