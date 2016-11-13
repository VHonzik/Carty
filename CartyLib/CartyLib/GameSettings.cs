using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartyLib
{
    /// <summary>
    /// Game logic oriented settings and rules.
    /// </summary>
    public class GameSettings
    {
        /// <summary>
        /// Maximal number of cards which can be in hand at one time.
        /// If a player would obtain additional card over MaxCardsInHand, the card is destroyed.
        /// </summary>
        public int MaxCardsInHand { get; set; }

        public GameSettings()
        {
            MaxCardsInHand = 10;
        }
    }
}
