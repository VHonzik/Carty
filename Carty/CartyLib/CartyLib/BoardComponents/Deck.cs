using Carty.CartyVisuals;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.CartyLib.Internals.BoardComponents
{
    /// <summary>
    /// Component representing a deck of player or enemy.
    /// </summary>
    public class Deck : MonoBehaviour
    {
        /// <summary>
        /// List of cards in the deck.
        /// </summary>
        public List<GameObject> Cards { get; private set; }

        /// <summary>
        /// Whether it is a player deck or an enemy deck.
        /// </summary>
        public bool PlayerOwned { get; set; }

        /// <summary>
        /// Assembles a deck.
        /// </summary>
        /// <param name="player">Whether the deck is owned by player.</param>
        /// <returns>Created deck object.</returns>
        public static Deck CreateDeck(bool player)
        {
            GameObject go = new GameObject(player ? "PlayerDeck" : "EnemyDeck");
            go.transform.position = player ? VisualManager.Instance.PlayerDeckPosition : VisualManager.Instance.EnemyDeckPosition;
            var result = go.AddComponent<Deck>();
            result.PlayerOwned = player;
            return result;
        }

        /// <summary>
        /// Gets a first card on the top of the deck and removes it from the deck.
        /// </summary>
        /// <returns>The very top card.</returns>
        public GameObject PopCard()
        {
            if(Cards.Count > 0)
            {
                GameObject result = Cards[0];
                Cards.RemoveAt(0);
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Fills deck with cards of specified card types.
        /// Immediately positions them without call to CanBeMoved.
        /// </summary>
        /// <param name="cardsTypes">Cards' types. The order of cards in the array is the order of draw from deck. </param>
        public void FillWithCards(string[] cardsTypes)
        {
            if(Cards == null) Cards = new List<GameObject>(cardsTypes.Length);
            for(int i = 0; i < cardsTypes.Length; i++)
            {
                var card = GameManager.Instance.CardManager.CreateCard(cardsTypes[i], PlayerOwned);
                int visualIndex = cardsTypes.Length - 1 - i;
                card.transform.position = PlayerOwned ?
                    VisualManager.Instance.DeckPositioning.PositionPlayer(visualIndex, cardsTypes.Length):
                    VisualManager.Instance.DeckPositioning.PositionEnemy(visualIndex, cardsTypes.Length);
                card.transform.rotation = PlayerOwned ?
                    VisualManager.Instance.DeckPositioning.RotationPlayer(visualIndex, cardsTypes.Length) :
                    VisualManager.Instance.DeckPositioning.RotationEnemy(visualIndex, cardsTypes.Length);
                Cards.Add(card);
            }
        }
    }
}
