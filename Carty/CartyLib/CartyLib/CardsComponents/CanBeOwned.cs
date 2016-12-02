using UnityEngine;

namespace Carty.CartyLib.Internals.CardsComponents
{
    /// <summary>
    /// Component responsible for keep track of who owns the card.
    /// </summary>
    public class CanBeOwned : MonoBehaviour
    {
        /// <summary>
        /// True if player owns the card, false otherwise.
        /// </summary>
        public bool PlayerOwned { get; set; }
    }
}
