using System.Collections;
using UnityEngine;

namespace CartyLib
{
    /// <summary>
    /// Interface between CartyLib and Unity coroutine calls.
    /// Originally for unit-testing purposes, now mostly just layer of abstraction.
    /// </summary>
    internal interface IUnityBridge
    {
        Coroutine StartCoroutine(IEnumerator coroutine);

        IEnumerator Wait(float seconds);
    }

    /// <summary>
    /// Implementation of IUnityBridge which calls actual Unity methods.
    /// </summary>
    internal class UnityBridgeReal : IUnityBridge
    {
        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return GameManager.Instance.StartCoroutine(coroutine);
        }

        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }

    /// <summary>
    /// Singleton serving as a bridge between CartyLib and Unity engine. 
    /// Has switchable implementation which defaults to UnityBridgeReal.
    /// </summary>
    internal class UnityBridge : IUnityBridge
    {
        public IUnityBridge Bridge { get; set; }

        private UnityBridge()
        {
            Bridge = new UnityBridgeReal();
        }

        private static UnityBridge _the_one_and_only;
        public static UnityBridge Instance
        {
           get
            {
                if(_the_one_and_only == null)
                {
                    _the_one_and_only = new UnityBridge();
                }

                return _the_one_and_only;
            }          
        }

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return Bridge.StartCoroutine(coroutine);
        }

        public IEnumerator Wait(float seconds)
        {
            return Bridge.Wait(seconds);
        }
    }
}
