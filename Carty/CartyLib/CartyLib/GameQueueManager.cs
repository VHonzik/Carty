using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyVisuals;
using System.Collections;
using UnityEngine;

namespace Carty.CartyLib.Internals
{
    /// <summary>
    /// Class responsible for turn-based gameplay and layered game "event system".
    /// </summary>
    public class GameQueueManager
    {
        public CoroutineTree Queue { get; private set; }

        public GameQueueManager()
        {
            Queue = new CoroutineTree();
            
        }

        private IEnumerator PlayerDrawCardDisplayCo()
        {
            GameObject card = GameManager.Instance.PlayerDeck.PopCard();
            CanBeMoved canBeMoved = card.GetComponent<CanBeMoved>(); 

            yield return GameManager.Instance.StartCoroutine(VisualManager.Instance.
                HighLevelCardMovement.MoveCardFromDeckToDrawDisplayArea(canBeMoved));
        }


        /// <summary>
        /// Start processing of the game queue.
        /// </summary>
        public void Start()
        {
            Queue.Start();
        }

        /// <summary>
        /// Immediately removes all pending game actions.
        /// </summary>
        public void CleanUp()
        {
            Queue.CleanUp();
        }


        /// <summary>
        /// Enqueue drawing a number of cards for the player.
        /// </summary>
        /// <param name="cardsAmount">Number of cards to draw.</param>
        public void PlayerDrawCards(int cardsAmount)
        {
            for(int i=0; i < cardsAmount; i++)
            {
                // Move the top card of the deck to a display area.
                Queue.AddRoot(PlayerDrawCardDisplayCo());
                // Trigger card drawn event.
                // Determine if there is space in hand, if the answer is no destroy the card and leave.
                // Inform hand and move it there.
            }
        }
    }
}
