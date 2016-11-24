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
        private CoroutineTree Queue { get; set; }

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
        /// Enqueue drawing a card for the player.
        /// </summary>
        public void PlayerDrawCard()
        {
            // Move the top card of the deck to a display area.
            Queue.AddRoot(PlayerDrawCardDisplayCo());
            // Trigger card drawn event.
            // Determine if there is space in hand, if the answer is no destroy the card and leave.
            // Inform hand and move it there.
        }
    }
}
