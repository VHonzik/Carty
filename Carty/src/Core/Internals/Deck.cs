using Carty.Visuals;
using System.Collections.Generic;

namespace Carty.Core.Internals
{
    /// <summary>
    /// A deck from which cards are drawn.
    /// </summary>
    internal class Deck
    {
        /// <summary>
        /// List of cards in the deck.
        /// </summary>
        public List<CardWrapper> Cards { get; private set; }

        /// <summary>
        /// Triggered when a card position needs to be updated instantly to match a certain position in a deck.
        /// </summary>
        public event DeckCardPositionDelegate CardInDeckInstantPositionChange;

        /// <summary>
        /// Immediately destroy all cards in the deck.
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
        /// Gets a first card on the top of the deck and removes it from the deck.
        /// </summary>
        /// <returns>The very top card or null.</returns>
        public CardWrapper PopCard()
        {
            if (Cards.Count > 0)
            {
                CardWrapper result = Cards[0];
                Cards.RemoveAt(0);
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Fills deck with cards of specified card types.
        /// </summary>
        /// <param name="cardsTypes">Cards' types. The order of cards in the array is the order of draw from deck. </param>
        public void FillWithCards(string[] cardsTypes)
        {
            if (Cards == null) Cards = new List<CardWrapper>(cardsTypes.Length);
            for (int i = 0; i < cardsTypes.Length; i++)
            {
                var card = GameManager.Instance.CardManager.CreateCard(cardsTypes[i]);
                if(CardInDeckInstantPositionChange != null) CardInDeckInstantPositionChange(card.CardVisuals , 0, cardsTypes.Length);
                Cards.Add(card);
            }
        }
    }
}