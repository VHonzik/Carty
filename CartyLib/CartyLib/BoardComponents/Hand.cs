using CartyLib.CardsComponenets;
using CartyVisuals;
using System.Collections.Generic;
using UnityEngine;

namespace CartyLib.BoardComponents
{
    /// <summary>
    /// Component representing the hand of a player or enemy.
    /// </summary>
    public class Hand : MonoBehaviour
    {
        /// <summary>
        /// List of cards that are currently in the hand.
        /// </summary>
        public List<CanBeInHand> Cards { get; private set; }

        /// <summary>
        /// Whether it is a player hand or an enemy hand.
        /// </summary>
        public bool PlayerOwned { get; set; }

        void Awake()
        {
            Cards = new List<CanBeInHand>();
        }

        /// <summary>
        /// Inform the hand a new card is gonna be added to it and make space for it.
        /// </summary>
        public void PrepareAddingCard()
        {
            for(int i=0; i < Cards.Count; i++)
            {
                Cards[i].OnIndexChanged(i, Cards.Count + 1);
            }
        }

        /// <summary>
        /// Returns the position new card would occupy if added.
        /// </summary>
        /// <returns>Potential position of the new card.</returns>
        public Vector3 NewCardPosition()
        {
            if(PlayerOwned)
            {
                return VisualManager.Instance.HandPositioning.PositionPlayer(Cards.Count, Cards.Count + 1);
            }
            else
            {
                return VisualManager.Instance.HandPositioning.PositionEnemy(Cards.Count, Cards.Count + 1);
            }            
        }

        /// <summary>
        /// Returns the rotation a new card would occupy if added.
        /// </summary>
        /// <returns>Potential rotation of the new card.</returns>
        public Quaternion NewCardRotation()
        {
            if (PlayerOwned)
            {
                return VisualManager.Instance.HandPositioning.RotationPlayer(Cards.Count, Cards.Count + 1);
            }
            else
            {
                return VisualManager.Instance.HandPositioning.RotationEnemy(Cards.Count, Cards.Count + 1);
            }
        }

        /// <summary>
        /// Adds a card into the hand.
        /// Does not update already present cards, use PrepareAddingCard for that.
        /// Will move and rotate the card to have a correct transform.
        /// </summary>
        /// <param name="card">Card to be added.</param>
        public void Add(CanBeInHand card)
        {
            card.AddedToHand(Cards.Count, Cards.Count + 1, this);
            Cards.Add(card);
        }

        /// <summary>
        /// Remove a card from hand.
        /// Will update all remaining cards transforms.
        /// </summary>
        /// <param name="card">Card to be removed.</param>
        public void Remove(CanBeInHand card)
        {
            Cards.Remove(card);
            card.RemovedFromHand();

            for (int i = 0; i < Cards.Count; i++)
            {
                Cards[i].OnIndexChanged(i, Cards.Count);
            }
        }
    }
}
