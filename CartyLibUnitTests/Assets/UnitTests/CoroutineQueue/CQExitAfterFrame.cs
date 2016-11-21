using UnityEngine;
using Testing;
using CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
public class CQExitAfterFrame : MonoBehaviour {
    private CoroutineQueue queue;
    private int UpdateCount { get; set; }

    void Start () {
        queue = new CoroutineQueue();
        queue.Start();
        queue.Add(SimpleCoroutines.ExitAfterFrame());
        UpdateCount = 0;
    }

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
