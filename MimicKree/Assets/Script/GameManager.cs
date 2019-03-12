using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private Player player;
    public GameObject screen;

    public GameObject intro;

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
        //if (player.getLocation() == end) return;
        List<PathNode> temp = BreadthFirstSearch(player.getLocation(), end);
        if (temp != null)
        {
            if (temp.Count == 1) player.getLocation().triggerEvent();
            else
            {
                temp.RemoveAt(0);
                player.setList(temp);
                player.walking = true;
            }
        }
    }

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadScreen()
    {
        screen.SetActive(!screen.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Intro()
    {
        intro.SetActive(true);
        UnityEngine.Video.VideoPlayer vp = intro.GetComponent<UnityEngine.Video.VideoPlayer>();
        StartCoroutine("playIntro",vp);
    }

    IEnumerator playIntro(UnityEngine.Video.VideoPlayer vp)
    {
        
        vp.Play();
        while (!vp.isPlaying)
        {
            yield return null;
        }
        while (vp.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene("SampleScene");
    }
}
