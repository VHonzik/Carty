namespace Carty.Core.Cards
{
    /// <summary>
    /// Interface between cards implementation and game logic.
    /// Any manipulation of game state from cards implementations goes through IGame.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Deal an amount of damage to the opponent of the owner of the card.
        /// </summary>
        /// <param name="amount">Amount of damage.</param>
        void DealDamageToOpponent(int amount);

        /// <summary>
        /// Deal an amount of damage to the owner of the card.
        /// </summary>
        /// <param name="amount">Amount of damage.</param>
        void DealDamageToSelf(int amount);

        /// <summary>
        /// Heal an amount of damage to the opponent of the owner of the card.
        /// </summary>
        /// <param name="amount">Amount of damage to heal.</param>
        void HealOpponent(int amount);

        /// <summary>
        /// Heal an amount of damage to the owner of the card.
        /// </summary>
        /// <param name="amount">Amount of damage to heal.</param>
        void HealSelf(int amount);
    }
}