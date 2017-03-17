using UnityEngine;

namespace Carty.Visuals.Interfaces
{
    /// <summary>
    /// Interface for visual aspects of positioning cards.
    /// </summary>
    public interface ICardPositioning
    {
        /// <summary>
        /// Called when a card was instantly placed into a specific deck position.
        /// </summary>
        /// <param name="card">Top-level parent game object from ICardManagment.AssembleCard.</param>
        /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
        /// <param name="deckSize">Number of cards in the deck.</param>
        void PositionCardInPlayerDeckInstantly(GameObject card, int deckIndex, int deckSize);
    }
}