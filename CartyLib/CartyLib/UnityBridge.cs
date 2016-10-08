using System.Collections;
using UnityEngine;

namespace CartyLib
{
    /// <summary>
    /// Singleton serving as a bridge between CartyLib and Unity engine.
    /// Used for unit-testing purposes.
    /// </summary>
    public class UnityBridge
    {
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

        private bool _override_mouse_position = false;
        private Vector3 _override_mouse_wanted_position = Vector3.zero;

        public void OverrideMousePosition(bool on, Vector3 wanted_position)
        {
            _override_mouse_position = on;
            _override_mouse_wanted_position = wanted_position;
        }

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return GameManager.Instance.StartCoroutine(coroutine);        }

        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

        public Vector3 MousePosition()
        {
            if(_override_mouse_position)
            {
                return _override_mouse_wanted_position;
            }
            else
            {
                return Input.mousePosition;
            }
            
        }
    }
}
