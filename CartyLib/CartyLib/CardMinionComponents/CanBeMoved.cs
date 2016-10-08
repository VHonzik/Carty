using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CartyLib.CardsComponenets
{
    public class CanBeMoved : MonoBehaviour
    {
        private CoroutineQueue _movement_queue;
        private CoroutineQueue _rotation_queue;

        void Awake()
        {
            _movement_queue.Start();
            _rotation_queue.Start();
        }

        public CanBeMoved Move(Vector3 position)
        {
            return this;
        }

        public CanBeMoved MoveInstantly(Vector3 position)
        {
            return this;
        }

        public CanBeMoved Rotate(Quaternion rotation)
        {
            return this;
        }

        public CanBeMoved RotateInstantly(Quaternion rotation)
        {
            return this;
        }

        public CanBeMoved Flip()
        {
            return this;
        }

        public CanBeMoved PauseMovement(float seconds)
        {
            return this;
        }

        public CanBeMoved PauseRotation(float seconds)
        {
            return this;
        }

        public CanBeMoved MovementArbitraryCoroutine(IEnumerator coroutine)
        {
            return this;
        }
    }
}
