using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyVisuals;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.CartyLib.Internals.BoardComponents
{
    /// <summary>
    /// Component representing the hand of a player or enemy.
    /// </summary>
    public class Hand : MonoBehaviour
    {
        /// <summary>
        /// List of cards that are currently in the hand.
        /// </summary>
        public List<CanBeInHand> Cards { get; private set; }

        /// <summary>
        /// Whether it is a player hand or an enemy hand.
        /// </summary>
        public bool PlayerOwned { get; set; }

        /// <summary>
        /// Assembles a hand.
        /// </summary>
        /// <param name="player">Whether the hand is owned by player.</param>
        /// <returns>Created hand object.</returns>
        public static Hand CreateHand(bool player)
        {
            GameObject go = new GameObject(player ? "PlayerHand" : "EnemyHand");
            go.transform.position = player ? VisualManager.Instance.PlayerHandPosition : VisualManager.Instance.EnemyHandPosition;
            var result = go.AddComponent<Hand>();
            result.PlayerOwned = player;
            return result;
        }

        void Awake()
        {
            Cards = new List<CanBeInHand>();
        }

        /// <summary>
        /// Immediately destroy all cards in the hand.
        /// </summary>
        public void CleanUp()
        {
            for(int i=0; i < Cards.Count; i++)
            {
                Destroy(Cards[i].gameObject);
            }

            Cards.Clear();
        }

        /// <summary>
        /// Inform the hand a new card is gonna be added to it and make space for it.
        /// </summary>
        public void PrepareAddingCard()
        {
            for(int i=0; i < Cards.Count; i++)
            {
                Cards[i].OnIndexChanged(i, Cards.Count + 1);
            }
        }

        /// <summary>
        /// Returns the position new card would occupy if added.
        /// </summary>
        /// <returns>Potential position of the new card.</returns>
        public Vector3 NewCardPosition()
        {
            if(PlayerOwned)
            {
                return VisualManager.Instance.HandPositioning.PositionPlayer(Cards.Count, Cards.Count + 1);
            }
            else
            {
                return VisualManager.Instance.HandPositioning.PositionEnemy(Cards.Count, Cards.Count + 1);
            }            
        }

        /// <summary>
        /// Returns the rotation a new card would occupy if added.
        /// </summary>
        /// <returns>Potential rotation of the new card.</returns>
        public Quaternion NewCardRotation()
        {
            if (PlayerOwned)
            {
                return VisualManager.Instance.HandPositioning.RotationPlayer(Cards.Count, Cards.Count + 1);
            }
            else
            {
                return VisualManager.Instance.HandPositioning.RotationEnemy(Cards.Count, Cards.Count + 1);
            }
        }

        /// <summary>
        /// Adds a card into the hand.
        /// Does not update already present cards, use PrepareAddingCard for that.
        /// Will move and rotate the card to have a correct transform.
        /// </summary>
        /// <param name="card">Card to be added.</param>
        public void Add(CanBeInHand card)
        {
            card.AddedToHand(Cards.Count, Cards.Count + 1, this);
            Cards.Add(card);
        }

        /// <summary>
        /// Adds a card into the hand but don't move and rotate it.
        /// Does not update already present cards, use PrepareAddingCard for that.
        /// </summary>
        /// <param name="card">Card to be added.</param>
        public void AddWithoutFitting(CanBeInHand card)
        {
            card.AddedToHandWithoutFitting(this);
            Cards.Add(card);
        }

        /// <summary>
        /// Remove a card from hand.
        /// Will update all remaining cards transforms.
        /// </summary>
        /// <param name="card">Card to be removed.</param>
        public void Remove(CanBeInHand card)
        {
            Cards.Remove(card);
            card.RemovedFromHand();

            for (int i = 0; i < Cards.Count; i++)
            {
                Cards[i].OnIndexChanged(i, Cards.Count);
            }
        }

        /// <summary>
        /// Immediately fit present cards to a different number of cards.
        /// </summary>
        /// <param name="countNumber">Assumed new number of cards.</param>
        private void ImmediatelyFitCards(int countNumber)
        {
            for (int i = 0; i < countNumber; i++)
            {
                Cards[i].gameObject.transform.position = Cards[i].WantedPosition(i, countNumber);
                Cards[i].gameObject.transform.rotation = Cards[i].WantedRotation(i, countNumber);
            }
        }

        /// <summary>
        /// Fills hand with cards of specified card types.
        /// Immediately positions them without call to CanBeInHand and CanBeMoved.
        /// If there are already cards present in hand they will be moved immediately as well.
        /// </summary>
        /// <param name="cardsTypes">Cards' types. The order of cards in the array is the order in hand, left to right. </param>
        public void FillWithCards(string[] cardsTypes)
        {
            int alreadyPresentCount = Cards.Count;
            int numberOfValidCards = 0;

            for (int i = 0; i < cardsTypes.Length; i++)
            {
                var card = GameManager.Instance.CardManager.CreateCard(cardsTypes[i], PlayerOwned);
                var cardCanBeInHand = card.GetComponent<CanBeInHand>();
                if (cardCanBeInHand)
                {
                    numberOfValidCards++;
                    AddWithoutFitting(cardCanBeInHand);
                }                
            }

            ImmediatelyFitCards(alreadyPresentCount + numberOfValidCards);
        }

        /// <summary>
        /// Pop a number of cards from the passed deck and add them to the hand.
        /// The change is immediate and does not involve fitting.
        /// </summary>
        /// <param name="deck">Deck to pop cards from.</param>
        /// <param name="numberOfCards">Number of cards to take.</param>
        public void ImmidiatelyTakeCardsFromDeck(Deck deck, int numberOfCards)
        {
            int alreadyPresentCount = Cards.Count;
            int numberOfValidCards = 0;

            for (int i=0; i < numberOfCards; i++)
            {
                var card = deck.PopCard();
                if(card)
                {
                    var cardCanBeInHand = card.GetComponent<CanBeInHand>();
                    if(cardCanBeInHand)
                    {
                        numberOfValidCards++;
                        AddWithoutFitting(cardCanBeInHand);
                    }
                }
            }

            ImmediatelyFitCards(alreadyPresentCount + numberOfValidCards);
        }
    }
}
