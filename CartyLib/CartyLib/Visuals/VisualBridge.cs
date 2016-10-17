using CartyLib.CardsComponenets;
using CartyLib.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CartyLib
{
    /// <summary>
    /// Bridge-singleton between CartyLib and customization of visual aspects inside Carty Unity project.
    /// </summary>
    public class VisualBridge
    {
        private static VisualBridge _the_one_and_only;
        public static VisualBridge Instance
        {
            get
            {
                if (_the_one_and_only == null)
                {
                    _the_one_and_only = new VisualBridge();
                }

                return _the_one_and_only;
            }
        }


        /// <summary>
        /// Card movement customization.
        /// Assign your own implementation in order to customize how cards move and rotate.
        /// </summary>
        public ICardMovement CardMovement { get; set; }

        /// <summary>
        /// Card outline customization.
        /// Assign your own implementation in order to customize how card outline is rendered.
        /// </summary>
        public IOutline CardOutline { get; set; }

        /// <summary>
        /// Card positioning in hand customization.
        /// Assign your own implementation in order to customize how cards in hand are positioned.
        /// </summary>
        public IHandCardPositioning HandPositioning { get; set; }

        /// <summary>
        /// Default rotation of the card when its face is facing camera.
        /// </summary>
        public Quaternion FlippedOn { get; set; }

        /// <summary>
        /// Default rotation of the card when its back is facing camera.
        /// </summary>
        public Quaternion FlippedOff { get; set; }

        /// <summary>
        /// Maximal number of cards which can be in hand at one time.
        /// </summary>
        public int MaxCardsInHand { get; set; }

        /// <summary>
        /// Position of the center of the player hand.
        /// </summary>
        public Vector3 PlayerHandPosition { get; set; }

        /// <summary>
        /// Height of the physical card.
        /// When two cards are placed in the same position with CardHeight difference in Y they should lie on top of each other.
        /// Influences board and hand positioning.
        /// </summary>
        public float CardHeight { get; set; }
    }
}
