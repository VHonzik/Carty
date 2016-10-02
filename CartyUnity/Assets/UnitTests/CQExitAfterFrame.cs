using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CQExitAfterFrame : MonoBehaviour {
    private CoroutineQueue queue;
    private int UpdateCount { get; set; }

    // Use this for initialization
    void Start () {
        queue = new CoroutineQueue();
        queue.Start();
        queue.Add(SimpleCoroutines.ExitAfterFrame());
        UpdateCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateCount < 2)
        {
            // 0 - Started queue processing and added coroutine
            // 1 - Coroutine picked up and executed
            IntegrationTest.Assert(queue.Empty == false);
        }
        else if (UpdateCount == 2)
        {
            // 2 - Queue continues and realizes it's empty
            IntegrationTest.Assert(queue.Empty == true);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}
