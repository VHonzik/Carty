using Carty.CartyVisuals;
using System.Collections;
using UnityEngine;

namespace Carty.CartyLib.Internals.CardsComponents
{
    /// <summary>
    /// Component to allow a card or minion move in the game world.
    /// All the calls are queued in movement or rotation queue which are executed parallelly to each other.
    /// Note that the actual movement is done by ILowLevelCardMovement interface living in VisualManager singleton.
    /// </summary>
    public class CanBeMoved : MonoBehaviour
    {

        /// <summary>
        /// Coroutine queue for movement.
        /// </summary>
        private CoroutineQueue _movementQueue;

        /// <summary>
        /// Coroutine queue for rotations.
        /// </summary>
        private CoroutineQueue _rotationQueue;

        void Awake()
        {
            _movementQueue = new CoroutineQueue();
            _rotationQueue = new CoroutineQueue();
            _movementQueue.Start();
            _rotationQueue.Start();
        }

        /// <summary>
        /// Queue in move from current position to a new position.
        /// </summary>
        /// <param name="position">Wanted position to move to.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved Move(Vector3 position)
        {
            _movementQueue.Add(VisualManager.Instance.LowLevelCardMovement.Move(gameObject, position));
            return this;
        }

        /// <summary>
        /// Queue in instantaneous move from current position to a new position.
        /// </summary>
        /// <param name="position">Wanted position to move to.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved MoveInstantly(Vector3 position)
        {
            _movementQueue.Add(VisualManager.Instance.LowLevelCardMovement.MoveInstantly(gameObject, position));
            return this;
        }

        /// <summary>
        /// Queue in rotation from current rotation to a new rotation.
        /// </summary>
        /// <param name="rotation">Wanted rotation to end up with.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved Rotate(Quaternion rotation)
        {
            _rotationQueue.Add(VisualManager.Instance.LowLevelCardMovement.Rotate(gameObject, rotation));
            return this;
        }

        /// <summary>
        /// Queue in instantaneous rotation from current rotation to a new rotation.
        /// </summary>
        /// <param name="rotation">Wanted rotation to end up with.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved RotateInstantly(Quaternion rotation)
        {
            _rotationQueue.Add(VisualManager.Instance.LowLevelCardMovement.RotateInstantly(gameObject, rotation));
            return this;
        }

        /// <summary>
        /// Queue in flipping card between front and back.
        /// </summary>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved Flip()
        {
            _rotationQueue.Add(VisualManager.Instance.LowLevelCardMovement.Flip(gameObject));
            return this;
        }

        /// <summary>
        /// Queue in instantaneous flipping card between front and back.
        /// </summary>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved FlipInstantly()
        {
            _rotationQueue.Add(VisualManager.Instance.LowLevelCardMovement.FlipInstantly(gameObject));
            return this;
        }

        /// <summary>
        /// Queue in a pause before incoming movement.
        /// </summary>
        /// <param name="seconds">How many seconds to wait.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved PauseMovement(float seconds)
        {
            _movementQueue.AddWait(seconds);
            return this;
        }

        /// <summary>
        /// Queue in a pause before incoming rotation.
        /// </summary>
        /// <param name="seconds">How many seconds to wait.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved PauseRotation(float seconds)
        {
            _rotationQueue.AddWait(seconds);
            return this;
        }

        /// <summary>
        /// Queue in an arbitrary coroutine to movement queue.
        /// Useful for callbacks after some movement.
        /// </summary>
        /// <param name="coroutine">Coroutine to queue in.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved MovementArbitraryCoroutine(IEnumerator coroutine)
        {
            _movementQueue.Add(coroutine);
            return this;
        }


        /// <summary>
        /// Coroutine which waits until movement queue reaches the point when this was called.
        /// That is if you queue in a bunch of orders and call this,
        /// you can yield on this and it will finish once all the previous orders are done.
        /// </summary>
        /// <returns>Coroutine.</returns>
        public IEnumerator WaitUntilMoveReachesThis()
        {
            // Magic using MovementArbitraryCoroutine and WaitForCallback. See WaitForCallback.
            WaitForCallback<CanBeMoved> waitHelper = new WaitForCallback<CanBeMoved>(MovementArbitraryCoroutine);
            yield return GameManager.Instance.StartCoroutine(waitHelper.Do());
        }
    }
}
