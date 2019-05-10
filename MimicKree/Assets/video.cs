using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class video : MonoBehaviour {

    public VideoPlayer vp;
    public GameObject panel;
    public GameObject chest;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (vp.frame >= 20)
        {
            panel.SetActive(false);
            chest.SetActive(false);
        }
        if(!vp.isPlaying)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }


}
