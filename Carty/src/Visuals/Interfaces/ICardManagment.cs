using UnityEngine;

namespace Carty.Visuals.Interfaces
{
    /// <summary>
    /// Interface for visual aspects of creating, destroying and managing cards.
    /// </summary>
    public interface ICardManagment
    {
        /// <summary>
        /// Called when a card is created.
        /// Should be used create visual representation of the card.
        /// <param name="card">Card ID associated with the new card.</param>
        /// </summary>
        void AssembleCard(int cardID);
    }
}