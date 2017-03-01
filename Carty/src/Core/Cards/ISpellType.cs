namespace Carty.Core.Cards
{
    /// <summary>
    /// A card of spell type.
    /// Spells neither have target nor create any minions.
    /// When played their OnCast callback is triggered and once it evaluates, they are destroyed.
    /// </summary>
    public interface ISpellType
    {
        /// <summary>
        /// Callback triggered when the spell was cast.
        /// </summary>
        /// <param name="state">Interface to interact with game. See IGame.</param>
        void OnCast(IGame state);
    }
}