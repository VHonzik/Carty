using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CartyLib.Internals
{
    /// <summary>
    /// Singleton serving as a bridge between CartyLib and Unity engine.
    /// Used for unit-testing purposes.
    /// </summary>
    public class UnityBridge
    {

        private UnityBridge() { }

        private static UnityBridge _theOneAndOnly;
        public static UnityBridge Instance
        {
           get
            {
                if(_theOneAndOnly == null)
                {
                    _theOneAndOnly = new UnityBridge();
                }

                return _theOneAndOnly;
            }          
        }

        private bool _overrideMousePosition = false;
        private Vector3 _overrideMouseWantedPosition = Vector3.zero;

        public void OverrideMousePosition(bool on, Vector3 wantedPosition)
        {
            _overrideMousePosition = on;
            _overrideMouseWantedPosition = wantedPosition;
        }

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return GameManager.Instance.StartCoroutine(coroutine);
        }

        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

        public Vector3 MousePosition()
        {
            if(_overrideMousePosition)
            {
                return _overrideMouseWantedPosition;
            }
            else
            {
                return Input.mousePosition;
            }
            
        }
    }
}
