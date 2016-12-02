using Carty.CartyLib.Internals.CardsComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Carty.CartyVisuals
{
    /// <summary>
    /// Wrapper class for CartyLib card's components commonly used in CartyVisuals.
    /// </summary>
    public class VisualCardWrapper
    {
        public CanBeMoved CanBeMoved { get; private set; }
        public CanBeDetached CanBeDetached { get; private set; }
        public GameObject CardGO { get; private set; }
        public CanBeInHand CanBeInHand { get; private set; }

        public VisualCardWrapper(GameObject card)
        {
            CardGO = card;
            CanBeMoved = card.GetComponent<CanBeMoved>();
            CanBeDetached = card.GetComponent<CanBeDetached>();
            CanBeInHand = card.GetComponent<CanBeInHand>();
        }
    }
}
