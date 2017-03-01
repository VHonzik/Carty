namespace Carty.Core.Cards
{
    /// <summary>
    /// Basic information about a card type.
    /// </summary>
    public interface ICardType
    {
        /// <summary>
        /// Name identifier of the card type.
        /// Must be unique among all card types.
        /// The value must never change.
        /// Creating an instance of a card of this type is done using this identifier.
        /// </summary>
        string UniqueCardTypeId { get; }

        /// <summary>
        /// Resource cost of playing the card.
        /// The value must never change. 
        /// For modifying cards cost there are other mechanisms.
        /// </summary>
        int Cost { get; }
    }
}