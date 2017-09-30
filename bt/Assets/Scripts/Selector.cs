using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The selector is a composite task and can have one or more children. This is
// why we use a list to hold the children.
// During the evaluation, we run through each children and eveluate each one individually.

public class Selector : Task {

    // Selector child tasks
    protected List<Task> childTasks = new List<Task>();

    public Selector(List<Task> _childTasks)
    {
        childTasks = _childTasks;
    }

    // If it's a success, report it UPWARDS, else, report failure.
    public override TaskStatus Evaluate()
    {
        for (int i = 0; i < childTasks.Count; i++)
        {
            Task currentTask = childTasks[i];
            switch (currentTask.Evaluate())
            {
                case TaskStatus.FAILURE:
                    continue;
                case TaskStatus.SUCCESS:
                    return currentTaskStatus;
                case TaskStatus.WAITING:
                    return currentTaskStatus;
                default:
                    continue;
            }
        }
        currentTaskStatus = TaskStatus.FAILURE;
        return currentTaskStatus;
    }
}
