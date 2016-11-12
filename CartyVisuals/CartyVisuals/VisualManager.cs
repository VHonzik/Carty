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
            PhysicalCard = new DefaultPhysicalCard();
            DeckPositioning = new DefaultCardPositionInDeck();

            FlippedOn = Quaternion.Euler(0, 0, 0);
            FlippedOff = Quaternion.Euler(0, 0, -180);

            MaxCardsInHand = 10;

            PlayerHandPosition = new Vector3(0, 4, -3f);
            EnemyHandPosition = new Vector3(0, 4, 3f);
            
            PlayerDeckPosition = new Vector3(6.11f, 0, -1.9f);
            EnemyDeckPosition = new Vector3(6.11f, 0, 1.9f);

            CardHeight = 0.013f;
        }

        public static GameObject CreateErrorObject(string error)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.GetComponent<Renderer>().material.color = Color.red;
            go.name = error;
            return go;
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
        /// Card positioning in deck customization.
        /// Assign your own implementation in order to customize how cards in deck are positioned.
        /// </summary>
        public IDeckCardPositioning DeckPositioning { get; set; }

        /// <summary>
        /// Customization of how the actual card looks like.
        /// Assign your own implementation in order to customize how cards look like.
        /// </summary>
        public IPhysicalCard PhysicalCard { get; set; }

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
        /// Position of the center of the enemy hand.
        /// </summary>
        public Vector3 EnemyHandPosition { get; set; }

        /// <summary>
        /// Position of the bottom-center of the player's deck.
        /// </summary>
        public Vector3 PlayerDeckPosition { get; set; }

        /// <summary>
        /// Position of the bottom-center of the enemy's deck.
        /// </summary>
        public Vector3 EnemyDeckPosition { get; set; }

        /// <summary>
        /// Height of the physical card.
        /// When two cards are placed in the same position with CardHeight difference in Y they should lie on top of each other.
        /// Influences board and hand positioning.
        /// </summary>
        public float CardHeight { get; set; }
    }
}
