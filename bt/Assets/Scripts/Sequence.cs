using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The sequence is a composite task: can have one or more children! (use list!)
// During the evaluation, we picture all of the childTasks as SUCCESS,
// only if they evaluate to be FAILURE the entire sequence fails.

public class Sequence : Task {

    // Sequence child tasks
    protected List<Task> childTasks = new List<Task>();

    public Sequence (List<Task> _childTasks)
    {
        childTasks = _childTasks;
    }

    // If any of the children returns failure, report it upwards.
    // If all report success, then report success.

    public override TaskStatus Evaluate()
    {
        bool taskRunning = false;

        for (int i = 0; i < childTasks.Count; i++)
        {
            Task currentTask = childTasks[i];

            switch(currentTask.Evaluate())
            {
                case TaskStatus.FAILURE:
                    currentTaskStatus = TaskStatus.FAILURE;
                    return currentTaskStatus;
                case TaskStatus.SUCCESS:
                    continue;
                case TaskStatus.WAITING:
                    taskRunning = true;
                    continue;
                default:
                    currentTaskStatus = TaskStatus.SUCCESS;
                    return currentTaskStatus;
            }
        }
        if (taskRunning)
        {
            currentTaskStatus = TaskStatus.WAITING;
            return currentTaskStatus;
        }
        else
        {
            currentTaskStatus = TaskStatus.SUCCESS;
            return currentTaskStatus;
        }
    }
}
