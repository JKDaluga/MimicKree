using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour {

    public Animator chestAnim;
    public GameObject Skull;

    public void eatSkull()
    {
        Skull.SetActive(false);
    }

    public void startAnim()
    {
        chestAnim.SetBool("Eat",true);
    }
}
