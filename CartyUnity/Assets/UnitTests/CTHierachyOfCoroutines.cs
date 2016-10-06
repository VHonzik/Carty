using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CTHierachyOfCoroutines : MonoBehaviour
{
    private CoroutineTree tree = new CoroutineTree();
    private int UpdateCount { get; set; }

    private IEnumerator SpawnSubCoroutine()
    {
        tree.AddCurrent(SpawnExitCoroutine());

        yield return null;
    }

    private IEnumerator SpawnExitCoroutine()
    {
        tree.AddCurrent(SimpleCoroutines.ExitAfterFrame());
        tree.AddCurrent(SimpleCoroutines.ExitAfterFrame());

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
        if (UpdateCount < 5)
        {
            // 0 - Started queue processing and added coroutine
            // 1 - SpawnSubCoroutine picked up and executed
            // 2 - SpawnExitCoroutine picked up and executed
            // 3 - ExitAfterFrame #1 picked up and executed
            // 4 - ExitAfterFrame #2 picked up and executed
            IntegrationTest.Assert(tree.Empty == false);
        }
        else if (UpdateCount == 5)
        {
            // 5 - Tree realizes it's empty
            IntegrationTest.Assert(tree.Empty == true);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}
