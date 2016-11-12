using UnityEngine;
using System.Collections;

namespace Testing
{
    class SimpleCoroutines
    {
        public static IEnumerator ExitImmidiately()
        {
            yield break;
        }

        public static IEnumerator ExitAfterFrame()
        {
            yield return null;
        }
    }

}
