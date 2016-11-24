using System.Collections;
using UnityEngine;

namespace Carty.CartyVisuals
{
    /// <summary>
    /// Interface for customization of low-level card movement.
    /// Low level in this case means for example how a card moves from a one place to another.
    /// </summary>
    public interface ILowLevelCardMovement
    {
        /// <summary>
        /// Move the card from its current position to a new position.
        /// </summary>
        /// <param name="card">The card to move.</param>
        /// <param name="position">A wanted position.</param>
        /// <returns>Coroutine.</returns>
        IEnumerator Move(GameObject card, Vector3 position);

        /// <summary>
        /// Move the card instantaneously from its current position to a new position.
        /// </summary>
        /// <param name="card">The card to move.</param>
        /// <param name="position">A wanted position.</param>
        /// <returns>Coroutine.</returns>
        IEnumerator MoveInstantly(GameObject card, Vector3 position);

        /// <summary>
        /// Rotate card from its current rotation to a new rotation.
        /// </summary>
        /// <param name="card">The card to rotate.</param>
        /// <param name="rotation">A wanted rotation.</param>
        /// <returns>Coroutine.</returns>
        IEnumerator Rotate(GameObject card, Quaternion rotation);

        /// <summary>
        /// Rotate card instantaneously from its current rotation to a new rotation.
        /// </summary>
        /// <param name="card">The card to rotate.</param>
        /// <param name="rotation">A wanted rotation.</param>
        /// <returns>Coroutine.</returns>
        IEnumerator RotateInstantly(GameObject card, Quaternion rotation);

        /// <summary>
        /// Flip card between front and back.
        /// </summary>
        /// <param name="card">A card to flip.</param>
        /// <returns>Coroutine.</returns>
        IEnumerator Flip(GameObject card);

        /// <summary>
        /// Flip card instantaneously between front and back.
        /// </summary>
        /// <param name="card">A card to flip.</param>
        /// <returns>Coroutine.</returns>
        IEnumerator FlipInstantly(GameObject card);
    }
}
