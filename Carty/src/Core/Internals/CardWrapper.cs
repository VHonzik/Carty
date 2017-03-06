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
        /// Game object for visual representation of the card.
        /// This is driven by Visuals side of the Carty engine.
        /// </summary>
        public GameObject CardVisuals;

        /// <summary>
        /// Release all resources associated with the card.
        /// </summary>
        public void Destroy()
        {

        }
    }
}
