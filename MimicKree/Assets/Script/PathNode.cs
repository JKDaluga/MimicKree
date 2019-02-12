using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode: MonoBehaviour {
    public PathNode[] neighbors;
    public List<PathNode> history;
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void walk()
    {
        gm.walk(this);
    }
}
