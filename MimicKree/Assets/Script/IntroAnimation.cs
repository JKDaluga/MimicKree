using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour {

    public Animator chestAnim;
    public GameObject Skull;
    public GameObject PressAnyText;
    private AudioSource audio;
    public AudioClip audioclip;
    public AudioClip audioclip2;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void eatSkull()
    {
        audio.PlayOneShot(audioclip);
        Skull.SetActive(false);
    }

    public void startAnim()
    {
        audio.Play();
        chestAnim.SetBool("Eat",true);
    }

    public void pressAny()
    {
        PressAnyText.SetActive(true);
        GetComponent<PressAnyButtonToContinue>().enabled = true;
    }

    public void idleSounds()
    {
        audio.PlayOneShot(audioclip2);
    }
}
