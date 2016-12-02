using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carty.CartyLib
{
    /// <summary>
    /// Helper class for convenient building of decks to be used in MatchInfo arrays.
    /// </summary>
    public class DeckBuilder
    {
        private List<string> Cards { get; set; }
        /// <summary>
        /// Create a new deck builder instance with no cards.
        /// </summary>
        public DeckBuilder()
        {
            Cards = new List<string>();
        }

        /// <summary>
        /// Add an amount of cards of the same type to the deck.
        /// </summary>
        /// <param name="card">Card type id. See ICardType.</param>
        /// <param name="amount">Amount of cards to add. Default 1.</param>
        public void Add(string card, int amount = 1)
        {
            for(int i=0; i < amount; i++)
            {
                Cards.Add(card);
            }            
        }

        /// <summary>
        /// Output an array of cards.
        /// </summary>
        /// <returns>Array of cards in the same order they were added.</returns>
        public string[] ToArray()
        {
            return Cards.ToArray();
        }
    }
}
