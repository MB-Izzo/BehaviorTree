using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ça ET ça
public class Sequence : CompositeNode {

    private int _currentNode, _previousTick;
    public override void Init()
    {
        _currentNode = 0;
        _previousTick = -1;
    }

    public override Result Process(Dictionary<string, System.Object> dataStore)
    {
        Result result = Result.RUNNING;
        
        for (/*_currentNode */; _currentNode < _nodes.Count; _currentNode++)
        {
            Node node = _nodes[_currentNode];

            // If this isn't the same node we were processing
            // last tick then we need to init it.
            if (_currentNode != _previousTick) node.Init();

            result = node.Process(dataStore);
            _previousTick = _currentNode;

            if (result == Result.SUCCESS) continue;
            else break;
        }

        return result;
    }
}
