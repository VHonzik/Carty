using UnityEngine;
using System.Collections;
using CartyLib;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CQNewIsEmpty : MonoBehaviour {

	void Start () {
        CoroutineQueue queue = new CoroutineQueue();
        IntegrationTest.Assert(queue.Empty == true);
        IntegrationTest.Pass(gameObject);
    }

}
