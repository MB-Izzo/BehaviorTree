using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour {

    // TASKS/
    // Add all the different types of task we'll need for
    // the tree here!
    public Selector rootTask;
    public Action branchTaskA;
    public Action branchTaskB;
    public Action branchTaskC;
    public Action leafTask;

    public int a;
    public int b;

    // Use this for initialization
    void Start () {
        InstantiateBehaviorTree();
	}
	
	private void InstantiateBehaviorTree()
    {
        // Instantion the tree divided into its different tiers staring from its leaf tasks.

        // Action / leaf tasks
        leafTask = new Action(DoSomething);

        branchTaskA = new Action(DoSomethingElseA);
        branchTaskB = new Action(DoSomethingElseB);
        branchTaskC = new Action(DoSomethingElseC);

        // Third tier / root task
        // Prepate list of all its children
        List<Task> rootChildren = new List<Task>();
        rootChildren.Add(branchTaskA);
        rootChildren.Add(branchTaskB);
        rootChildren.Add(branchTaskC);

        rootTask = new Selector(rootChildren);

    }

    // Action delegates needs to return a TaskStatus
    private TaskStatus DoSomething()
    {
        if (a == 50)
        {
            Debug.Log("Do something done!");
            return TaskStatus.SUCCESS;
        }
        else
        {
            Debug.Log("Do something failed!");
            return TaskStatus.FAILURE;
        }
    }

    private TaskStatus DoSomethingElseA()
    {
        a += 50;
        if (a==50)
        {
            Debug.Log("DoSomethingElseA Done!");
            return TaskStatus.SUCCESS;
        }
        else
        {
            Debug.Log("DoSomethingElseA failed!");
            return TaskStatus.FAILURE;
        }
    }

    private TaskStatus DoSomethingElseB()
    {
        a -= 50;
        if (a == 0)
        {
            Debug.Log("DoSomethingElseB Done!");
            return TaskStatus.SUCCESS;
        }
        else
        {
            Debug.Log("DoSomethingElseB failed!");
            return TaskStatus.FAILURE;
        }
    }

    private TaskStatus DoSomethingElseC()
    {
        a -= 100;
        if (a == -50)
        {
            Debug.Log("DoSomethingElseC Done!");
            return TaskStatus.SUCCESS;
        }
        else
        {
            Debug.Log("DoSomethingElseC failed!");
            return TaskStatus.FAILURE;
        }
    }
}
