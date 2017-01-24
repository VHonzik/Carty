using System;
using UnityEngine;

namespace Carty.CartyVisuals.Defaults
{
    /// <summary>
    /// Default implementation of ITurnTimer.
    /// </summary>
    class DefaultTurnTimer : ITurnTimer
    {
        public GameObject CreateTimerObject()
        {
            GameObject turnclock = Resources.Load("TurnClock") as GameObject;
            if (turnclock == null)
            {
                Debug.Log("There is no prefab called TurnClock in Resources folder. See CartyVisuals for more details.");
                return VisualManager.CreateErrorObject("Error: TurnClock not found.");
            }

            GameObject result = GameObject.Instantiate(turnclock) as GameObject;
            if(result != null) result.AddComponent<TurnTimer>();
            return result;
        }

        public void SetEndTurnCallback(GameObject timer, EndTurnDeletegate endTurnCallback)
        {
            if(timer != null)
            {
                TurnTimer timerBehavior = timer.GetComponent<TurnTimer>();
                if(timerBehavior != null)
                {
                    timerBehavior.EndTurn = endTurnCallback;
                }
            }
        }

        public void SetTurnDuration(GameObject timer, float duration)
        {
            if (timer != null)
            {
                TurnTimer timerBehavior = timer.GetComponent<TurnTimer>();
                if (timerBehavior != null)
                {
                    timerBehavior.TurnDuration = duration;
                }
            }
        }

        public void TurnStarted(GameObject timer)
        {
            if (timer != null)
            {
                TurnTimer timerBehavior = timer.GetComponent<TurnTimer>();
                if (timerBehavior != null)
                {
                    timerBehavior.StartTurn();
                }
            }
        }
    }
}
