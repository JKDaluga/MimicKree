using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour {
    public GameObject skipButton;
    public GameObject skipHelpText;
    private float counter;

	// Use this for initialization
	void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown)
        {
            counter = 0; 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                skipButton.SetActive(true);
            }
            else
            {
                skipHelpText.SetActive(true);
            }
        }
        else
        {
            counter += Time.deltaTime;
            if(counter >= 5f)
            {
                skipButton.SetActive(false);
                skipHelpText.SetActive(false);
            }
        }
		
	}
}
