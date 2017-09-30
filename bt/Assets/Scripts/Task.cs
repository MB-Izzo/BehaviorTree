using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All base fonctionality of our tasks, they will all derive from it.
public abstract class Task {

    // Current status of the task
    protected TaskStatus currentTaskStatus;
    public TaskStatus CurrentTaskStatus {  get { return currentTaskStatus; } }

    // Constructor
    public Task() { }

    // Delegate, returns the status of the task.
    public delegate TaskStatus TaskReturn();

    // Method to evaluate the desired set of conditions/tasks
    public abstract TaskStatus Evaluate();
}

public enum TaskStatus
{
    SUCCESS,
    FAILURE,
    WAITING
}