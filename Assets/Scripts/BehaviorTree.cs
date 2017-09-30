using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour {

    public TextAsset _behaviorScript;

    private Node _root;
    private Dictionary<System.String, System.Object> _dataStore;
    private bool _done;

    private void Awake()
    {
        _dataStore = new Dictionary<string, System.Object>();
        _done = false;

        Selector selector = new Selector();

        Node node = new ThreeTicksThenFail();
        Inverter inverter = new Inverter();
        inverter.Node = node;
        selector.AddNode(inverter);
        selector.AddNode(new ThreeTicksThenFail());
        _root = selector;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_done) return;
        Node.Result result = _root.Process(_dataStore);
        if (result!=Node.Result.RUNNING)
        {
            _done = true;
            Debug.Log("Result " + result);
        }
	}
}
