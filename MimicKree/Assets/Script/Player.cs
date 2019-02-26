using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PathNode location;
    List<PathNode> pathsToTravel = new List<PathNode>();
    private bool isWalking;
    public bool walking;
    bool isStartTimeSet;

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isWalking)
        {
            if(isStartTimeSet == false)
            {
                startTime = Time.time;
                isStartTimeSet = true;
                journeyLength = (startMarker.position - endMarker.position).magnitude;
                location = endMarker.GetComponent<PathNode>();
            }
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
            
            if(transform.position == endMarker.position)
            {
                location = endMarker.GetComponent<PathNode>();
                if(location.triggeredevent != null)
                {
                    location.triggerEvent();
                }
                isWalking = false;
                walking = false;
                isStartTimeSet = false;
            }
        }
        else walk();
    }

    public void walk()
    {
        if (pathsToTravel.Count != 0)
        {
            startMarker = location.transform;
            endMarker = pathsToTravel[0].transform;
            pathsToTravel.RemoveAt(0);
            isWalking = true;
            walking = true;
          }
    }

    public void setList(List<PathNode> path)
    {
        pathsToTravel = path;
    }

    public PathNode getLocation()
    {
        return location;
    }

    public void stopWalking()
    {
        isWalking = false;
        walking = false;
        isStartTimeSet = false;
        pathsToTravel.Clear();
    }

    public int Count()
    {
        return pathsToTravel.Count;
    }
}
