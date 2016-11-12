using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CQAddingIsNotEmpty : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CoroutineQueue queue = new CoroutineQueue();
        queue.Add(SimpleCoroutines.ExitImmidiately());
        IntegrationTest.Assert(queue.Empty == false);
        IntegrationTest.Pass(gameObject);
    }
	
}
