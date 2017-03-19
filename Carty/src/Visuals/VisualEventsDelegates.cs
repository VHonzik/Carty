using Carty.Core.Internals;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.Visuals
{
    /// <summary>
    /// A delegate for a deck requesting a visual change of card position.
    /// </summary>
    /// <param name="card">Wanted card.</param>
    /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
    /// <param name="deckSize">Number of cards in the deck.</param>
    internal delegate void DeckCardPositionDelegate(GameObject card, int deckIndex, int deckSize);

    /// <summary>
    /// A delegate for card manager informing that a card was created.
    /// </summary>
    /// <param name="card">Newly created card.</param>
    internal delegate void CardCreatedDelegate(GameObject card);

    /// <summary>
    /// A delegate for hand requesting moving a card into the hand and adjusting other cards in hand.
    /// </summary>
    /// <param name="card">Wanted card.</param>
    /// <param name="handIndex">Wanted position of the card where zero is leftmost card.</param>
    /// <param name="cardsInHand">Already present cards in hand.</param>
    internal delegate void AddingCardToHandDelegate(GameObject card, int handIndex, 
        IEnumerable<GameObject> cardsInHand);
}
