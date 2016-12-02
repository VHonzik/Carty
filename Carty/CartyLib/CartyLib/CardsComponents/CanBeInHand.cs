using Carty.CartyLib.Internals.BoardComponents;
using Carty.CartyVisuals;
using UnityEngine;

namespace Carty.CartyLib.Internals.CardsComponents
{
    /// <summary>
    /// Component to handle the card transform when it is in hand.
    /// When the hand informs this component that the card position in hand or number of cards in hand has changed,
    /// this component take cares of the necessary movement.
    /// Gathers information about wanted transform from VisualManager.Instance.HandPositioning
    /// </summary>
    public class CanBeInHand : MonoBehaviour
    {
        /// <summary>
        /// Whether the card is in hand.
        /// Calls to OnIndexChanged have effect only when true.
        /// </summary>
        public bool IsInHand { get; set; }

        /// <summary>
        /// Inform the component that the card was added to a hand.
        /// </summary>
        /// <param name="index">Index of the card in the hand.</param>
        /// <param name="cards">Number of cards in the hand.</param>
        /// <param name="hand">Hand to which the card was added.</param>
        public void AddedToHand(int index, int cards, Hand hand)
        {
            IsInHand = true;
            var owned = GetComponent<CanBeOwned>();
            if (owned && owned.PlayerOwned != hand.PlayerOwned) owned.PlayerOwned = hand.PlayerOwned;
            OnIndexChanged(index, cards);
            transform.parent = hand.transform;
        }

        /// <summary>
        /// Similar to AddedToHand but don't move card.
        /// Useful when position was already updated.
        /// </summary>
        /// <param name="hand">Hand to which the card was added.</param>
        public void AddedToHandWithoutFitting(Hand hand)
        {
            IsInHand = true;
            var owned = GetComponent<CanBeOwned>();
            if (owned && owned.PlayerOwned != hand.PlayerOwned) owned.PlayerOwned = hand.PlayerOwned;
            transform.parent = hand.transform;
        }

        /// <summary>
        /// Inform the component that the card was removed from a hand.
        /// </summary>
        public void RemovedFromHand()
        {
            IsInHand = false;
            transform.parent = null;
        }

        /// <summary>
        /// Wanted position based on index and number of present cards.
        /// </summary>
        /// <param name="index">Index of the card in the hand.</param>
        /// <param name="cards">Number of cards in the hand.</param>
        /// <returns>Wanted position in world.</returns>
        public Vector3 WantedPosition(int index, int cards)
        {
            if (GetComponent<CanBeOwned>() && GetComponent<CanBeOwned>().PlayerOwned)
            {
               return VisualManager.Instance.HandPositioning.PositionPlayer(index, cards);
            }
            else
            {
                return VisualManager.Instance.HandPositioning.PositionEnemy(index, cards);
            }
        }

        /// <summary>
        /// Wanted rotation based on index and number of present cards.
        /// </summary>
        /// <param name="index">Index of the card in the hand.</param>
        /// <param name="cards">Number of cards in the hand.</param>
        /// <returns>Wanted rotation.</returns>
        public Quaternion WantedRotation(int index, int cards)
        {
            if (GetComponent<CanBeOwned>() && GetComponent<CanBeOwned>().PlayerOwned)
            {
                return VisualManager.Instance.HandPositioning.RotationPlayer(index, cards);
            }
            else
            {
                return VisualManager.Instance.HandPositioning.RotationEnemy(index, cards);
            }
        }

        /// <summary>
        /// Inform the component that the card position in hand or number of cards in hand has changed.
        /// </summary>
        /// <param name="index">Index, possibly a new one, of the card in the hand.</param>
        /// <param name="cards">Number of cards in the hand.</param>
        public void OnIndexChanged(int index, int cards)
        {
            if(IsInHand)
            {
                Vector3 position = WantedPosition(index, cards);
                Quaternion rotation = WantedRotation(index, cards);

                var moveComponent = GetComponent<CanBeMoved>();
                if (moveComponent)
                {
                    moveComponent.Move(position);
                    moveComponent.Rotate(rotation);
                }
            }
        }
    }
}
