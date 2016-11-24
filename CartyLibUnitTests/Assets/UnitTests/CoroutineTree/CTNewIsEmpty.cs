using UnityEngine;
using Carty.CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
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