using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeDecorator : Node
{
    public Node node { get; protected set; }
 
    public NodeDecorator(Node node)
    {
        this.node = node;
    }

    public override void Init()
    {
        node.Init();
    }
}
