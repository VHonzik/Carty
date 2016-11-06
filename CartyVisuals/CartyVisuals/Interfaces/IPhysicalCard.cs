using System.Collections;
using UnityEngine;

namespace CartyVisuals
{
    /// <summary>
    /// Interface for customization of actual card outlook.
    /// </summary>
    public interface IPhysicalCard
    {
        /// <summary>
        /// Creates an object which physically represents the card.
        /// </summary>
        /// <returns>Created game object.</returns>
        GameObject CreatePhysicalCardObject();
    }
}
