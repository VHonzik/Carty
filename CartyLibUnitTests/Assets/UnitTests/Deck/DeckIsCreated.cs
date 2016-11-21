using UnityEngine;
using CartyLib.Internals.BoardComponents;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
class DeckIsCreated : MonoBehaviour
{
    void Awake()
    {
        Deck deck = Deck.CreateDeck(true);

        IntegrationTest.Assert(deck != null);
        IntegrationTest.Assert(deck.PlayerOwned == true);

        Destroy(deck.gameObject);

        IntegrationTest.Pass(gameObject);
    }
}

