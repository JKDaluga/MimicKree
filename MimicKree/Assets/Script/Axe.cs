using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

    AxePuzzle ap;
    public int axeNum;

	// Use this for initialization
	void Start () {
        ap = FindObjectOfType<AxePuzzle>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spark()
    {
        ap.Spark(axeNum);
    }
}
