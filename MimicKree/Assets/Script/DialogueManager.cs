using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Queue<string> dialogues;

    public GameObject TextDisplay;

    public Text text;
    public Text charName;

    public Image profile;
    //Continue or Exit
    public Text infoText;

	// Use this for initialization
	void Start () {
        dialogues = new Queue<string>();
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Player p = GameObject.FindObjectOfType<Player>();
            if (!p.getWalking())
            {
                DisplayText();
            }
            
        }
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogues.Clear();

        foreach(string words in dialogue.dialogues)
        {
            dialogues.Enqueue(words);
        }

        charName.text = dialogue.name;
        profile.sprite = dialogue.profilePicture;
        DisplayText();
    }

    public void DisplayText()
    {
        if (dialogues.Count != 0)
        {
            text.text = dialogues.Dequeue();
            if (dialogues.Count == 0) infoText.text = "Exit >>";
            else infoText.text = "Continue >>";
            TextDisplay.SetActive(true);
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        TextDisplay.SetActive(false);
    }
}
