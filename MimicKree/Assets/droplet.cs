using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droplet : MonoBehaviour {

    public Animator anim;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Splash()
    {
        audio.Play();
        anim.SetBool("Puddle Spash", true);
    }
}
