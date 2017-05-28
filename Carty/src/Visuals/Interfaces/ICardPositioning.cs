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
        /// <param name="cardID">Wanted card ID as passed in ICardManagment.AssembleCard.</param>
        /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
        /// <param name="deckSize">Number of cards in the deck.</param>
        void PositionCardInPlayerDeckInstantly(int cardID, int deckIndex, int deckSize);

        /// <summary>
        /// Called when a card was instantly placed into a specific enemy's deck position.
        /// </summary>
        /// <param name="cardID">Wanted card ID as passed in ICardManagment.AssembleCard.</param>
        /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
        /// <param name="deckSize">Number of cards in the deck.</param>
        void PositionCardInEnemyDeckInstantly(int cardID, int deckIndex, int deckSize);

        /// <summary>
        /// Called when a card is being added to the player hand.
        /// In the case that already present cards need to be adjusted they are passed in cardsInHand.
        /// </summary>
        /// <param name="cardID">Wanted card ID as passed in ICardManagment.AssembleCard.</param>
        /// <param name="handIndex">Wanted, zero based, index of the card in hand.</param>
        /// <param name="cardsInHand">IDs of already present cards in the hand.</param>
        /// <returns>The coroutine should exit when the card was added to the hand.</returns>
        IEnumerator MoveCardToPlayerHandAndAdjustHand(int cardID, int handIndex,
        IEnumerable<int> cardsInHand);

        /// <summary>
        /// Called when a card is being added to the enemy hand.
        /// In the case that already present cards need to be adjusted they are passed in cardsInHand.
        /// </summary>
        /// <param name="cardID">Wanted card ID as passed in ICardManagment.AssembleCard.</param>
        /// <param name="handIndex">Wanted, zero based, index of the card in hand.</param>
        /// <param name="cardsInHand">IDs of already present cards in the hand.</param>
        /// <returns>The coroutine should exit when the card was added to the hand.</returns>
        IEnumerator MoveCardToEnemyHandAndAdjustHand(int cardID, int handIndex,
        IEnumerable<int> cardsInHand);
    }
}