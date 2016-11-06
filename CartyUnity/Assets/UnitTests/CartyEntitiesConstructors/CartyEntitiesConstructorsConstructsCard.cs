using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;
using CartyLib.CardsComponenets;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CartyEntitiesConstructorsConstructsCard : MonoBehaviour
{
    void Awake()
    {
        GameObject card = CartyEntitiesConstructors.CreateCard();
        IntegrationTest.Assert(card.GetComponent<CanBeDetached>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeDetached>().Handle != null);
        IntegrationTest.Assert(card.GetComponent<CanBeInHand>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeMousedOver>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeMoved>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeOwned>() != null);
        IntegrationTest.Assert(card.GetComponent<HasOutline>() != null);
        Destroy(card);
        IntegrationTest.Pass(gameObject);
    }
}