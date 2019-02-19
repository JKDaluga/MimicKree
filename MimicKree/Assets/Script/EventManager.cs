using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    Player player;
    Inventory inv;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        inv = FindObjectOfType<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void triggerEvent(Event triggeredEvent)
    {
        switch (triggeredEvent.eventType)
        {
            case "animation":
                triggeredEvent.obj.GetComponent<Animation>().Play();
                break;
            case "dialogue":
                triggeredEvent.obj.GetComponent<DialogueTrigger>().TriggerDialogue();
                player.stopWalking();
                break;
            case "changeScene":
                triggeredEvent.sceneOld.SetActive(false);
                triggeredEvent.sceneNew.SetActive(true);
                player.location = triggeredEvent.obj.GetComponent<PathNode>();
                player.transform.position = triggeredEvent.obj.transform.position;
                break;
            case "addEdge":
                if(triggeredEvent.obj != null)
                {
                    triggeredEvent.obj.SetActive(true);
                }
                PathNode[] temp = new PathNode[triggeredEvent.p1.neighbors.Length + 1];
                for(int i = 0; i < triggeredEvent.p1.neighbors.Length; i++)
                {
                    print(triggeredEvent.p1.neighbors[i]);
                    temp[i] = triggeredEvent.p1.neighbors[i];
                }
                print(triggeredEvent.p2);
                temp[triggeredEvent.p1.neighbors.Length] = triggeredEvent.p2;
                triggeredEvent.p1.neighbors = temp;
                temp = new PathNode[triggeredEvent.p2.neighbors.Length + 1];
                for (int i = 0; i < triggeredEvent.p2.neighbors.Length; i++)
                {
                    temp[i] = triggeredEvent.p2.neighbors[i];
                }
                temp[triggeredEvent.p2.neighbors.Length] = triggeredEvent.p1;
                triggeredEvent.p2.neighbors = temp;
                break;
            case "addItem":
                inv.addItem(triggeredEvent.addedItem);
                break;
            case "removeItem":
                inv.removeItem(triggeredEvent.removedItem);
                break;
            default:
                break;
        }
    }
}
