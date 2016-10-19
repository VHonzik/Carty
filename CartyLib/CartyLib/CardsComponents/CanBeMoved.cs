using CartyVisuals;
using System.Collections;
using UnityEngine;

namespace CartyLib.CardsComponenets
{
    /// <summary>
    /// Component to allow a card or minion move in the game world.
    /// All the calls are queued in movement or rotation queue which are executed parallelly to each other.
    /// Note that the actual movement is done by ICardMovement interface living in VisualManager singleton.
    /// </summary>
    public class CanBeMoved : MonoBehaviour
    {

        /// <summary>
        /// Implementation of movement and rotation coroutines taken from VisualManager.
        /// </summary>
        private ICardMovement _card_movement_implementation;

        /// <summary>
        /// Coroutine queue for movement.
        /// </summary>
        private CoroutineQueue _movement_queue;

        /// <summary>
        /// Coroutine queue for rotations.
        /// </summary>
        private CoroutineQueue _rotation_queue;

        void Awake()
        {
            _movement_queue = new CoroutineQueue();
            _rotation_queue = new CoroutineQueue();
            _card_movement_implementation = VisualManager.Instance.CardMovement;
            _movement_queue.Start();
            _rotation_queue.Start();
        }

        /// <summary>
        /// Queue in move from current position to a new position.
        /// </summary>
        /// <param name="position">Wanted position to move to.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved Move(Vector3 position)
        {
            _movement_queue.Add(_card_movement_implementation.Move(gameObject, position));
            return this;
        }

        /// <summary>
        /// Queue in instantaneous move from current position to a new position.
        /// </summary>
        /// <param name="position">Wanted position to move to.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved MoveInstantly(Vector3 position)
        {
            _movement_queue.Add(_card_movement_implementation.MoveInstantly(gameObject, position));
            return this;
        }

        /// <summary>
        /// Queue in rotation from current rotation to a new rotation.
        /// </summary>
        /// <param name="rotation">Wanted rotation to end up with.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved Rotate(Quaternion rotation)
        {
            _rotation_queue.Add(_card_movement_implementation.Rotate(gameObject, rotation));
            return this;
        }

        /// <summary>
        /// Queue in instantaneous rotation from current rotation to a new rotation.
        /// </summary>
        /// <param name="rotation">Wanted rotation to end up with.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved RotateInstantly(Quaternion rotation)
        {
            _rotation_queue.Add(_card_movement_implementation.RotateInstantly(gameObject, rotation));
            return this;
        }

        /// <summary>
        /// Queue in flipping card between front and back.
        /// </summary>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved Flip()
        {
            _rotation_queue.Add(_card_movement_implementation.Flip(gameObject));
            return this;
        }

        /// <summary>
        /// Queue in instantaneous flipping card between front and back.
        /// </summary>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved FlipInstantly()
        {
            _rotation_queue.Add(_card_movement_implementation.FlipInstantly(gameObject));
            return this;
        }

        /// <summary>
        /// Queue in a pause before incoming movement.
        /// </summary>
        /// <param name="seconds">How many seconds to wait.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved PauseMovement(float seconds)
        {
            _movement_queue.AddWait(seconds);
            return this;
        }

        /// <summary>
        /// Queue in a pause before incoming rotation.
        /// </summary>
        /// <param name="seconds">How many seconds to wait.</param>
        /// <returns>Returns this for call chaining.</returns>
        public CanBeMoved PauseRotation(float seconds)
        {
            _rotation_queue.AddWait(seconds);
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
            _movement_queue.Add(coroutine);
            return this;
        }
    }
}
