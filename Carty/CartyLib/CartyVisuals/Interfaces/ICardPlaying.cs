using UnityEngine;

namespace Carty.CartyVisuals
{
    /// <summary>
    /// Interface for customization of details of playing cards.
    /// </summary>
    public interface ICardPlaying
    {

        /// <summary>
        /// When a dragged player card is considered outside of the hand area.
        /// Dragged card which is released while this is true is considered played.
        /// Dragged card which is released while this is false is returned to hand.
        /// </summary>
        /// <param name="cardPosition">Position of the card.</param>
        /// <returns>Whether the card is outside of hand area.</returns>
        bool IsOutsideOfHandArea(Vector3 cardPosition);
    }
}
