using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeNode
{
    public abstract void Init(Hashtable data);
    public abstract NodeStatus Tick();
}

public enum NodeStatus
{
    SUCCESS,
    FAILURE,
    RUNNING
}

public abstract class Decorator : TreeNode
{
    public TreeNode child;

    public override void Init(Hashtable data)
    {
        child.Init(data);
    }
}

public abstract class Compositor : TreeNode
{
    public TreeNode[] children;

    public override void Init(Hashtable data)
    {
        foreach (TreeNode child in children)
        {
            child.Init(data);
        }
    }
}