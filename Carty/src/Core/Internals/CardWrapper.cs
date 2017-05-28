using Carty.Core.Cards;
using UnityEngine;

namespace Carty.Core.Internals
{
    /// <summary>
    /// Wrapper around visuals side of card and core logic side of card.
    /// </summary>
    internal class CardWrapper
    {
        /// <summary>
        /// A top level type of the card common to all cards.
        /// </summary>
        public ICardType CardType = null;

        /// <summary>
        /// Whether this card is of type spell.
        /// </summary>
        public bool IsSpell = false;

        /// <summary>
        /// If IsSpell is true, this is pointer to spell type of the card.
        /// </summary>
        public ISpellType Spell = null;

        /// <summary>
        /// Unique ID of the card.
        /// Used by Carty Core to talk to the Visuals side of the engine.
        /// </summary>
        public int CardID;

        /// <summary>
        /// Release all resources associated with the card.
        /// </summary>
        public void Destroy()
        {

        }
    }
}
