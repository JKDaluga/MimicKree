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
    public Event toggleOff;

    IEnumerator waitForTrigger()
    {
        Player p = FindObjectOfType<Player>();
        while (p.walking)
        {
            yield return null;
        }
        if (p.location != location)
        {
            yield return null;
        }

        if (p.location == location)
        {
            print("ACTIVATE");
            toggle = !toggle;
            if(toggle)
            {
                foreach(SpriteRenderer button in buttons)
                {
                    button.sprite = buttonOn;
                }
                background.sprite = RoomOn;
                triggerEvent();
            }
            else
            {
                foreach (SpriteRenderer button in buttons)
                {
                    button.sprite = buttonOff;
                }
                background.sprite = RoomOff;
                triggerEvent(toggleOff);
            }
            if (DestoryOnceUsed)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            print("not there ma dude");
        }
    }
}
