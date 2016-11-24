using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carty.CartyLib
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

        /// <summary>
        /// Dynamic setting for how many cards players draw for each turn. See CardDrawSettingDelegate.
        /// </summary>
        public CardDrawSettingDelegate TurnStartCardDrawSetting { get; set; }

        /// <summary>
        /// Default turn start card draw settings. Always draw one card. See TurnStartCardDrawSetting.
        /// </summary>
        public int DefaultTurnStartCardDrawSetting(int turn, bool player, bool playerWentFirst)
        {
            return 1;
        }

        /// <summary>
        /// Delegate for TurnStartCardDrawSetting.
        /// </summary>
        /// <param name="turn">Turn count. One-based separately counted for each player.</param>
        /// <param name="player">Whether it is player's turn or enemy's turn.</param>
        /// <param name="playerWentFirst">Whether player went first in the first turn.</param>
        /// <returns></returns>
        public delegate int CardDrawSettingDelegate(int turn, bool player, bool playerWentFirst);

        public GameSettings()
        {
            MaxCardsInHand = 10;
            TurnStartCardDrawSetting = DefaultTurnStartCardDrawSetting;
        }
    }
}
