using Carty.Visuals;
using System.Collections.Generic;
using System.Linq;

namespace Carty.Core.Internals
{
    /// <summary>
    /// A hand from which cards are played.
    /// </summary>
    internal class Hand
    {
        /// <summary>
        /// List of cards in the hand.
        /// </summary>
        public List<CardWrapper> Cards { get; private set; }

        public Hand()
        {
            Cards = new List<CardWrapper>();
        }

        /// <summary>
        /// Immediately destroy all cards in the hand.
        /// </summary>
        public void CleanUp()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                GameManager.Instance.CardManager.FindAndDestroy(Cards[i]);
            }

            Cards.Clear();
        }

        /// <summary>
        /// Triggered when a card was added to the hand and it is moved to its new position,
        /// while the already present cards in hand are adjusted.
        /// </summary>
        public event AddingCardToHandDelegate CardAddedToHand;

        /// <summary>
        /// Adds a card into the hand.
        /// </summary>
        /// <param name="card">Card to be added.</param>
        public void AddCard(CardWrapper card)
        {            
            if (CardAddedToHand != null) CardAddedToHand(card.CardID, Cards.Count, 
                Cards.Select(c => c.CardID));
            Cards.Add(card);
        }
    }
}


   