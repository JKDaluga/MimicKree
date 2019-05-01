using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour {

    public Animator chestAnim;
    public GameObject Skull;
    public GameObject PressAnyText;

    public void eatSkull()
    {
        Skull.SetActive(false);
    }

    public void startAnim()
    {
        chestAnim.SetBool("Eat",true);
    }

    public void pressAny()
    {
        PressAnyText.SetActive(true);
        GetComponent<PressAnyButtonToContinue>().enabled = true;
    }
}
