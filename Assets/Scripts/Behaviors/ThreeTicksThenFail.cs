using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeTicksThenFail : Node
{
    private int _ticks;

    public override void Init()
    {
        _ticks = 0;
    }

    public override Result Process(Dictionary<string, System.Object> dataStore)
    {
        Debug.Log("Tick " + _ticks);
        if (_ticks++ < 3)
        {
            return Result.RUNNING;
        }
        return Result.FAILURE;
    }
}
