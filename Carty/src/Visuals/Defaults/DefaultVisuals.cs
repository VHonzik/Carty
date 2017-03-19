using System;
using System.Collections;
using System.Collections.Generic;
using Carty.Visuals.Defaults.CardComponents;
using Carty.Visuals.Interfaces;
using UnityEngine;

namespace Carty.Visuals.Defaults
{
    internal class DefaultVisuals : ICardManagment, ICardPositioning
    {
        /// <summary>
        /// Height of the physical card.
        /// When two cards are placed in the same position with CardHeight difference in Y they should lie on top of each other.
        /// Influences board, hand and deck positioning.
        /// </summary>
        public float CardHeight { get; set; }

        /// <summary>
        /// Default rotation of the card when its face is facing camera.
        /// </summary>
        public Quaternion FlippedOn { get; set; }

        /// <summary>
        /// Default rotation of the card when its back is facing camera.
        /// </summary>
        public Quaternion FlippedOff { get; set; }

        /// <summary>
        /// Position of the bottom-center of the player's deck.
        /// </summary>
        public Vector3 PlayerDeckPosition { get; set; }

        /// <summary>
        /// Position of the bottom-center of the enemy's deck.
        /// </summary>
        public Vector3 EnemyDeckPosition { get; set; }

        public DefaultVisuals()
        {
            CardHeight = 0.013f;
            EnemyDeckPosition = new Vector3(7f, 0, 1.9f);
            PlayerDeckPosition = new Vector3(7f, 0, -1.9f);
        }

        public void AssembleCard(GameObject card)
        {
            card.AddComponent<CanBeInDeck>().DVisuals = this;
        }

        public void PositionCardInPlayerDeckInstantly(GameObject card, int deckIndex, int deckSize)
        {
            card.GetComponent<CanBeInDeck>().ChangePosition(true, deckIndex, deckSize);
        }

        public void PositionCardInEnemyDeckInstantly(GameObject card, int deckIndex, int deckSize)
        {
            card.GetComponent<CanBeInDeck>().ChangePosition(false, deckIndex, deckSize);
        }

        public IEnumerator MoveCardToPlayerHandAndAdjustHand(GameObject card, int handIndex, IEnumerable<GameObject> cardsInHand)
        {
            throw new NotImplementedException();
        }

        public IEnumerator MoveCardToEnemyHandAndAdjustHand(GameObject card, int handIndex, IEnumerable<GameObject> cardsInHand)
        {
            throw new NotImplementedException();
        }
    }
}