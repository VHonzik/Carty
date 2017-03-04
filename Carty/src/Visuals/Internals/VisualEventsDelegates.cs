using Carty.Core.Internals;

namespace Carty.Visuals.Internals
{
    /// <summary>
    /// A delegate for Deck requesting a visual change of card position.
    /// </summary>
    /// <param name="card">Wanted card</param>
    /// <param name="deckIndex">Index of the card where zero is top of the deck.</param>
    /// <param name="deckSize">Number of cards in the deck.</param>
    internal delegate void DeckCardPositionDelegate(CardWrapper card, int deckIndex, int deckSize);
}
