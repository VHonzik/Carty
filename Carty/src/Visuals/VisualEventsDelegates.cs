using Carty.Core.Internals;
using UnityEngine;

namespace Carty.Visuals
{
    /// <summary>
    /// A delegate for a deck requesting a visual change of card position.
    /// </summary>
    /// <param name="card">Wanted card</param>
    /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
    /// <param name="deckSize">Number of cards in the deck.</param>
    internal delegate void DeckCardPositionDelegate(GameObject card, int deckIndex, int deckSize);

    /// <summary>
    /// A delegate for card manager informing that a card was created.
    /// </summary>
    /// <param name="card">Newly created card.</param>
    internal delegate void CardCreatedDelegate(GameObject card);
}
