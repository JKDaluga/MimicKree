using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour {

    public SpriteRenderer spriteRend;
    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        Flip();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Flip()
    {
        int rand = Random.Range(0, sprites.Length);
        spriteRend.sprite = sprites[rand];
        bool flipped = (Random.value > .5f);
        spriteRend.flipX = flipped;
        Invoke("Flip", 1f);
        int randRotation = Random.Range(0, 360);
        this.transform.Rotate(new Vector3(0,0,randRotation));
    }
}
