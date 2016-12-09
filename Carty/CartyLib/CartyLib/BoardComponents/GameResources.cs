using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyVisuals;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.CartyLib.Internals.BoardComponents
{
    /// <summary>
    /// Component representing resources of player or enemy.
    /// </summary>
    public class GameResources : MonoBehaviour
    {
        /// <summary>
        /// Whether these are player resources.
        /// </summary>
        public bool PlayerOwned { get; private set; }

        /// <summary>
        /// Total amount of resources including already spent ones.
        /// Spent resources refresh each frame.
        /// </summary>
        public int ResourcesCount;

        /// <summary>
        /// Amount of resources still available in the current turn.
        /// </summary>
        public int ResourcesAvailable;

        /// <summary>
        /// Assembles resources.
        /// </summary>
        /// <param name="player">Whether they are players' resources.</param>
        /// <returns>Created Resources object.</returns>
        public static GameResources CreateResources(bool player)
        {
            GameObject go = new GameObject(player ? "PlayerResources" : "EnemyResources");
            var result = go.AddComponent<GameResources>();
            result.PlayerOwned = player;
            return result;
        }

        /// <summary>
        /// Initialize resources before the first turn stars.
        /// </summary>
        /// <param name="initialAmountOfResources">Starting amount of resources.</param>
        public void Init(int initialAmountOfResources)
        {
            ResourcesCount = initialAmountOfResources;
            ResourcesAvailable = initialAmountOfResources;
        }

        /// <summary>
        /// Start a new turn. Refreshes all spent resources.
        /// </summary>
        /// <param name="increaseAmount">Amount by which ResourcesCount should be increased.</param>
        public void TurnStart(int increaseAmount)
        {
            ResourcesCount += increaseAmount;
            ResourcesAvailable = ResourcesCount;
        }
    }
}
