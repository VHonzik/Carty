using CartyLib.BoardComponents;
using CartyLib.CardsComponenets;
using CartyVisuals;
using UnityEngine;

namespace CartyLib
{
    /// <summary>
    /// Class responsible for assembling cards and other board game objects and adding all necessary components.
    /// </summary>
    public class CartyEntitiesConstructors
    {
        /// <summary>
        /// Assembles a hand.
        /// </summary>
        /// <param name="player">Whether the hand is owned by player.</param>
        /// <returns>Created hand object.</returns>
        public static Hand CreateHand(bool player)
        {
            GameObject go = new GameObject( player ? "PlayerHand" : "EnemyHand");
            go.transform.position = player ? VisualManager.Instance.PlayerHandPosition : VisualManager.Instance.EnemyHandPosition;
            var result = go.AddComponent<Hand>();
            result.PlayerOwned = player;
            return result;
        }

        /// <summary>
        /// Assembles a deck.
        /// </summary>
        /// <param name="player">Whether the deck is owned by player.</param>
        /// <returns>Created deck object.</returns>
        public static Deck CreateDeck(bool player)
        {
            GameObject go = new GameObject(player ? "PlayerDeck" : "EnemyDeck");
            var result = go.AddComponent<Deck>();
            result.PlayerOwned = player;
            return result;
        }
    }
}
