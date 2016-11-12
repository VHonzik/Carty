using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CQThreeCoroutines : MonoBehaviour {

    private CoroutineQueue queue;
    private int UpdateCount { get; set; }

    // Use this for initialization
    void Start()
    {
        queue = new CoroutineQueue();
        queue.Start();
        queue.Add(SimpleCoroutines.ExitAfterFrame());
        queue.Add(SimpleCoroutines.ExitAfterFrame());
        queue.Add(SimpleCoroutines.ExitAfterFrame());
        UpdateCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateCount < 4)
        {
            // 0 - Started queue processing and added coroutine
            // 1-3 - Coroutines picked up and executed
            IntegrationTest.Assert(queue.Empty == false);
        }
        else if (UpdateCount == 4)
        {
            // 4 - Queue realizes it's empty
            IntegrationTest.Assert(queue.Empty == true);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}
