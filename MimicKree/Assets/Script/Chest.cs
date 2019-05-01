using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour {

    public GameObject NewGame;
    public GameObject Quit;
    public GameObject Drool1;
    public GameObject Drool2;
    public GameObject intro;

    public void EnterIdle()
    {
        NewGame.SetActive(true);
        Quit.SetActive(true);
        Drool1.SetActive(true);
        Invoke("delayedDrool", .2f);
    }

    private void delayedDrool()
    {
        Drool2.SetActive(true);
    }


    public void ExitIdle()
    {
        NewGame.SetActive(false);
        Quit.SetActive(false);
        Drool1.SetActive(false);
        Drool2.SetActive(false);
        GetComponent<Animator>().SetBool("Close", true);
    }

    public void Intro()
    {
        FindObjectOfType<GameManager>().Intro();
    }
}
