using Carty.Core.Internals;
using UnityEngine;

namespace Carty.Core
{
    /// <summary>
    /// Facade singleton for the Carty inner-workings.
    /// Initializes all necessary subsystems and starts a match of Carty game.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton accessor.
        /// </summary>
        public static GameManager Instance { get; set; }

        /// <summary>
        /// Deck of the player.
        /// </summary>
        internal Deck PlayerDeck { get; private set; }

        /// <summary>
        /// Card manager instance. See CardManager class.
        /// </summary>
        internal CardManager CardManager { get; private set; }

        void Awake()
        {
            CardManager = new CardManager();
            CardManager.Initialize();
        }
    }
}