using System.Collections;

namespace CartyLib.Internals
{
    /// <summary>
    /// Helper class for when inside a coroutine one needs to wait for another coroutine's callback.
    /// It is slightly twisted concept but CartyLib often uses coroutine queues. You can't just
    /// yield on a coroutine shoved into a queue, you don't know when it will start.
    /// So you instead add a fake coroutine to the queue after the coroutine you are interested in,
    /// which call-backs you when your coroutine has finished. 
    /// WaitForCallback facilitates this concept for you.
    /// </summary>
    /// <typeparam name="TReturn">Return type of the callback coroutine. Necessary for this helper to be generic.</typeparam>
    public class WaitForCallback<TReturn>
    {
        /// <summary>
        /// Delegate for a coroutine with callback of whatever return type.
        /// </summary>
        /// <param name="callback">Callback coroutine.</param>
        /// <returns>Whatever.</returns>
        public delegate TReturn FunctionWithCoroutineCallBack(IEnumerator callback);

        private FunctionWithCoroutineCallBack Function { get; set; }
        private bool _finished;

        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="function">Function for whose callback you want to wait for.</param>
        public WaitForCallback(FunctionWithCoroutineCallBack function)
        {
            Function = function;
            _finished = false;
        }

        /// <summary>
        /// Fake callback which informs the instance it was called and exits immediately.
        /// </summary>
        /// <returns>Coroutine.</returns>
        private IEnumerator Done()
        {
            _finished = true;
            yield break;
        }

        /// <summary>
        /// Coroutine on which you can yield until a Function you passed in ctor has triggered a callback.
        /// </summary>
        /// <returns>Coroutine.</returns>
        public IEnumerator Do()
        {
            Function(Done());

            while (_finished == false)
            {
                yield return null;
            }
        }
    }
}
