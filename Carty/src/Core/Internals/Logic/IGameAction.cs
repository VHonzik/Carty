using System.Collections.Generic;

namespace Carty.Core.Internals.Logic
{
    /// <summary>
    /// A general game logic action.
    /// An action calls into cards implementation and that in turn can spawn more actions.
    /// All children actions are evaluated depth first.
    /// </summary>
    internal interface IGameAction
    {
        List<IGameAction> Children { get; }
        void Evaluate();
    }
}