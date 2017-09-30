using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ça OU ça
public class Selector : CompositeNode {

    private int _currentNode, _previousTick;

    public override void Init()
    {
        _currentNode = 0;
        _previousTick = -1;
    }

    public override Result Process(Dictionary<string, System.Object> dataStore)
    {
        Result result = Result.RUNNING;

        for (/*_currentNode*/; _currentNode < _nodes.Count; _currentNode++)
        {
            Node node = _nodes[_currentNode];
            // If this isn't the same node we were processing
            // last tick then we need to Init it
            if (_currentNode != _previousTick) node.Init();

            result = node.Process(dataStore);

            if (result == Result.FAILURE) continue;
            else break;
        }

        return result;
    }

}
