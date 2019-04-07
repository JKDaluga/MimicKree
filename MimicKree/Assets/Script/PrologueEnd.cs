using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueEnd : Interactable {

    public bool stolenItem;
    public Event cutsceneEvent;
    public GameObject invIcon;
    public AudioSource audio;

    private bool escapeTriggered = false;
    public GameObject[] nonEscapeNodes;
    public GameObject[] escapeNodes;
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
            print("Trigger the escape D:");
            foreach(GameObject node in nonEscapeNodes)
            {
                node.SetActive(false);
            }
            foreach (GameObject node in escapeNodes)
            {
                node.SetActive(true);
            }
            runAwayEvent.newSceneNode = runAwayToNode;
            escapeTriggered = true;
        }
    }

    private void OnMouseEnter()
    {
        FindObjectOfType<CursorManager>().changeCursor("SceneChangeIcon");
    }

    private void OnMouseOver()
    {
        if(stolenItem)
        {
            if (Input.GetMouseButtonDown(0))
            {
                walk();
                StartCoroutine("waitForTrigger2");
            }
        }
        else
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
            audio.enabled = false;
            triggerEvent(cutsceneEvent);
            invIcon.SetActive(false);
            if (DestoryOnceUsed)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
