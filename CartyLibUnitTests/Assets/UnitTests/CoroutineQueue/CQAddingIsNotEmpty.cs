using UnityEngine;
using Testing;
using CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
public class CQAddingIsNotEmpty : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CoroutineQueue queue = new CoroutineQueue();
        queue.Add(SimpleCoroutines.ExitImmidiately());
        IntegrationTest.Assert(queue.Empty == false);
        IntegrationTest.Pass(gameObject);
    }
	
}
