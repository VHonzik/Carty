﻿using Carty.CartyVisuals.Defaults;
using UnityEngine;

namespace Carty.CartyVisuals
{
    /// <summary>
    /// Manager for customization of visual aspects of Carty engine.
    /// It serves as a bridge between core engine - CartyLib - and visuals implementation - CartyVisuals.
    /// </summary>
    public class VisualManager
    {
        private static VisualManager _the_one_and_only;
        /// <summary>
        /// Singleton accessor.
        /// </summary>
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
            LowLevelCardMovement = new DefaultLowLevelCardMovement();
            CardOutline = new DefaultCardOutline();
            HandPositioning = new DefaultCardPositionInHand();
            PhysicalCard = new DefaultPhysicalCard();
            DeckPositioning = new DefaultCardPositionInDeck();
            HighLevelCardMovement = new DefaultHighLevelCardMovement();
            CardPlaying = new DefaultCardPlaying();
            TurnTimer = new DefaultTurnTimer();

            FlippedOn = Quaternion.Euler(0, 0, 0);
            FlippedOff = Quaternion.Euler(0, 0, -180);

            PlayerHandPosition = new Vector3(0, 4, -3f);
            EnemyHandPosition = new Vector3(0, 4, 3f);
            
            PlayerDeckPosition = new Vector3(7f, 0, -1.9f);
            EnemyDeckPosition = new Vector3(7f, 0, 1.9f);

            PlayerShowDrawnCardPosition = new Vector3(2.3f, 4.60f, -1.3f);

            CardHeight = 0.013f;

            CardTexturesPath = "";

            if(Camera.main != null)
            {
                Camera.main.transform.position = new Vector3(0, 10, 0);
                Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
        }

        /// <summary>
        /// Creates a dummy object for when some goes wrong in visual objects creation.
        /// </summary>
        /// <param name="error">Error message, the game object will be called so.</param>
        /// <returns>Dummy object.</returns>
        public static GameObject CreateErrorObject(string error)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.GetComponent<Renderer>().material.color = Color.red;
            go.name = error;
            return go;
        }

        /// <summary>
        /// Low level card movement customization. See ILowLevelCardMovement.
        /// Assign your own implementation in order to customize how cards move and rotate on the low level.
        /// </summary>
        public ILowLevelCardMovement LowLevelCardMovement { get; set; }


        /// <summary>
        /// High level card movement customization. See IHighLevelCardMovement.
        /// Assign your own implementation in order to customize how cards move and rotate on the low level.
        /// </summary>
        public IHighLevelCardMovement HighLevelCardMovement { get; set; }

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
        /// Customization of details of playing cards.
        /// Assign your own implementation in order to change details of how cards are played.
        /// </summary>
        public ICardPlaying CardPlaying { get; set; }

        /// <summary>
        /// Customization of turn timer.
        /// Assign your own implementation in order to change how turn timer is displayed.
        /// </summary>
        public ITurnTimer TurnTimer { get; set; }

        /// <summary>
        /// Default rotation of the card when its face is facing camera.
        /// </summary>
        public Quaternion FlippedOn { get; set; }

        /// <summary>
        /// Default rotation of the card when its back is facing camera.
        /// </summary>
        public Quaternion FlippedOff { get; set; }

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
        /// Position of the card when it's being shown to player after he has drawn it.
        /// </summary>
        public Vector3 PlayerShowDrawnCardPosition { get; set; }

        /// <summary>
        /// Height of the physical card.
        /// When two cards are placed in the same position with CardHeight difference in Y they should lie on top of each other.
        /// Influences board and hand positioning.
        /// </summary>
        public float CardHeight { get; set; }

        /// <summary>
        /// A path to folder containing cards and portrait pictures relative to the Resources folder.
        /// The folder must be a child of Resources folder.
        /// </summary>
        public string CardTexturesPath { get; set; }
    }
}
