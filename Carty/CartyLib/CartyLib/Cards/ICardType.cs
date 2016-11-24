using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carty.CartyLib
{
    /// <summary>
    /// Basic information about a card type.
    /// </summary>
    public struct CardInfo
    {
        /// <summary>
        /// Name-identifier of the card type.
        /// Must be unique among all card types.
        /// Creating an instance of a card of this type is done using this identifier.
        /// </summary>
        public string UniqueCardTypeId;

        /// <summary>
        /// Resource cost of playing the card.
        /// Is displayed on the card's front.
        /// </summary>
        public int Cost;

        /// <summary>
        /// Name of the texture of the card front.
        /// Search order:
        ///     1. Resources folder + VisualManager.Instance.CardTexturesPath
        ///     2. Resources folder
        /// </summary>
        public string CardFrontTexture;
    }


    /// <summary>
    /// A bare minimum interface to consider a MonoBeaviour a card.
    /// </summary>
    public interface ICardType
    {
        /// <summary>
        /// Get basic information about the card.
        /// See CardInfo structure.
        /// </summary>
        /// <returns>Filled CardInfo structure.</returns>
        CardInfo GetInfo();
    }
}
