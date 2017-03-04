using Carty.Core;
using Carty.Core.Internals;
using Carty.Visuals.Internals;
using UnityEngine;

namespace Carty.Visuals
{
    public class VisualsManager
    {
        private static VisualsManager _the_one_and_only;
        /// <summary>
        /// Singleton accessor.
        /// </summary>
        public static VisualsManager Instance
        {
            get
            {
                if (_the_one_and_only == null)
                {
                    _the_one_and_only = new VisualsManager();
                }

                return _the_one_and_only;
            }
        }

        /// <summary>
        /// See Deck.CardInDeckInstantPositionChange
        /// </summary>
        internal void PositionCardInPlayerDeckInstantly(CardWrapper card, int cardPositionInDeck, int deck)
        {
            
        }

        /// <summary>
        /// Subscribe to all of the visuals events in Core.
        /// </summary>
        /// <param name="gameManager">GameManager instance to avoid going through singleton.</param>
        internal void HookUpEvents(GameManager gameManager)
        {
            gameManager.PlayerDeck.CardInDeckInstantPositionChange += PositionCardInPlayerDeckInstantly;
        }
    }
}