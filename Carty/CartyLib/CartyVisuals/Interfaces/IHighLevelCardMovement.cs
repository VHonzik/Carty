using Carty.CartyLib.Internals.CardsComponents;
using System.Collections;
using UnityEngine;

namespace Carty.CartyVisuals
{
    /// <summary>
    /// Interface customization of high level movement of cards.
    /// High level movement is a move to a concrete place triggered by a specific game mechanic. 
    /// It utilizes low level movement to achieve a particular spatial state of a card.
    /// Think when a player draws a card there is a specific movement of a card from deck to hand.
    /// High level movement knows the card is moving from deck to hand and tells low level movement to do the heavy lifting.
    /// </summary>
    public interface IHighLevelCardMovement
    {
        /// <summary>
        /// First step of player drawing a card when it is flipped and moved to display area.
        /// Display area is generally defined by VisualManager.Instance.PlayerShowDrawnCardPosition.
        /// </summary>
        /// <param name="card">Card in deck to move to display area.</param>
        /// <returns>Coroutine which finishes after the move is done.</returns>
        IEnumerator MoveCardFromDeckToDrawDisplayArea(VisualCardWrapper card);

        /// <summary>
        /// Second step of player drawing a card when it is moved from display area to the hand.
        /// </summary>
        /// <param name="card">Card in deck to moved to hand.</param>
        /// <param name="wantedPosition">Wanted position as determined by current state of player hand.</param>
        /// <param name="wantedRotation">Wanted rotation as determined by current state of player hand.</param>
        /// <returns>Coroutine which finishes after the move is done.</returns>
        IEnumerator MoveCardFromDisplayAreaToHand(VisualCardWrapper card, Vector3 wantedPosition, Quaternion wantedRotation);

        /// <summary>
        /// When card in player's hand is moused over it becomes highlighted.
        /// This should be relatively fast action.
        /// It is useful to use detached transform so that moused over state won't change during highlighting.
        /// </summary>
        /// <param name="card">Player's card to be highlighted.</param>
        /// <returns>Coroutine which finishes when the card was highlighted.</returns>
        IEnumerator HighlightCardInHand(VisualCardWrapper card);

        /// <summary>
        /// When card in player's hand was highlighted but is no longer moused over it loses the highlight.
        /// This should be relatively fast action.
        /// </summary>
        /// <param name="card">Player's card to be un-highlighted.</param>
        /// <returns>Coroutine which finishes when the card lost the highlight.</returns>
        IEnumerator UnhighlightCardInHand(VisualCardWrapper card);
    }
}
