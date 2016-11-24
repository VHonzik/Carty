using UnityEngine;
using Carty.CartyLib.Internals.BoardComponents;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
public class DeckPops : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private Deck _deck;

    void Start()
    {
        _deck = Deck.CreateDeck(true);
        _deck.FillWithCards(new string[1] { "simplecard" });
        var card = _deck.PopCard();
        IntegrationTest.Assert(card != null);
        IntegrationTest.Assert(_deck.Cards.Count == 0);

        Destroy(card);
        Destroy(_deck.gameObject);

        IntegrationTest.Pass(gameObject);
    }
}

