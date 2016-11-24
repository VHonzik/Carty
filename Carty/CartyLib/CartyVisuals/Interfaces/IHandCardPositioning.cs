using UnityEngine;

namespace Carty.CartyVisuals
{
    /// <summary>
    /// Interface for customization of how are cards held in players hand.
    /// </summary>
    public interface IHandCardPositioning
    {
        /// <summary>
        /// Position a card should have when it occupies specified index of player hand.
        /// </summary>
        /// <param name="index">Zero-based index of the card in hand from left to right. Should be less than cards parameter.</param>
        /// <param name="cards">Number of cards in the hand. Should be less than GameManager.Instance.Settings.MaxCardsInHand.</param>
        /// <returns>Wanted world position.</returns>
        Vector3 PositionPlayer(int index, int cards);

        /// <summary>
        /// Rotation a card should have when it occupies specified index of player hand.
        /// </summary>
        /// <param name="index">Zero-based index of the card in hand from left to right. Should be less than cards parameter.</param>
        /// <param name="cards">Number of cards in the hand. Should be less than GameManager.Instance.Settings.MaxCardsInHand.</param>
        /// <returns>Wanted rotation.</returns>
        Quaternion RotationPlayer(int index, int cards);

        /// <summary>
        /// Position a card should have when it occupies specified index of enemy hand.
        /// </summary>
        /// <param name="index">Zero-based index of the card in hand from left to right. Should be less than cards parameter.</param>
        /// <param name="cards">Number of cards in the hand. Should be less than GameManager.Instance.Settings.MaxCardsInHand.</param>
        /// <returns>Wanted world position.</returns>
        Vector3 PositionEnemy(int index, int cards);

        /// <summary>
        /// Rotation a card should have when it occupies specified index of enemy hand.
        /// </summary>
        /// <param name="index">Zero-based index of the card in hand from left to right. Should be less than cards parameter.</param>
        /// <param name="cards">Number of cards in the hand. Should be less than GameManager.Instance.Settings.MaxCardsInHand.</param>
        /// <returns>Wanted rotation.</returns>
        Quaternion RotationEnemy(int index, int cards);
    }
}
