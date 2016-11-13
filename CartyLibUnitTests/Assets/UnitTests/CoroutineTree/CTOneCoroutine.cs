using UnityEngine;
using Testing;
using CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CTOneCoroutine : MonoBehaviour
{
    private CoroutineTree tree = new CoroutineTree();
    private int UpdateCount { get; set; }

    void Start()
    {
        tree.Start();
        tree.AddRoot(SimpleCoroutines.ExitAfterFrame());
        UpdateCount = 0;
    }

    void Update()
    {
        if (UpdateCount < 2)
        {
            // 0 - Started queue processing and added coroutine
            // 1 - Coroutine picked up and executed
            IntegrationTest.Assert(tree.Empty == false);
        }
        else if (UpdateCount == 2)
        {
            // 2 - Queue realizes it's empty
            IntegrationTest.Assert(tree.Empty == true);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}
