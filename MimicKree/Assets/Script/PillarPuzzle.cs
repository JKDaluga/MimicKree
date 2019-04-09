using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPuzzle : MonoBehaviour {

    private int pillar_ID1 = 0;
    private int pillar_ID2 = 0;
    private int pillar_ID3 = 0;

    private bool isP1Spinning = false;
    private bool isP2Spinning = false;
    private bool isP3Spinning = false;

    public GameObject door;
    public Sprite openDoor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cyclePillar(int id)
    {
        switch(id)
        {
            case (1):
                if(isP1Spinning)
                {
                    pillar_ID1++;
                    pillar_ID1 = pillar_ID1 % 4;
                    isP1Spinning = true;
                }
                break;
            case (2):
                if (isP2Spinning)
                {
                    pillar_ID2++;
                    pillar_ID2 = pillar_ID2 % 4;
                    isP2Spinning = true;
                }
                break;
            case (3):
                if (isP3Spinning)
                {
                    pillar_ID3++;
                    pillar_ID3 = pillar_ID3 % 4;
                    isP3Spinning = true;
                }
                break;
        }
        StartCoroutine("resetSpinning", id);
    }

    IEnumerator resetSpinning(int id)
    {
        yield return new WaitForSeconds(1f);
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
        if(pillar_ID1 == 3 && pillar_ID2 == 2 & pillar_ID3 == 3)
        {
            solvedPuzzle();
        }
    }

    public void solvedPuzzle()
    {
        door.GetComponent<Interactable>().enabled = true;
        door.GetComponent<SpriteRenderer>().sprite = openDoor;
    }


}
