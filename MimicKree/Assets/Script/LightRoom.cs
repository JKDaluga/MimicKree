using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightRoom : Interactable {

    public GameObject[] buttons;
    public GameObject[] darkbuttons;
    public SpriteRenderer background;

    public DialogueTrigger darkRoomDialogue;

    public Sprite buttonOn;
    public Sprite buttonOff;
    public Sprite RoomOn;
    public Sprite RoomOff;

    public bool toggle;
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
            toggle = true;
            if (toggle)
            {
                foreach (GameObject button in buttons)
                {
                    button.SetActive(true);
                }
                foreach (GameObject button in darkbuttons)
                {
                    button.SetActive(false);
                }
                background.sprite = RoomOn;
                triggerEvent();
            }
        }
    }
}
