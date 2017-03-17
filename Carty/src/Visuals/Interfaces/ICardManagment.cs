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
        /// Should be used to add any visual behaviors.
        /// <param name="card">Top-level parent game object to use for visuals of the card.</param>
        /// </summary>
        void AssembleCard(GameObject card);
    }
}