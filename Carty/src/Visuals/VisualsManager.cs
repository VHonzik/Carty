using Carty.Core;
using Carty.Visuals.Defaults;
using Carty.Visuals.Interfaces;
using Carty.Visuals.Internals;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.Visuals
{
    public class VisualsManager
    {
        private static VisualsManager TheOneAndOnly;
        /// <summary>
        /// Singleton accessor.
        /// </summary>
        public static VisualsManager Instance
        {
            get
            {
                if (TheOneAndOnly == null)
                {
                    TheOneAndOnly = new VisualsManager();
                }

                return TheOneAndOnly;
            }
        }

        private VisualsManager()
        {
            ActualCardManagment = null;
            DefaultVisuals = new DefaultVisuals();
            VisualQueue = new CoroutineQueue();

            VisualQueue.Start();
            HookUpEvents(GameManager.Instance);
        }

        /// <summary>
        /// Default implementation of visual interfaces.
        /// </summary>
        private DefaultVisuals DefaultVisuals;

        /// <summary>
        /// Overridden implementation of ICardManagment.
        /// </summary>
        private ICardManagment ActualCardManagment;

        /// <summary>
        /// Implementation of ICardManagment.
        /// Use it to assign your custom implementation.
        /// </summary>
        public ICardManagment CardManagment
        {
            get
            {
                if (ActualCardManagment != null)
                {
                    return ActualCardManagment;
                }

                return DefaultVisuals;
            }
            set
            {
                if (value != null)
                {
                    ActualCardManagment = value;
                }
            }
        }

        /// <summary>
        /// Overridden implementation of ICardPositioning.
        /// </summary>
        private ICardPositioning ActualCardPositioning;

        /// <summary>
        /// Implementation of ICardPositioning.
        /// Use it to assign your custom implementation.
        /// </summary>
        public ICardPositioning CardPositioning
        {
            get
            {
                if (ActualCardPositioning != null)
                {
                    return ActualCardPositioning;
                }

                return DefaultVisuals;
            }
            set
            {
                if (value != null)
                {
                    ActualCardPositioning = value;
                }
            }
        }

        /// <summary>
        /// Queue for visuals effects.
        /// </summary>
        private CoroutineQueue VisualQueue { get; set; }

        private void QueueAddingCardToPlayerHand(GameObject card, int handIndex,
            IEnumerable<GameObject> cardsInHand)
        {
            VisualQueue.Add(CardPositioning.MoveCardToPlayerHandAndAdjustHand(card, handIndex, cardsInHand));
        }

        private void QueueAddingCardToEnemyHand(GameObject card, int handIndex,
            IEnumerable<GameObject> cardsInHand)
        {
            VisualQueue.Add(CardPositioning.MoveCardToEnemyHandAndAdjustHand(card, handIndex, cardsInHand));
        }

        /// <summary>
        /// Subscribe to all of the visuals events in Core.
        /// </summary>
        /// <param name="gameManager">GameManager instance to avoid going through singleton.</param>
        private void HookUpEvents(GameManager gameManager)
        {
            gameManager.CardManager.CardCreated += CardManagment.AssembleCard;
            gameManager.PlayerDeck.CardInDeckInstantPositionChange += CardPositioning.PositionCardInPlayerDeckInstantly;
            gameManager.EnemyDeck.CardInDeckInstantPositionChange += CardPositioning.PositionCardInEnemyDeckInstantly;
            gameManager.PlayerHand.CardAddedToHand += QueueAddingCardToPlayerHand;
            gameManager.EnemyHand.CardAddedToHand += QueueAddingCardToEnemyHand;
        }
    }
}