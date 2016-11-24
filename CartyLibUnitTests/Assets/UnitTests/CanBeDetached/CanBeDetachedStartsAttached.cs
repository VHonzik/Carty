using UnityEngine;
using Testing;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
public class CanBeDetachedStartsAttached : MonoBehaviour
{
   void Awake()
   {
        GameObject card = CardsGameObjects.OnlyDetachHandle();
        card.AddComponent<CanBeDetached>();
        IntegrationTest.Assert(card.GetComponent<CanBeDetached>().Detached == false);
        Destroy(card);
        IntegrationTest.Pass(gameObject);
    }
}
