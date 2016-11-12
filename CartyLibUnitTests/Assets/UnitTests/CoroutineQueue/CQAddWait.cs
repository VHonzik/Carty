using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CQAddWait : MonoBehaviour {

    private CoroutineQueue queue = new CoroutineQueue();
    private float TimeElapsed { get; set; }
    private float wait = 1.5f;
    private int UpdateCount { get; set; }

    void Start()
    {
        queue.Start();
        queue.AddWait(wait);
        TimeElapsed = 0;
        UpdateCount = 0;
    }

    void Update()
    {
        if (TimeElapsed < wait)
        {
            IntegrationTest.Assert(queue.Empty == false);
        }
        // One frame for starting coroutine and one for realizing the queue is empty
        else if (TimeElapsed >= wait && UpdateCount == 2)
        {
            IntegrationTest.Assert(queue.Empty == true);
            IntegrationTest.Pass(gameObject);
        }

        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= wait) UpdateCount++;
    }
}
