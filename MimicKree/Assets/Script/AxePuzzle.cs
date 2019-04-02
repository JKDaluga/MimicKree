using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePuzzle : MonoBehaviour {

    public bool isAxe1Active;
    public bool isAxe2Active;
    public bool isAxe3Active;

    public float speed;

    public bool changeAxe1;
    public bool changeAxe2;
    public bool changeAxe3;

    public GameObject axe1;
    public GameObject axe2;
    public GameObject axe3;

    private bool isStartTimeSet;
    private bool isMoving = true;
    public float length;
    private float startTime;
    private bool isSolved;

    public PathNode p1;
    public PathNode p2;

    public Event feedbackDialogue;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (isMoving && !isSolved)
        {
            if (isStartTimeSet == false)
            {
                startTime = Time.time;
                isStartTimeSet = true;
            }
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / length;
            // Set our position as a fraction of the distance between the markers.

            Vector3 axe1v1 = new Vector3(axe1.transform.position.x,4,0);
            Vector3 axe1v2 = new Vector3(axe1.transform.position.x, 15, 0);
            Vector3 axe2v1 = new Vector3(axe2.transform.position.x, 4, 0);
            Vector3 axe2v2 = new Vector3(axe2.transform.position.x, 15, 0);
            Vector3 axe3v1 = new Vector3(axe3.transform.position.x, 4, 0);
            Vector3 axe3v2 = new Vector3(axe3.transform.position.x, 15, 0);
            if(changeAxe1)
            {
                if(isAxe1Active)
                {
                    axe1.transform.position = Vector3.Lerp(axe1v1, axe1v2, fracJourney);
                    if(fracJourney >= 1)
                    {
                        isAxe1Active = false;
                        changeAxe1 = false;
                    }
                }
                else
                {
                    axe1.transform.position = Vector3.Lerp(axe1v2, axe1v1, fracJourney);
                    if (fracJourney >= 1)
                    {
                        isAxe1Active = true;
                        changeAxe1 = false;
                    }
                }
            }
            if (changeAxe2)
            {
                if (isAxe2Active)
                {
                    axe2.transform.position = Vector3.Lerp(axe2v1, axe2v2, fracJourney);
                    if (fracJourney >= 1)
                    {
                        isAxe2Active = false;
                        changeAxe2 = false;
                    }
                }
                else
                {
                    axe2.transform.position = Vector3.Lerp(axe2v2, axe2v1, fracJourney);
                    if (fracJourney >= 1)
                    {
                        isAxe2Active = true;
                        changeAxe2 = false;
                    }
                }
            }
            if (changeAxe3)
            {
                if (isAxe3Active)
                {
                    axe3.transform.position = Vector3.Lerp(axe3v1, axe3v2, fracJourney);
                    if (fracJourney >= 1)
                    {
                        isAxe3Active = false;
                        changeAxe3 = false;
                    }
                }
                else
                {
                    axe3.transform.position = Vector3.Lerp(axe3v2, axe3v1, fracJourney);
                    if (fracJourney >= 1)
                    {
                        isAxe3Active = true;
                        changeAxe3= false;
                    }
                }
            }

            if (fracJourney >= 1)
            {
                isMoving = false;
                isStartTimeSet = false;
                checkEndState();
            }
        }
    }

    public void updateAxes(int i)
    {
        if(!isMoving)
        {
            isMoving = true;
            if (i == 1)
            {
                changeAxe1 = false;
                changeAxe2 = true;
                changeAxe3 = true;
            }
            else if (i == 2)
            {
                changeAxe1 = true;
                changeAxe2 = true;
                changeAxe3 = false;
            }
            else
            {
                changeAxe1 = false;
                changeAxe2 = false;
                changeAxe3 = true;
            }
        }
    }

    void checkEndState()
    {
        if(!isAxe1Active && !isAxe2Active && !isAxe3Active)
        {
            isSolved = true;
            PathNode[] temp = new PathNode[p1.neighbors.Length + 1];
            for (int i = 0; i < p1.neighbors.Length; i++)
            {
                print(p1.neighbors[i]);
                temp[i] = p1.neighbors[i];
            }
            print(p2);
            temp[p1.neighbors.Length] = p2;
            p1.neighbors = temp;
            temp = new PathNode[p2.neighbors.Length + 1];
            for (int i = 0; i < p2.neighbors.Length; i++)
            {
                temp[i] = p2.neighbors[i];
            }
            temp[p2.neighbors.Length] = p1;
            p2.neighbors = temp;

            feedbackDialogue.hasDialogue = false;
        }
    }
}
