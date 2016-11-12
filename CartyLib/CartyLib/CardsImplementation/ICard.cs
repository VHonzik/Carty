using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartyLib
{
    public struct CardInfo
    {
        /// <summary>
        /// Name-identifier of the card type.
        /// Must be unique among all card types.
        /// Creating an instance of a card of this type is done using this identifier.
        /// </summary>
        public string UniqueCardTypeId;

        /// <summary>
        /// Title displayed on the card's front.
        /// Depending on the card visuals and font chosen, care should be taken regarding the length of the title.
        /// </summary>
        public string Title;

        /// <summary>
        /// Description of the card displayed on the card's front.
        /// Depending on the card visuals and font chosen, care should be taken regarding the length of the description.
        /// </summary>
        public string Description;

        /// <summary>
        /// Resource cost of playing the card.
        /// Is displayed on the card's front.
        /// </summary>
        public int Cost;
    }

    /// <summary>
    /// A bare minimum interface to consider a MonoBeaviour a card.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Get basic information about the card.
        /// See CardInfo structure.
        /// </summary>
        /// <returns>Filled CardInfo structure.</returns>
        CardInfo GetInfo();
    }
}
