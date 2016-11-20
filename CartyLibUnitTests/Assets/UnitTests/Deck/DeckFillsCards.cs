using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;
using CartyVisuals;
using CartyLib.Internals.BoardComponents;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class DeckFillsCards : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private Deck _deck;

    void Start()
    {
        _deck = Deck.CreateDeck(true);
        _deck.FillWithCards(new string[2] { "simplecard", "othersimplecard" });
    }

    void Update()
    {
        IntegrationTest.Assert(_deck.Cards.Count == 2);
        IntegrationTest.Assert(_deck.Cards[0].GetComponent<SimpleCard>() != null);
        IntegrationTest.Assert(_deck.Cards[1].GetComponent<OtherSimpleCard>() != null);

        IntegrationTest.Pass(gameObject);
    }
}
