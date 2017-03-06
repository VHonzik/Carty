using Carty.Visuals.CardComponents;
using UnityEngine;

namespace Carty.Visuals
{
    public class Visuals
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

        public Visuals()
        {
            CardHeight = 0.013f;
            EnemyDeckPosition = new Vector3(7f, 0, 1.9f);
            PlayerDeckPosition = new Vector3(7f, 0, -1.9f);
        }

        /// <summary>
        /// Called when a card is created.
        /// Should be used to add any visual behaviors.
        /// Hooked-up into CardManager.CardCreated event.
        /// <param name="card">Top-level parent game object to use for visuals of the card.</param>
        /// </summary>
        public virtual void AssembleCard(GameObject card)
        {
            card.AddComponent<CanBeInDeck>();
        }

        /// <summary>
        /// Called when a card was instantly placed into a specific deck position.
        /// Hooked-up into Deck.CardInDeckInstantPositionChange event.
        /// </summary>
        /// <param name="card">Top-level parent game object to use for visuals of the card.</param>
        /// <param name="deckIndex">Index of the card in the deck where zero is top of the deck.</param>
        /// <param name="deckSize">Number of cards in the deck.</param>
        public virtual void PositionCardInPlayerDeckInstantly(GameObject card, int deckIndex, int deckSize)
        {
            card.GetComponent<CanBeInDeck>().ChangePosition(true, deckIndex, deckSize);
        }
    }
}