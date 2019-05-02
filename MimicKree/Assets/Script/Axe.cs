using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

    AxePuzzle ap;
    public int axeNum;
    public bool soundEnabled;
    public AudioSource axeSound;

	// Use this for initialization
	void Start () {
        ap = FindObjectOfType<AxePuzzle>();
	}

    void Spark()
    {
        ap.Spark(axeNum);
    }

    void AxeNoise()
    {
        if(soundEnabled)
        {
            axeSound.Play();
        }
    }
}
