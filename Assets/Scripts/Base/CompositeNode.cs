using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeNode : Node
{
    private List<Node> _nodes;
    private Node _current_node;

    public CompositeNode( List<Node> initial_list = null)
    {
        _nodes = initial_list;
        if (_nodes == null || _nodes.Count == 0)
        {
            _nodes = new List<Node>();
        }
    }

    public void AddNode(Node node)
    {
        _nodes.Add(node);
    }

    public override void Init()
    {
        // Don't force implementation
        if ( _nodes.Count != 0 )
        {
            _current_node = _nodes[0];
            _current_node.Init();
        }
    }

    public override Result Process(Dictionary<string, System.Object> dataStore)
    {
        Result result = _current_node.Process(dataStore);
        if (result == Result.RUNNING)
        {
            return result;
        }
        _current_node = GetNextNode();
        _current_node.Init();
        return Process(dataStore);
    }

    private Node GetNextNode()
    {
        int idx = _nodes.IndexOf(_current_node);
        return (idx == _nodes.Count - 1 ? _nodes[0] : _nodes[idx + 1]);
    }
}
