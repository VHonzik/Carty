namespace Carty.CartyLib
{
    /// <summary>
    /// Card of spell type.
    /// Spells neither have target nor create any minions.
    /// When dropped on board they simply trigger the OnCast callback and are destroyed.
    /// </summary>
    public interface ISpell
    {
        /// <summary>
        /// Triggered when the spell was cast.
        /// </summary>
        /// <param name="state">GameState to interact with game. See IGameState.</param>
        void OnCast(IGameState state);
    }
}
