using Carty.Core.Internals;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.Visuals
{
    /// <summary>
    /// A delegate for a deck requesting a visual change of card position.
    /// </summary>
    /// <param name="cardID">Wanted card ID.</param>
    /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
    /// <param name="deckSize">Number of cards in the deck.</param>
    internal delegate void DeckCardPositionDelegate(int cardID, int deckIndex, int deckSize);

    /// <summary>
    /// A delegate for card manager informing that a card was created.
    /// </summary>
    /// <param name="cardID">ID of the newly created card. Will be used in subsequent visual calls.</param>
    internal delegate void CardCreatedDelegate(int cardID);

    /// <summary>
    /// A delegate for hand requesting moving a card into the hand and adjusting other cards in hand.
    /// </summary>
    /// <param name="cardID">Wanted card ID.</param>
    /// <param name="handIndex">Wanted position of the card where zero is leftmost card.</param>
    /// <param name="cardsInHand">Already present cards in hand.</param>
    internal delegate void AddingCardToHandDelegate(int cardID, int handIndex, 
        IEnumerable<int> cardsInHand);
}
