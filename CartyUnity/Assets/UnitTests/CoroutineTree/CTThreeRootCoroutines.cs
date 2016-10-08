using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CTThreeRootCoroutines : MonoBehaviour
{
    private CoroutineTree tree = new CoroutineTree();
    private int UpdateCount { get; set; }

    void Start()
    {
        tree.Start();
        tree.AddRoot(SimpleCoroutines.ExitAfterFrame());
        tree.AddRoot(SimpleCoroutines.ExitAfterFrame());
        tree.AddRoot(SimpleCoroutines.ExitAfterFrame());
        UpdateCount = 0;
    }

    void Update()
    {
        if (UpdateCount < 4)
        {
            // 0 - Started queue processing and added coroutine
            // 1-3 - Coroutines picked up and executed
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