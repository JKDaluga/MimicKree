using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightRoom : Interactable {

    public SpriteRenderer[] buttons;
    public SpriteRenderer background;
    public SpriteRenderer Switch;

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
            print("1");
            yield return null;
        }
        if (p.location != location)
        {
            yield return null;
        }
        print("2");
        if (p.location == location)
        {
            toggle = !toggle;
            toggle = true;
            if (toggle)
            {
                foreach (SpriteRenderer button in buttons)
                {
                    button.sprite = buttonOn;
                }
                background.sprite = RoomOn;
                dialogueEvent.hasDialogue = false;
                Switch.color = new Color(255f, 255f, 255f);
                triggerEvent();
            }
            /*else
            {
                print("ACTIVATE");
                foreach (SpriteRenderer button in buttons)
                {
                    button.sprite = buttonOff;
                }
                background.sprite = RoomOff;
                Switch.color = new Color(145f, 145f, 145f);
                triggerEvent(toggleOff);
            }*/
        }
    }
}
