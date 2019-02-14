using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<PathNode> BreadthFirstSearch(PathNode start, PathNode end)
    {
        List<PathNode> result = new List<PathNode>();
        List<PathNode> visited = new List<PathNode>();
        Queue<PathNode> work = new Queue<PathNode>();

        
        start.history = new List<PathNode>();
        visited.Add(start);
        work.Enqueue(start);
        while (work.Count > 0)
        {
            PathNode current = work.Dequeue();
            if (current == end)
            {
                //Found Node
                result = current.history;
                result.Add(current);
                return result;
            }
            else
            {
                //Didn't find Node
                for (int i = 0; i < current.neighbors.Length; i++)
                {
                    PathNode currentNeighbor = current.neighbors[i];
                    if (!visited.Contains(currentNeighbor))
                    {
                        currentNeighbor.history = new List<PathNode>(current.history);
                        currentNeighbor.history.Add(current);
                        visited.Add(currentNeighbor);
                        work.Enqueue(currentNeighbor);
                    }
                }
            }
        }
        //Route not found, loop ends
        return null;
    }

    public void walk(PathNode end)
    {
        List<PathNode> temp = BreadthFirstSearch(player.getLocation(), end);
        if (temp != null)
        {
            temp.RemoveAt(0);
            if(temp.Count != 0) player.setList(temp);
        }
    }
}
