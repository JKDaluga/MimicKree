using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLight : Interactable {

    public GameObject lightRoom;
    public GameObject darkRoom;

    private bool isOn;

    public override void triggerEvent()
    {
        isOn = !isOn;
        if (isOn)
        {
            lightRoom.SetActive(true);
            darkRoom.SetActive(false);
        }
        else
        {

            lightRoom.SetActive(false);
            darkRoom.SetActive(true);
        }
    }
}
