using CartyLib.CardsComponenets;
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
        /// Default rotation of the card when its face is facing camera.
        /// </summary>
        public Quaternion Flipped_On { get; set; }


        /// <summary>
        /// Default rotation of the card when its back is facing camera.
        /// </summary>
        public Quaternion Flipped_Off { get; set; }
    }
}
