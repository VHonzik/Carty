using UnityEngine;
using System.Collections;
using CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
public class CQWaitUntil : MonoBehaviour {

    private CoroutineQueue queue;
    private float _wait = 1.5f;
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
        queue.AddWait(_wait);
        StartCoroutine(AssertWaitUntilDone());
    }

    void Update () {
        if(TimeElapsed >= _wait)
        {
            if(_wait_until_done == true)
            {
                IntegrationTest.Assert(queue.Empty == true);
                IntegrationTest.Pass(gameObject);
            }
        }
        else
        {
            IntegrationTest.Assert(_wait_until_done == false);
        }

        TimeElapsed += Time.deltaTime;
    }
}
