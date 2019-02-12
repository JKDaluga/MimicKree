using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGraph : MonoBehaviour {

    public int[][] adjList;
    public PathNode[] nodes;


	// Use this for initialization
	void Start () {
        if(adjList == null)
        {
            print("adjList was uninitialized. Creating a default list");
            adjList = new int[1][];
        }

    }

    void BFS()
    {
        bool[] visited = new bool[adjList.Length];


    }
}
