using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : NodeDecorator {

    public override Result Process(Dictionary<string, System.Object> dataStore)
    {
        Result result = _node.Process(dataStore);

        switch(result)
        {
            case Result.SUCCESS: return Result.FAILURE;
            case Result.FAILURE: return Result.SUCCESS;
            default: return Result.RUNNING;

        }
    }
}
