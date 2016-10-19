using CartyVisuals.Defaults;
using UnityEngine;

namespace CartyVisuals
{
    /// <summary>
    /// Manager for customization of visual aspects of Carty engine.
    /// It serves as a bridge between core engine - CartyLib - and visuals implementation - CartyVisuals.
    /// </summary>
    public class VisualManager
    {
        private static VisualManager _the_one_and_only;
        public static VisualManager Instance
        {
            get
            {
                if (_the_one_and_only == null)
                {
                    _the_one_and_only = new VisualManager();
                }

                return _the_one_and_only;
            }
        }

        private VisualManager()
        {
            CardMovement = new DefaultCardMovement();
            CardOutline = new DefaultCardOutline();
            HandPositioning = new DefaultCardPositionInHand();

            FlippedOn = Quaternion.Euler(-90, 90, 90);
            FlippedOff = Quaternion.Euler(90, 90, 90);

            MaxCardsInHand = 10;

            PlayerHandPosition = new Vector3(0, 4, -3f);

            CardHeight = (0.075f + 0.118f) * 0.125f;
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
