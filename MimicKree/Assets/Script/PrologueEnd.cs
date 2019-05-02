using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueEnd : Interactable {

    public bool stolenItem;
    public Event cutsceneEvent;
    public GameObject invIcon;
    public AudioSource audioSource;

    private bool escapeTriggered = false;
    public GameObject[] nonEscapeNodes;
    public GameObject[] escapeNodes;
    public GameObject[] pillarPuzzlePieces;

    public GameObject statue;
    public GameObject door;

    public Event runAwayEvent;
    public PathNode runAwayToNode;

    private void Update()
    {
        if (FindObjectOfType<Inventory>().contains("lockpick"))
        {
            stolenItem = false;
        }
        else
        {
            stolenItem = true;
        }
        if(stolenItem && !escapeTriggered)
        {
            print("STOLEN ITEM HERE");
            escapeTriggered = true;
            foreach(GameObject node in escapeNodes)
            {
                node.SetActive(false);
            }
            foreach (GameObject node in nonEscapeNodes)
            {
                node.SetActive(true);
            }
            foreach (GameObject go in pillarPuzzlePieces)
            {
                go.SetActive(true);
            }
            runAwayEvent.newSceneNode = runAwayToNode;
            statue.SetActive(true);
            door.SetActive(true);
        }
    }

    private void OnMouseEnter()
    {
        FindObjectOfType<CursorManager>().changeCursor("SceneChangeIcon");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            walk();
            if (itemRequired == "")
            {
                StartCoroutine("waitForTrigger");
            }
        }
    }

    IEnumerator waitForTrigger2()
    {
        Player p = FindObjectOfType<Player>();
        while (p.walking)
        {
            yield return null;
        }
        if (p.location == location)
        {
            audioSource.enabled = false;
            triggerEvent(cutsceneEvent);
            invIcon.SetActive(false);
            if (DestoryOnceUsed)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
