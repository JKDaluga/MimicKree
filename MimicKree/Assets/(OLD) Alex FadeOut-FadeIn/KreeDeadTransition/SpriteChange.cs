using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{

    public Sprite KreeAlive;
    public Sprite KreeDead;

    float timer = 1f;
    float delay = 1f;

    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {

            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == KreeAlive)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = KreeDead;
                timer = delay;
                return;
            }

            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == KreeDead)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = KreeAlive;
                timer = delay;
                return;


            }

        }
    }
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame

}