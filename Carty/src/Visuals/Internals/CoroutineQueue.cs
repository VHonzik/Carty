using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.Visuals.Internals
{
    internal class DummyMonoBehaviour : MonoBehaviour
    {
        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }

    /// <summary>
    /// A queue of Unity coroutines. As the name implies a new coroutine won't start before the previous one ended.
    /// </summary>
    internal class CoroutineQueue
    {
        /// <summary>
        /// Dummy behaviour for StartingCoroutines.
        /// </summary>
        private DummyMonoBehaviour Dummy;

        /// <summary>
        /// Underlying data structure.
        /// </summary>
        private Queue<IEnumerator> Queue;

        /// <summary>
        /// Whether the queue is empty, that is there is nothing queued and nothing is currently being executed.
        /// </summary>
        public bool Empty { get; private set; }

        /// <summary>
        /// Ctor for the queue.
        /// </summary>
        public CoroutineQueue()
        {
            Dummy = new GameObject().AddComponent<DummyMonoBehaviour>();
            Queue = new Queue<IEnumerator>();
            Empty = true;
        }

        /// <summary>
        /// Start processing of coroutines.
        /// </summary>
        public void Start()
        {
            Dummy.StartCoroutine(UpdateQueue());
        }

        /// <summary>
        /// Enqueue a coroutine into the queue.
        /// </summary>
        /// <param name="coroutine">Coroutine to be added.</param>
        public void Add(IEnumerator coroutine)
        {
            Queue.Enqueue(coroutine);
            Empty = false;
        }

        /// <summary>
        /// Enqueue a coroutine into the queue which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds">Number of seconds the coroutine should wait.</param>
        public void AddWait(float seconds)
        {
            Queue.Enqueue(Dummy.Wait(seconds));
            Empty = false;
        }

        /// <summary>
        /// Coroutine which waits until the queue is empty.
        /// </summary>
        /// <returns>Coroutine</returns>
        public IEnumerator WaitUntilEmpty()
        {
            while (!Empty)
            {
                yield return null;
            }
        }

        private IEnumerator UpdateQueue()
        {
            while (true)
            {
                if (Queue.Count > 0)
                {
                    Empty = false;
                    yield return Dummy.StartCoroutine(Queue.Dequeue());
                }
                else
                {
                    Empty = true;
                    yield return null;
                }
            }
        }
    }
}
