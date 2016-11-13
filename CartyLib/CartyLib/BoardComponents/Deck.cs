using CartyLib.Internals.CardsComponents;
using CartyVisuals;
using System.Collections.Generic;
using UnityEngine;

namespace CartyLib.Internals.BoardComponents
{
    /// <summary>
    /// Component representing a deck of player or enemy.
    /// </summary>
    public class Deck : MonoBehaviour
    {
        /// <summary>
        /// Whether it is a player deck or an enemy deck.
        /// </summary>
        public bool PlayerOwned { get; set; }

        /// <summary>
        /// Assembles a deck.
        /// </summary>
        /// <param name="player">Whether the deck is owned by player.</param>
        /// <returns>Created deck object.</returns>
        public static Deck CreateDeck(bool player)
        {
            GameObject go = new GameObject(player ? "PlayerDeck" : "EnemyDeck");
            go.transform.position = player ? VisualManager.Instance.PlayerDeckPosition : VisualManager.Instance.EnemyDeckPosition;
            var result = go.AddComponent<Deck>();
            result.PlayerOwned = player;
            return result;
        }
    }
}
