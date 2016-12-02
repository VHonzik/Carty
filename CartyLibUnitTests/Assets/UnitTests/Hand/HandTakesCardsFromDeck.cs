using UnityEngine;
using Carty.CartyLib.Internals.BoardComponents;
using Carty.CartyVisuals;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
public class HandTakesCardsFromDeck : MonoBehaviour
{
    private Hand _hand;
    private Deck _deck;

    void Start()
    {
        _hand = Hand.CreateHand(true);
        _deck = Deck.CreateDeck(true);
        _deck.FillWithCards(new string[3] { "simplecard", "simplecard", "simplecard" });
        _hand.ImmidiatelyTakeCardsFromDeck(_deck, 2);
    }


    // Update is called once per frame
    void Update()
    {
        IntegrationTest.Assert(_hand.Cards.Count == 2);
        IntegrationTest.Assert(_deck.Cards.Count == 1);
        _hand.CleanUp();
        _deck.CleanUp();

        IntegrationTest.Pass(gameObject);
    }
}
