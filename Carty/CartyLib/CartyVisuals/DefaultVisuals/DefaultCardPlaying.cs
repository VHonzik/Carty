using System;
using UnityEngine;

namespace Carty.CartyVisuals.Defaults
{
    /// <summary>
    /// Default implementation of ICardPlaying.
    /// Card is outside of the player hand when it its z coordinate is big enough.
    /// </summary>
    class DefaultCardPlaying : ICardPlaying
    {
        public bool IsOutsideOfHandArea(Vector3 cardPosition)
        {
            return cardPosition.z > -1.9f;
        }
    }
}
