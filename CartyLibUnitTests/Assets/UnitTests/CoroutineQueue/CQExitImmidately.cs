using UnityEngine;
using Testing;
using CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CQExitImmidately : MonoBehaviour {
    private CoroutineQueue queue;
    private int UpdateCount { get; set; }

    // Use this for initialization
    void Start () {
        queue = new CoroutineQueue();
        queue.Start();
        queue.Add(SimpleCoroutines.ExitImmidiately());
        UpdateCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
	    if(UpdateCount < 2)
        {
            // 0 - Started queue processing and added coroutine
            // 1 - Coroutine picked up and done
            IntegrationTest.Assert(queue.Empty == false);
        }
        else if (UpdateCount == 2)
        {
            // 2 - Queue realized it's empty
            IntegrationTest.Assert(queue.Empty == true);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;

    }
}
