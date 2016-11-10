using CartyLib.CardsComponenets;
using CartyVisuals;
using System.Collections.Generic;
using UnityEngine;

namespace CartyLib.BoardComponents
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
    }
}
