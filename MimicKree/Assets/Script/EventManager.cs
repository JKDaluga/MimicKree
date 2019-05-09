using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

    Player player;
    Inventory inv;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        inv = FindObjectOfType<Inventory>();
    }

    public void triggerEvent(Event triggeredEvent)
    {
        if(triggeredEvent.triggerOnce && triggeredEvent.beenTriggered)
        {
            return;
        }
        if(triggeredEvent.hasAnimation)
        {
            if (triggeredEvent.isSwitch)
            {
                triggeredEvent.animator.SetBool("Pull", true);
            }
            else
            {
                if (triggeredEvent.waitOnAnimation)
                {
                    WaitForAnimation(triggeredEvent.anim);
                }
                else
                {
                    triggeredEvent.anim.Play();
                }
            }
        }
        if (triggeredEvent.hasDialogue)
        {
            player.stopWalking();
            triggeredEvent.dialogueTrigger.TriggerDialogue();
        }
        if (triggeredEvent.hasSceneChange)
        {
            triggeredEvent.sceneOld.SetActive(false);
            triggeredEvent.sceneNew.SetActive(true);
            if(triggeredEvent.newSceneNode != null)
            {
                player.location = triggeredEvent.newSceneNode;
                player.transform.position = triggeredEvent.newSceneNode.transform.position;
            }
            else
            {
                print("No Node to transition to");
            }
            player.stopWalking();
        }
        if (triggeredEvent.addAnEdge)
        {
            PathNode[] temp = new PathNode[triggeredEvent.p1.neighbors.Length + 1];
            for (int i = 0; i < triggeredEvent.p1.neighbors.Length; i++)
            {
                print(triggeredEvent.p1.neighbors[i]);
                temp[i] = triggeredEvent.p1.neighbors[i];
            }
            temp[triggeredEvent.p1.neighbors.Length] = triggeredEvent.p2;
            triggeredEvent.p1.neighbors = temp;
            temp = new PathNode[triggeredEvent.p2.neighbors.Length + 1];
            for (int i = 0; i < triggeredEvent.p2.neighbors.Length; i++)
            {
                temp[i] = triggeredEvent.p2.neighbors[i];
            }
            temp[triggeredEvent.p2.neighbors.Length] = triggeredEvent.p1;
            triggeredEvent.p2.neighbors = temp;
        }
        if (triggeredEvent.removeAnEdge)
        {
            PathNode[] temp = new PathNode[triggeredEvent.p1.neighbors.Length - 1];
            for (int i = 0; i < triggeredEvent.p1.neighbors.Length; i++)
            {
                if (triggeredEvent.p1.neighbors[i] != triggeredEvent.p2)
                {
                    temp[i] = triggeredEvent.p1.neighbors[i];
                }
            }
            if(temp.Length < triggeredEvent.p1.neighbors.Length)
            {
                triggeredEvent.p1.neighbors = temp;
            }
            temp = new PathNode[triggeredEvent.p2.neighbors.Length - 1];
            for (int i = 0; i < triggeredEvent.p2.neighbors.Length; i++)
            {
                if (triggeredEvent.p2.neighbors[i] != triggeredEvent.p1)
                {
                    temp[i] = triggeredEvent.p2.neighbors[i];
                }
            }
            if (temp.Length < triggeredEvent.p2.neighbors.Length)
            {
                triggeredEvent.p2.neighbors = temp;
            }
        }
        if (triggeredEvent.addsItem)
        {
            inv.addItem(triggeredEvent.addedItem);
            inv.turnOnInv();
        }
        if (triggeredEvent.removesItem)
        {
            inv.removeItem(triggeredEvent.removedItem);
        }
        if (triggeredEvent.istoggleSprite)
        {
            triggeredEvent.on = !triggeredEvent.on;
            triggeredEvent.toggleSprite.SetActive(triggeredEvent.on);
        }
        if (triggeredEvent.hasAudio)
        {
            FindObjectOfType<SoundManager>().playClip(triggeredEvent.sfx);
        }
        if (triggeredEvent.hasAnotherEvent)
        {
            triggerEvent(triggeredEvent.anotherEvent);
        }
        if (triggeredEvent.axeNum != 0)
        {
            triggeredEvent.ap.updateAxes(triggeredEvent.axeNum);
        }
        if (triggeredEvent.door != null)
        {
            triggeredEvent.door.SetActive(false);
            triggeredEvent.door2.SetActive(true);
            triggeredEvent.button.GetComponent<SpriteRenderer>().sprite = triggeredEvent.sprite;
            triggeredEvent.ev.hasDialogue = false;
        }
    }

    private IEnumerator WaitForAnimation(Animation animation)
    {
        animation.Play();
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }
}
