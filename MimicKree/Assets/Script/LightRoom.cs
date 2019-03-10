using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightRoom : Interactable {

    public SpriteRenderer[] buttons;
    public SpriteRenderer background;

    public Sprite buttonOn;
    public Sprite buttonOff;
    public Sprite RoomOn;
    public Sprite RoomOff;

    public bool toggle;

    public Event dialogueEvent;

    IEnumerator waitForTrigger()
    {
        Player p = FindObjectOfType<Player>();
        while (p.walking)
        {
            yield return null;
        }
        if (p.location == location)
        {
            triggerEvent();
            toggle = !toggle;
            if(toggle)
            {
                foreach(SpriteRenderer button in buttons)
                {
                    button.sprite = buttonOn;
                }
                background.sprite = RoomOn;
            }
            else
            {
                foreach (SpriteRenderer button in buttons)
                {
                    button.sprite = buttonOff;
                }
                background.sprite = RoomOff;
            }
            if (DestoryOnceUsed)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
