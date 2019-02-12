using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour {

    public GameObject journalCanvas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) toggleJournal();

    }

    public void toggleJournal()
    {
        journalCanvas.SetActive(!journalCanvas.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
