using UnityEngine;
using Carty.CartyLib;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
class CardManangerConstructsCard : MonoBehaviour
{
    private GameObject card;

    void Awake()
    {
        card = GameManager.Instance.CardManager.CreateCard("simplecard", true);
        IntegrationTest.Assert(card.GetComponent<CanBeDetached>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeDetached>().Handle != null);
        IntegrationTest.Assert(card.GetComponent<CanBeInHand>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeMousedOver>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeMoved>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeOwned>() != null);
        IntegrationTest.Assert(card.GetComponent<HasPhysicalCard>() != null);
        IntegrationTest.Assert(card.GetComponent<HasOutline>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeHighlighted>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeInteractedWith>() != null);
        IntegrationTest.Assert(card.GetComponent<CanBeDragged>() != null);
        IntegrationTest.Assert(card.GetComponent<SimpleCard>() != null);

    }

    void Update()
    {
        IntegrationTest.Assert(card.GetComponent<HasPhysicalCard>().PhysicalCardGO != null);
        IntegrationTest.Assert(card.GetComponent<HasOutline>().OutlineGO != null);
        Destroy(card);
        IntegrationTest.Pass(gameObject);
    }
}