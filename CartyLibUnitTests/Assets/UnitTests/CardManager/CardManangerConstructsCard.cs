using UnityEngine;
using Carty.CartyLib;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
class CardManangerConstructsCard : MonoBehaviour
{
    void Awake()
    {
        GameObject card = GameManager.Instance.CardManager.CreateCard("simplecard", true);
        IntegrationTest.Assert(card.GetComponent<CanBeDetached>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeDetached>().Handle != null);
        IntegrationTest.Assert(card.GetComponent<CanBeInHand>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeMousedOver>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeMoved>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeOwned>() != null);
        IntegrationTest.Assert(card.GetComponent<HasOutline>() != null);
        IntegrationTest.Assert(card.GetComponent<SimpleCard>() != null);
        Destroy(card);
        IntegrationTest.Pass(gameObject);
    }
}