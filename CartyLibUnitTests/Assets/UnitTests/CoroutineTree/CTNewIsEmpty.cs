using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CTNewIsEmpty : MonoBehaviour
{
    private CoroutineTree tree = new CoroutineTree();

    void Start()
    {
        tree.Start();
        IntegrationTest.Assert(tree.Empty == true);
        IntegrationTest.Pass(gameObject);
    }
}