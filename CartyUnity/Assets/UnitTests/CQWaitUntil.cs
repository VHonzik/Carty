using UnityEngine;
using System.Collections;
using CartyLib;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CQWaitUntil : MonoBehaviour {

    private CoroutineQueue queue;
    private float _wait = 1.5f;
    private int UpdateCount { get; set; }
    private float TimeElapsed { get; set; }
    private bool _wait_until_done = false;

    private IEnumerator AssertWaitUntilDone()
    {
        yield return StartCoroutine(queue.WaitUntilEmpty());
        _wait_until_done = true;
    }

    void Start()
    {
        queue = new CoroutineQueue();
        queue.Start();
        queue.AddWait(1.5f);
        UpdateCount = 0;
        StartCoroutine(AssertWaitUntilDone());
    }

    void Update () {

        // Starting queue + Realizing it's empty + Assert getting hit + ???
        if(TimeElapsed >= _wait && UpdateCount == 4)
        {
            IntegrationTest.Assert(_wait_until_done == true);
            IntegrationTest.Pass(gameObject);
        }
        else
        {
            IntegrationTest.Assert(_wait_until_done == false);
        }

        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= _wait) UpdateCount++;
    }
}
