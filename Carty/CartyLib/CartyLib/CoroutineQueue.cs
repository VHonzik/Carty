using System.Collections;
using System.Collections.Generic;

namespace Carty.CartyLib.Internals
{
    /// <summary>
    /// A queue of Unity coroutines. As the name implies a new coroutine won't start before the previous one ended.
    /// </summary>
    public class CoroutineQueue
    {
        private Queue<IEnumerator> _queue;

        public bool Empty { get; private set; }

        /// <summary>
        /// Ctor for the queue.
        /// </summary>
        public CoroutineQueue()
        {
            _queue = new Queue<IEnumerator>();
            Empty = true;            
        }

        /// <summary>
        /// Start processing of coroutines.
        /// </summary>
        public void Start()
        {
            UnityBridge.Instance.StartCoroutine(UpdateQueue());
        }

        /// <summary>
        /// Enqueue a coroutine into the queue.
        /// </summary>
        /// <param name="coroutine">Coroutine to be added.</param>
        public void Add(IEnumerator coroutine)
        {
            _queue.Enqueue(coroutine);
            Empty = false;
        }

        /// <summary>
        /// Enqueue a coroutine into the queue which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds">Number of seconds the coroutine should wait.</param>
        public void AddWait(float seconds)
        {
            _queue.Enqueue(UnityBridge.Instance.Wait(seconds));
            Empty = false;
        }

        /// <summary>
        /// Coroutine which waits until the queue is empty.
        /// </summary>
        /// <returns>Coroutine</returns>
        public IEnumerator WaitUntilEmpty()
        {
            while(!Empty)
            {
                yield return null;
            }
        }

        private IEnumerator UpdateQueue()
        {
            while(true)
            {
                if(_queue.Count > 0)
                {
                    Empty = false;
                    yield return UnityBridge.Instance.StartCoroutine(_queue.Dequeue());
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
