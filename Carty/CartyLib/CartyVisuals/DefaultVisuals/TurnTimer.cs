using System;
using UnityEngine;

namespace Carty.CartyVisuals.Defaults
{
    public class TurnTimer : MonoBehaviour
    {
        public EndTurnDeletegate EndTurn { get; set; }
        public float TurnDuration { get; set; }

        private float timer;
        private bool turnStarted;

        private GameObject clockHand;

        void Awake()
        {
            turnStarted = false;
            clockHand = transform.GetChild(0).gameObject;
        }

        void Update()
        {
            if(turnStarted == true)
            {
                timer += Time.deltaTime;
                if(timer >= TurnDuration)
                {
                    clockHand.transform.rotation = Quaternion.Euler(0,0, (timer / TurnDuration) * -360.0f);
                    timer = TurnDuration;
                    turnStarted = false;
                    if(EndTurn != null) EndTurn();
                }
            }

        }

        public void StartTurn()
        {
            turnStarted = true;
            timer = 0.0f;
        }
    }
}
