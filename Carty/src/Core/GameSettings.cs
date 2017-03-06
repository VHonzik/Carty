namespace Carty.Core
{
    /// <summary>
    /// Class for game logic settings and rules.
    /// </summary>
    public class GameSettings
    {
        /// <summary>
        /// Maximal number of cards which can be in hand at one time.
        /// If a player would obtain additional card over MaxCardsInHand, the card is destroyed.
        /// </summary>
        public int MaxCardsInHand { get; set; }

        /// <summary>
        /// Default amount of health player's or enemy's hero starts with.
        /// Also determines maximal amount of health hero can have.
        /// Can be overwritten per match basis. See MatchInfo.
        /// </summary>
        public int StartingHeroHealth { get; set; }

        /// <summary>
        /// Rule for how many cards player and enemy draw each turn. 
        /// See CardDrawRule delegate.
        /// </summary>
        public CardDrawRule TurnStartCardRule { get; set; }

        /// <summary>
        /// Delegate for TurnStartCardRule rule.
        /// </summary>
        /// <param name="turn">Turn count. One-based separately counted for each player.</param>
        /// <param name="player">Whether it is player's turn or enemy's turn.</param>
        /// <param name="playerWentFirst">Whether player went first in the first turn.</param>
        /// <returns>How many cards to draw.</returns>
        public delegate int CardDrawRule(int turn, bool player, bool playerWentFirst);

        /// <summary>
        /// Rule for how many resources player and enemy receive each turn. 
        /// See ResourceIncreaseRule.
        /// </summary>
        public ResourceIncreaseRule TurnStartResourceIncreaseRule { get; set; }

        /// <summary>
        /// Delegate for TurnStartResourceIncreaseRule rule.
        /// </summary>
        /// <param name="turn">Turn count. One-based separately counted for both player and enemy.</param>
        /// <param name="player">Whether it is player's turn or enemy's turn.</param>
        /// <param name="playerWentFirst">Whether player went first in the first turn.</param>
        /// <param name="currentResources">How many resources player or enemy have currently.</param>
        /// <returns>How many resources to obtain.</returns>
        public delegate int ResourceIncreaseRule(int turn, bool player, bool playerWentFirst, int currentResources);
    }
}