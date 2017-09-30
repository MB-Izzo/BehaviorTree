using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeDecorator : Node
{
    protected Node _node;
    public Node Node { set { _node = value; } }

    public override void Init()
    {
        _node.Init();
    }
}
