using UnityEngine;
using Carty.CartyLib.Internals.BoardComponents;
using Carty.CartyVisuals;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
public class HandFillsCards : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private Hand _hand;

    void Start()
    {
        _hand = Hand.CreateHand(true);
        _hand.FillWithCards(new string[2] { "simplecard", "othersimplecard" });
    }

    void Update()
    {
        IntegrationTest.Assert(_hand.Cards.Count == 2);
        IntegrationTest.Assert(_hand.Cards[0].GetComponent<SimpleCard>() != null);
        IntegrationTest.Assert(_hand.Cards[1].GetComponent<OtherSimpleCard>() != null);

        IntegrationTest.Assert(_hand.Cards[0].transform.position == VisualManager.Instance.HandPositioning.PositionPlayer(0,2));
        IntegrationTest.Assert(_hand.Cards[0].transform.rotation == VisualManager.Instance.HandPositioning.RotationPlayer(0,2));

        IntegrationTest.Assert(_hand.Cards[1].transform.position == VisualManager.Instance.HandPositioning.PositionPlayer(1, 2));
        IntegrationTest.Assert(_hand.Cards[1].transform.rotation == VisualManager.Instance.HandPositioning.RotationPlayer(1, 2));

        IntegrationTest.Pass(gameObject);
    }
}
