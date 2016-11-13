using CartyLib.Internals;
using CartyLib.Internals.BoardComponents;
using UnityEngine;

namespace CartyLib
{
    /// <summary>
    /// Facade singleton for the CartyLib inner-workings.
    /// Initializes all necessary subsystems and starts a match of Carty game.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

        /// <summary>
        /// Hand of the player.
        /// </summary>
        public Hand PlayerHand { get; private set; }

        /// <summary>
        /// Hand of the enemy.
        /// </summary>
        public Hand EnemyHand { get; private set; }

        /// <summary>
        /// Deck of the player.
        /// </summary>
        public Deck PlayerDeck { get; private set; }

        /// <summary>
        /// Deck of the enemy.
        /// </summary>
        public Deck EnemyDeck { get; private set; }

        /// <summary>
        /// Game logic oriented settings and rules.
        /// To modify them simply change the values inside.
        /// </summary>
        public GameSettings Settings { get; private set; }

        private CardManager _cardManager;
        /// <summary>
        /// Card manager instance.
        /// </summary>
        public CardManager CardManager
        {
            get
            {
                if (_cardManager == null)
                {
                    _cardManager = new CardManager();
                }

                return _cardManager;
            }
        }

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            CardManager.Initialize();
            Settings = new GameSettings();
        }

        private void CreateBoardObjects()
        {
            PlayerHand = Hand.CreateHand(true);
            EnemyHand = Hand.CreateHand(false);
            PlayerDeck = Deck.CreateDeck(true);
            EnemyDeck = Deck.CreateDeck(false);
        }

        public void StartMatch()
        {
            CreateBoardObjects();
        }
    }
}
