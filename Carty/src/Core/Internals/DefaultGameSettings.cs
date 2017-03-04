namespace Carty.Core.Internals
{
    /// <summary>
    /// Default game settings rules.
    /// </summary>
    internal class DefaultGameSettings : GameSettings
    {
        /// <summary>
        /// Default turn start card draw rule. 
        /// Always draw one card.
        /// </summary>
        public int DefaultCardRule(int turn, bool player, bool playerWentFirst)
        {
            return 1;
        }

        /// <summary>
        /// Default turn start resource increase settings. 
        /// Always receive 1 resource, cap at 10.
        /// </summary>
        public int DefaultResourceIncreaseRule(int turn, bool player, bool playerWentFirst, int currentResources)
        {
            if (currentResources < 10)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public DefaultGameSettings()
        {
            MaxCardsInHand = 10;
            TurnStartCardRule = DefaultCardRule;
            TurnStartResourceIncreaseRule = DefaultResourceIncreaseRule;
        }
    }

}