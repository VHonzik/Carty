using Carty.CartyLib.Internals.CardsComponents;
using System.Collections;

namespace Carty.CartyVisuals
{
    /// <summary>
    /// Interface customization of high level movement of cards.
    /// High level movement is a move to a concrete place triggered by a specific game mechanic. 
    /// It utilizes low level movement to achieve a particular spatial state of a card.
    /// Think when a player draws a card there is a specific movement of a card from deck to hand,
    /// high level movement knows the card is moving from deck to hand and tells low level movement to do the heavy lifting.
    /// </summary>
    public interface IHighLevelCardMovement
    {
        /// <summary>
        /// First step of player drawing card when it is flipped and moved to display area.
        /// Display area is generally defined by VisualManager.Instance.PlayerShowDrawnCardPosition.
        /// </summary>
        /// <param name="card">Card in deck to move to display area.</param>
        /// <returns>Coroutine which finishes after it is done moving.</returns>
        IEnumerator MoveCardFromDeckToDrawDisplayArea(CanBeMoved card);
    }
}
