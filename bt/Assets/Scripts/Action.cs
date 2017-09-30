using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Action is the leaf/end Task of the tree, it's the element that actually executes a given behavior.
// This script is used as a generic which we will then pass a delegate.
// This needs a delegate.
// We can implement whatever logic we want here, but the method needs to return a TaskStatus.

public class Action : Task {

    // Method signature for the action
    public delegate TaskStatus ActionTaskDelegate();

    // Delegate that is called to evaluate this task
    private ActionTaskDelegate action;

    public Action(ActionTaskDelegate _action)
    {
        action = _action;
    }

    // Use switch to evalute the current task status
    public override TaskStatus Evaluate()
    {
        switch(action())
        {
            case TaskStatus.SUCCESS:
                currentTaskStatus = TaskStatus.SUCCESS;
                return currentTaskStatus;
            case TaskStatus.FAILURE:
                currentTaskStatus = TaskStatus.FAILURE;
                return currentTaskStatus;
            case TaskStatus.WAITING:
                currentTaskStatus = TaskStatus.FAILURE;
                return currentTaskStatus;
            default:
                currentTaskStatus = TaskStatus.FAILURE;
                return currentTaskStatus;
        }
    }

}
