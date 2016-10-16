using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CartyLib.CardsComponenets
{
    /// <summary>
    /// Component to detect the mouse is over a card or minion.
    /// </summary>
    public class CanBeMousedOver : MonoBehaviour
    {
        /// <summary>
        /// If true the mouse was over the card or the minion this frame.
        /// </summary>
        public bool MouseOver { get; private set; }

        /// <summary>
        /// If true the mouse was over the card or the minion previous frame.
        /// </summary>
        public bool MouserOverPreviousFrame { get; private set; }

        void Awake()
        {
            MouseOver = false;
            MouserOverPreviousFrame = false;
        }

        void Update()
        {
            MouserOverPreviousFrame = MouseOver;

            Ray ray = Camera.main.ScreenPointToRay(UnityBridge.Instance.MousePosition());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                MouseOver = hit.transform.gameObject == gameObject;
            }
            else
            {
                MouseOver = false;
            }
        }
    }
}
