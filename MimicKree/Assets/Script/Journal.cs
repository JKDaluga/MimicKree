using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Journal : MonoBehaviour {

    public GameObject journalCanvas;
    public GameObject helpPanel;
    public GameObject ragaPanel;

    public GameObject KreeBioPanel;


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
        helpPanel.SetActive(false);
    }

    public void toggleHelp()
    {
        helpPanel.SetActive(!helpPanel.activeSelf);
    }

    public void toggleRaga()
    {
        ragaPanel.SetActive(!ragaPanel.activeSelf);

    }

    public void toggleKreeBio()
    {
        KreeBioPanel.SetActive(!KreeBioPanel.activeSelf);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
