using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.Visuals.Interfaces
{
    /// <summary>
    /// Interface for visual aspects of positioning cards.
    /// </summary>
    public interface ICardPositioning
    {
        /// <summary>
        /// Called when a card was instantly placed into a specific player's deck position.
        /// </summary>
        /// <param name="card">Top-level parent game object from ICardManagment.AssembleCard.</param>
        /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
        /// <param name="deckSize">Number of cards in the deck.</param>
        void PositionCardInPlayerDeckInstantly(GameObject card, int deckIndex, int deckSize);

        /// <summary>
        /// Called when a card was instantly placed into a specific enemy's deck position.
        /// </summary>
        /// <param name="card">Top-level parent game object from ICardManagment.AssembleCard.</param>
        /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
        /// <param name="deckSize">Number of cards in the deck.</param>
        void PositionCardInEnemyDeckInstantly(GameObject card, int deckIndex, int deckSize);

        /// <summary>
        /// Called when a card is being added to the player hand.
        /// In the case that already present cards need to be adjusted they are passed in cardsInHand.
        /// </summary>
        /// <param name="card">Card being added to the hand.</param>
        /// <param name="handIndex">Wanted, zero based, index of the card in hand.</param>
        /// <param name="cardsInHand">Already present cards in the hand.</param>
        /// <returns>The coroutine should exit when the card was added to the hand.</returns>
        IEnumerator MoveCardToPlayerHandAndAdjustHand(GameObject card, int handIndex,
        IEnumerable<GameObject> cardsInHand);

        /// <summary>
        /// Called when a card is being added to the enemy hand.
        /// In the case that already present cards need to be adjusted they are passed in cardsInHand.
        /// </summary>
        /// <param name="card">Card being added to the hand.</param>
        /// <param name="handIndex">Wanted, zero based, index of the card in hand.</param>
        /// <param name="cardsInHand">Already present cards in the hand.</param>
        /// <returns>The coroutine should exit when the card was added to the hand.</returns>
        IEnumerator MoveCardToEnemyHandAndAdjustHand(GameObject card, int handIndex,
        IEnumerable<GameObject> cardsInHand);
    }
}