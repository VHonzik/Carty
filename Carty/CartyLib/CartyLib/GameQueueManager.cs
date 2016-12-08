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

        private IEnumerator PlayerDrawCardDisplayCo(GameObject card)
        {
            VisualCardWrapper wrapper = new VisualCardWrapper(card);

            yield return GameManager.Instance.StartCoroutine(VisualManager.Instance.
                HighLevelCardMovement.MoveCardFromDeckToDrawDisplayArea(wrapper));
        }

        private IEnumerator PlayerDrawCardFinishCo(GameObject card)
        {
            VisualCardWrapper wrapper = new VisualCardWrapper(card);

            yield return GameManager.Instance.StartCoroutine(VisualManager.Instance.
                HighLevelCardMovement.MoveCardFromDisplayAreaToHand(wrapper, 
                GameManager.Instance.PlayerHand.NewCardPosition(),
                GameManager.Instance.PlayerHand.NewCardRotation()
                ));
            GameManager.Instance.PlayerHand.Add(wrapper.CanBeInHand);
            if (card.GetComponent<CanBeInteractedWith>()) card.GetComponent<CanBeInteractedWith>().InteractionAllowed = true;
        }

        private IEnumerator DestroyCardCo(GameObject card)
        {
            card.GetComponent<CanBeInteractedWith>().InteractionAllowed = false;
            var physicalCardGO = card.GetComponent<HasPhysicalCard>().PhysicalCardGO;
            yield return GameManager.Instance.StartCoroutine(
                VisualManager.Instance.PhysicalCard.DestroyPhysicalCard(physicalCardGO));
            GameManager.Instance.CardManager.DestroyCard(card);
        }

        private IEnumerator EnableInteractionCo()
        {
            GameManager.Instance.EnableInteraction(true);
            yield break;
        }

        private IEnumerator CastSpell(ISpell spell)
        {
            spell.OnCast(null);
            yield break;
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
        /// Play a card and trigger all necessary callbacks depending on the card implementation.
        /// </summary>
        /// <param name="card">Card to play.</param>
        public void PlayCard(GameObject card)
        {
            var info = GameManager.Instance.CardManager.FindCardInfo(card);
            if (info.IsSpell == true) Queue.AddRoot(CastSpell(info.Spell));
        }

        /// <summary>
        /// Play destroy animation of physical card and then destroy it.
        /// </summary>
        /// <param name="card">Card to destroy.</param>
        public void DestroyCard(GameObject card)
        {
            Queue.AddRoot(DestroyCardCo(card));
        }


        /// <summary>
        /// Enqueue drawing a number of cards for the player.
        /// </summary>
        /// <param name="cardsAmount">Number of cards to draw.</param>
        public void PlayerDrawCards(int cardsAmount)
        {
            GameManager.Instance.EnableInteraction(false);
            for(int i=0; i < cardsAmount; i++)
            {
                var card = GameManager.Instance.PlayerDeck.PopCard();
                // Move the top card of the deck to a display area.
                Queue.AddRoot(PlayerDrawCardDisplayCo(card));

                // Determine if there is space in hand, if the answer is no destroy the card and leave.
                if(GameManager.Instance.PlayerHand.Cards.Count >= GameManager.Instance.Settings.MaxCardsInHand)
                {
                    DestroyCard(card);
                    continue;
                }

                // Inform hand and move it there.
                GameManager.Instance.PlayerHand.PrepareAddingCard();
                Queue.AddRoot(PlayerDrawCardFinishCo(card));
            }

            Queue.AddRoot(EnableInteractionCo());
        }
    }
}
