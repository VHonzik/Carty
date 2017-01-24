using UnityEngine;

namespace Carty.CartyVisuals
{
    /// <summary>
    /// Callback for ending the turn.
    /// </summary>
    public delegate void EndTurnDeletegate();

    /// <summary>
    /// Interface for customization of turn timer.
    /// Turn timer is displaying how much time player has left before his/her turn ends.
    /// It should also allow player to end the turn early.
    /// </summary>
    public interface ITurnTimer
    {
        /// <summary>
        /// Creates an object(s) representing the turn timer.
        /// </summary>
        /// <returns>Created game object.</returns>
        GameObject CreateTimerObject();

        /// <summary>
        /// Called when the turn duration has changed.
        /// Also called right after CreateTimerObject() to initialize the turn duration.
        /// </summary>
        /// <param name="timer">Timer object created by CreateTimerObject.</param>
        /// <param name="duration">New duration of turn.</param>
        void SetTurnDuration(GameObject timer, float duration);

        /// <summary>
        /// Called right after CreateTimerObject to provide the implementation a callback for ending a turn.
        /// It's up to the implementation to provide a mean for ending the turn, such as a button.
        /// When ending the turn is desired the passed callback should be called.
        /// </summary>
        /// <param name="timer">Timer object created by CreateTimerObject.</param>
        /// <param name="endTurnCallback">Callback to call when the turn should end.</param>
        void SetEndTurnCallback(GameObject timer, EndTurnDeletegate endTurnCallback);

        /// <summary>
        /// Called when the turn has started.
        /// Timer should start counting down for amount of time set in SetTurnDuration.
        /// <param name="timer">Timer object created by CreateTimerObject.</param>
        /// </summary>
        void TurnStarted(GameObject timer);
    }
}
