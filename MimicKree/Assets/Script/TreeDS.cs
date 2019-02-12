using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogueNode
{
    int id;
    string message;
}

public class TreeDS<T> {
    private T data;
    private LinkedList<TreeDS<T>> children;

    public TreeDS(T data)
    {
        this.data = data;
        children = new LinkedList<TreeDS<T>>();
    }

    public void AddChild(T data)
    {
        children.AddFirst(new TreeDS<T>(data));
    }

    public TreeDS<T> GetChild(int i)
    {
        foreach (TreeDS<T> n in children)
            if (--i == 0)
                return n;
        return null;
    }
}
