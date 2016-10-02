using UnityEngine;
using System.Collections;
using CartyLib;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CQNewIsEmpty : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CoroutineQueue queue = new CoroutineQueue();
        IntegrationTest.Assert(queue.Empty == true);
        IntegrationTest.Pass(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
