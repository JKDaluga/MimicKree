using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator anim;

    public PathNode location;
    public List<PathNode> pathsToTravel = new List<PathNode>();
    private bool isWalking;
    public bool walking;
    public bool selectedItem;
    bool isStartTimeSet;
    private Inventory inv;

    public AudioSource audioSource;

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
    void Start ()
    {
        anim = GetComponent<Animator>();
        inv = FindObjectOfType<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        rescale();
        if (isWalking)
        {
            
            if (startMarker.position.x < endMarker.position.x)
            {
                anim.SetBool("KreeWalkRight", true);
                anim.SetBool("KreeWalkLeft", false);
                anim.SetBool("KreeIdleRight", false);
                anim.SetBool("KreeIdleLeft", false);
            }

            else
            {
                anim.SetBool("KreeWalkLeft", true);
                anim.SetBool("KreeWalkRight", false);
                anim.SetBool("KreeIdleLeft", false);
                anim.SetBool("KreeIdleRight", false);
            }

            if (isStartTimeSet == false)
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

                isStartTimeSet = false;
                if(pathsToTravel.Count == 0)
                {
                    walking = false;
                    if (anim.GetBool("KreeWalkRight"))
                    {
                        anim.SetBool("KreeIdleRight", true);
                        anim.SetBool("KreeIdleLeft", false);
                        anim.SetBool("KreeWalkRight", false);
                        anim.SetBool("KreeWalkLeft", false);
                    }
                    else
                    {

                        anim.SetBool("KreeIdleLeft", true);
                        anim.SetBool("KreeIdleRight", false);
                        anim.SetBool("KreeWalkRight", false);
                        anim.SetBool("KreeWalkLeft", false);
                    }
                }
            }
        }
        else walk();
    }

    void rescale()
    {
        float diff = -0.125f*(transform.position.y + 1);
        transform.localScale = new Vector3(1 + diff, 1 + diff, 1);
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
        inv.turnOffInv();
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

    public bool getWalking()
    {
        return isWalking;
    }

    public void playStepSound()
    {
        if(isWalking)
        audioSource.Play();
    }
}
