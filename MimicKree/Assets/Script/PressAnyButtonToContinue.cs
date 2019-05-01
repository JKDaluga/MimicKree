using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButtonToContinue : MonoBehaviour {

    public GameObject StartScreen;
    public GameObject OldScreen;
    public GameObject PressAnyButton;
    public GameObject NewScreen;
    public Animator chestAnim;

    // Update is called once per frame
    void Update () {
        if (Input.anyKeyDown)
        {
            chestAnim.SetBool("Fade", true);
        }
	}

    public void changeScreen()
    {
        StartScreen.SetActive(true);
        OldScreen.SetActive(false);
        NewScreen.SetActive(true);
        PressAnyButton.SetActive(false);
    }
}
