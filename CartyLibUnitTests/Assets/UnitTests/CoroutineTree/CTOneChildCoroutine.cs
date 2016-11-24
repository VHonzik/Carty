using UnityEngine;
using System.Collections;
using Testing;
using Carty.CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
public class CTOneChildCoroutine : MonoBehaviour
{
    private CoroutineTree tree = new CoroutineTree();
    private int UpdateCount { get; set; }

    private IEnumerator SpawnSubCoroutine()
    {
        tree.AddCurrent(SimpleCoroutines.ExitAfterFrame());

        yield return null;

        yield return null;
    }

    void Start()
    {
        tree.Start();
        tree.AddRoot(SpawnSubCoroutine());
        UpdateCount = 0;
    }

    void Update()
    {
        if (UpdateCount < 4)
        {
            // 0 - Started queue processing and added coroutine
            // 1-2 - Coroutine picked up and executed, child coroutine added
            // 3 - Child executed
            IntegrationTest.Assert(tree.Empty == false);
        }
        else if (UpdateCount == 4)
        {
            // 4 - Tree realizes it's empty
            IntegrationTest.Assert(tree.Empty == true);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}