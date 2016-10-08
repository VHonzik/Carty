using CartyLib.CardsComponenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartyLib
{
    /// <summary>
    /// Bridge-singleton between CartyLib and customization of visual aspects inside Carty Unity project.
    /// </summary>
    class VisualBridge
    {
        private VisualBridge()
        {
            CardMovement = new DefaultCardMovement();
        }

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
        public ICardMovement CardMovement { get; set;}
    }
}
