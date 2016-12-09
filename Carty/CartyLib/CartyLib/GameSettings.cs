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
        /// Dynamic setting for how many resources players receive on each turn. See ResourceIncreaseSettingDelegate.
        /// </summary>
        public ResourceIncreaseSettingDelegate TurnStartResourceIncreaseSetting { get; set; }

        /// <summary>
        /// Default turn start card draw settings. Always draw one card. See TurnStartCardDrawSetting.
        /// </summary>
        public int DefaultTurnStartCardDrawSetting(int turn, bool player, bool playerWentFirst)
        {
            return 1;
        }

        /// <summary>
        /// Default turn start resource increase settings. Always receive 1 resource, cap at 10. See TurnStartResourceIncreaseSetting.
        /// </summary>
        public int DefaultTurnStartResourceIncreaseSetting(int turn, bool player, bool playerWentFirst, int currentResources)
        {
            if(currentResources < 10)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        /// <summary>
        /// Delegate for TurnStartCardDrawSetting.
        /// </summary>
        /// <param name="turn">Turn count. One-based separately counted for each player.</param>
        /// <param name="player">Whether it is player's turn or enemy's turn.</param>
        /// <param name="playerWentFirst">Whether player went first in the first turn.</param>
        /// <returns>How many cards to draw.</returns>
        public delegate int CardDrawSettingDelegate(int turn, bool player, bool playerWentFirst);

        /// <summary>
        /// Delegate for TurnStartResourceIncreaseSetting.
        /// </summary>
        /// <param name="turn">Turn count. One-based separately counted for both player and enemy.</param>
        /// <param name="player">Whether it is player's turn or enemy's turn.</param>
        /// <param name="playerWentFirst">Whether player went first in the first turn.</param>
        /// <param name="currentResources">How many resources player or enemy have currently.</param>
        /// <returns>How many resources to obtain.</returns>
        public delegate int ResourceIncreaseSettingDelegate(int turn, bool player, bool playerWentFirst, int currentResources);

        public GameSettings()
        {
            MaxCardsInHand = 10;
            TurnStartCardDrawSetting = DefaultTurnStartCardDrawSetting;
            TurnStartResourceIncreaseSetting = DefaultTurnStartResourceIncreaseSetting;
        }
    }
}
