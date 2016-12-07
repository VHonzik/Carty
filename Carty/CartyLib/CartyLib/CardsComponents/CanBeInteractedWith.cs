using Carty.CartyVisuals;
using UnityEngine;

namespace Carty.CartyLib.Internals.CardsComponents
{
    /// <summary>
    /// Component responsible for enabling/preventing interaction with the card through other components.
    /// </summary>
    public class CanBeInteractedWith : MonoBehaviour
    {
        /// <summary>
        /// Whether the card should allow interaction.
        /// </summary>
        public bool InteractionAllowed { get; set; }

        void Start()
        {
            InteractionAllowed = false;
        }

    }
}
