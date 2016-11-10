using UnityEngine;

namespace CartyVisuals
{
    /// <summary>
    /// Interface for customization of how are cards stacked in players deck.
    /// </summary>
    public interface IDeckCardPositioning
    {
        /// <summary>
        /// Position a card should have when it occupies specified index of player deck.
        /// </summary>
        /// <param name="index">Zero-based index of the card in the deck from bottom to top. Should be less than cards parameter.</param>
        /// <param name="cards">Number of cards in the deck.</param>
        /// <returns>Wanted world position.</returns>
        Vector3 PositionPlayer(int index, int cards);

        /// <summary>
        /// Rotation a card should have when it occupies specified index of player deck.
        /// </summary>
        /// <param name="index">Zero-based index of the card in the deck from bottom to top. Should be less than cards parameter.</param>
        /// <param name="cards">Number of cards in the deck.</param>
        /// <returns>Wanted rotation.</returns>
        Quaternion RotationPlayer(int index, int cards);

        /// <summary>
        /// Position a card should have when it occupies specified index of enemy deck.
        /// </summary>
        /// <param name="index">Zero-based index of the card in the deck from bottom to top. Should be less than cards parameter.</param>
        /// <param name="cards">Number of cards in the deck.</param>
        /// <returns>Wanted world position.</returns>
        Vector3 PositionEnemy(int index, int cards);

        /// <summary>
        /// Rotation a card should have when it occupies specified index of enemy deck.
        /// </summary>
        /// <param name="index">Zero-based index of the card in the deck from bottom to top. Should be less than cards parameter.</param>
        /// <param name="cards">Number of cards in the deck.</param>
        /// <returns>Wanted rotation.</returns>
        Quaternion RotationEnemy(int index, int cards);
    }
}
