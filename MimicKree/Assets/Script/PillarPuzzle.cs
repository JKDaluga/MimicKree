using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillarPuzzle : MonoBehaviour {

    private int pillar_ID1 = 0;
    private int pillar_ID2 = 0;
    private int pillar_ID3 = 0;

    public SpriteRenderer Numeral1;
    public SpriteRenderer Numeral2;
    public SpriteRenderer Numeral3;

    public Sprite[] pillar1Sprites;
    public Sprite[] pillar2Sprites;
    public Sprite[] pillar3Sprites;

    private bool isP1Spinning = false;
    private bool isP2Spinning = false;
    private bool isP3Spinning = false;

    public GameObject door;

    public PrologueEnd PE;

    public Event OpenDoor;
    private EventManager em;
    private bool lockPuzzle = false;

    // Use this for initialization
    void Start () {
        em = FindObjectOfType<EventManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cyclePillar(int id)
    {
        if(lockPuzzle)
        {
            return;
        }
        switch(id)
        {
            case (1):
                if(!isP1Spinning)
                {
                    pillar_ID1++;
                    pillar_ID1 = pillar_ID1 % 4;
                    Numeral1.sprite = pillar1Sprites[pillar_ID1];
                    isP1Spinning = true;
                    StartCoroutine("resetSpinning", id);
                }
                break;
            case (2):
                if (!isP2Spinning)
                {
                    pillar_ID2++;
                    pillar_ID2 = pillar_ID2 % 4;
                    Numeral2.sprite = pillar2Sprites[pillar_ID2];
                    isP2Spinning = true;
                    StartCoroutine("resetSpinning", id);
                }
                break;
            case (3):
                if (!isP3Spinning)
                {
                    pillar_ID3++;
                    pillar_ID3 = pillar_ID3 % 4;
                    Numeral3.sprite = pillar3Sprites[pillar_ID3];
                    isP3Spinning = true;
                    StartCoroutine("resetSpinning", id);
                }
                break;
        }
    }

    IEnumerator resetSpinning(int id)
    {
        yield return new WaitForSeconds(.2f);
        switch(id)
        {
            case (1):
                isP1Spinning = false;
                break;
            case (2):
                isP2Spinning = false;
                break;
            case (3):
                isP3Spinning = false;
                break;
        }
        checkCombination();
    }

    public void checkCombination()
    {
        if(!PE.stolenItem)
        {
            return;
        }
        if (pillar_ID1 == 2 && pillar_ID2 == 3 & pillar_ID3 == 1)
        {
            solvedPuzzle();
        }
    }

    public void solvedPuzzle()
    {  
        door.SetActive(false);
        em.triggerEvent(OpenDoor);
        Numeral1.GetComponent<BoxCollider2D>().enabled = false;
        Numeral2.GetComponent<BoxCollider2D>().enabled = false;
        Numeral3.GetComponent<BoxCollider2D>().enabled = false;
        lockPuzzle = true;
    }
}
