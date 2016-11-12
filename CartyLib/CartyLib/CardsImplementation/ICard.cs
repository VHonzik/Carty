using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartyLib.CardsImplementation
{
    /// <summary>
    /// A bare minimum interface to consider a MonoBeaviour a card.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Unique name-identifier of the card type.
        /// Creating an instance of a card of this type is done using this identifier.
        /// </summary>
        /// <returns>Name of the card type. Must be unique among all cards.</returns>
        string GetUniqueID();

        /// <summary>
        /// Title displayed on the card front.
        /// Depending on the card visuals and font chosen, care should be taken regarding the length of the title.
        /// </summary>
        /// <returns>Any string.</returns>
        string GetTitle();

        /// <summary>
        /// Description of the card displayed on the card front.
        /// Depending on the card visuals and font chosen, care should be taken regarding the length of the description.
        /// </summary>
        /// <returns>Any string.</returns>
        string GetDescription();

        /// <summary>
        /// Resource cost of playing the card.
        /// </summary>
        /// <returns></returns>
        int GetCost();
    }
}
