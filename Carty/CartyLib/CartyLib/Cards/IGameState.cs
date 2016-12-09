namespace Carty.CartyLib
{
    /// <summary>
    /// Bridge between cards implementation and game logic.
    /// Any manipulation of game state from cards implementation goes through IGameState.
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// Deal an amount of damage to the opponent of the owner of the card.
        /// If the player's health goes below 1 he looses. If the enemy's health goes below 1 player wins.
        /// </summary>
        /// <param name="damage">Amount of damage.</param>
        void DealDamageToOpponent(int damage);

        /// <summary>
        /// Deal an amount of damage to the owner of the card.
        /// If the player's health goes below 1 he looses. If the enemy's health goes below 1 player wins.
        /// </summary>
        /// <param name="damage">Amount of damage.</param>
        void DealDamageToSelf(int damage);
    }
}
