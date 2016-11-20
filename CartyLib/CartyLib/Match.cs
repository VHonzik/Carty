using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartyLib
{
    /// <summary>
    /// Information about initial state or player and enemy decks, boards and hands.
    /// Only applied once at the start of the game.
    /// </summary>
    public class MatchInfo
    {
        /// <summary>
        /// Default ctor. Equals completely empty match.
        /// </summary>
        public MatchInfo()
        {
            PlayerDeckCards = new string[0];
            PlayerStartingHandCards = new string[0];
            EnemyDeckCards = new string[0];
            EnemyStartingHandCards = new string[0];
        }

        /// <summary>
        /// Array of cards to be created in player's deck.
        /// The order of cards in this array is the order of draw from deck. 
        /// </summary>
        public string[] PlayerDeckCards { get; set; }

        /// <summary>
        /// Array of cards to be created in player's hand.
        /// These are not taken from deck, for that use PlayerAmountOfCardDrawBeforeGame.
        /// Length of this + PlayerAmountOfCardDrawBeforeGame shouldn't be larger than GameManager.Instance.GameSettings.MaxCardsInHand.
        /// The order of cards in this array is the order of them in hand (from left to right). 
        /// </summary>
        public string[] PlayerStartingHandCards;

        /// <summary>
        /// Amount of resource player starts with before first turn ticks in.
        /// </summary>
        public int PlayerStartingResource;

        /// <summary>
        /// Amount of cards taken from the top of players's deck to form a starting hand of player.
        /// This + length of PlayerStartingHandCards shouldn't be larger than GameManager.Instance.GameSettings.MaxCardsInHand.
        /// The cards are added to the hand after PlayerStartingHandCards in order they were in deck from left to right.
        /// </summary>
        public int PlayerAmountOfCardDrawBeforeGame;

        /// <summary>
        /// Array of cards to be created in enemy's deck.
        /// The order of cards in this array is the order of draw from deck. 
        /// </summary>
        public string[] EnemyDeckCards;

        /// <summary>
        /// Array of cards to be created in enemy's hand.
        /// These are not taken from deck, for that use EnemyAmountOfCardDrawBeforeGame.
        /// Length of this + EnemyAmountOfCardDrawBeforeGame shouldn't be larger than GameManager.Instance.GameSettings.MaxCardsInHand.
        /// The order of cards in this array is the order of them in hand (from left to right). 
        /// </summary>
        public string[] EnemyStartingHandCards;

        /// <summary>
        /// Amount of resource enemy starts with before the first turn ticks in.
        /// </summary>
        public int EnemyStartingResource;

        /// <summary>
        /// Amount of cards taken from the top of enemy's deck to form a starting hand of enemy.
        /// This + length of EnemyStartingHandCards shouldn't be larger than GameManager.Instance.GameSettings.MaxCardsInHand.
        /// The cards are added to the hand after EnemyStartingHandCards in order they were in deck from left to right.
        /// </summary>
        public int EnemyAmountOfCardDrawBeforeGame;
    }
}
