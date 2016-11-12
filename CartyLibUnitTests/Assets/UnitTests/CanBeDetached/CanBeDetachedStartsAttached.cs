using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CanBeDetachedStartsAttached : MonoBehaviour
{
   void Awake()
   {
        GameObject card = CardsGameObjects.OnlyDetachHandle();
        card.AddComponent<CartyLib.CardsComponenets.CanBeDetached>();
        IntegrationTest.Assert(card.GetComponent<CartyLib.CardsComponenets.CanBeDetached>().Detached == false);
        Destroy(card);
        IntegrationTest.Pass(gameObject);
    }
}
