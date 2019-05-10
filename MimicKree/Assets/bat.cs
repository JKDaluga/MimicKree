using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour {

    private Vector3 pos;
    private Animator anim;

	// Use this for initialization
	void Start () {
        pos = transform.position;
        anim = GetComponent<Animator>();
	}

    private void OnDisable()
    {
        transform.position = pos;
        anim.SetBool("Bat_Fly_Right", true);
        anim.SetBool("Bat_Fly_Left", false);
    }
}
