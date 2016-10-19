using CartyVisuals;
using UnityEngine;

namespace CartyLib.CardsComponenets
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
        /// Inform the component that the card was added to hand.
        /// </summary>
        /// <param name="index">Index of the card in the hand.</param>
        /// <param name="cards">Number of cards in the hand.</param>
        public void AddedToHand(int index, int cards)
        {
            IsInHand = true;
            OnIndexChanged(index, cards);
        }

        /// <summary>
        /// Inform the component that the card position in hand or number of cards in hand has changed.
        /// </summary>
        /// <param name="index">Possibly new index of the card in the hand.</param>
        /// <param name="cards">Number of cards in the hand.</param>
        public void OnIndexChanged(int index, int cards)
        {
            if(IsInHand)
            {
                Vector3 position;
                Quaternion rotation;

                if (GetComponent<CanBeOwned>() && GetComponent<CanBeOwned>().PlayerOwned)
                {
                    position = VisualManager.Instance.HandPositioning.PositionPlayer(index, cards);
                    rotation = VisualManager.Instance.HandPositioning.RotationPlayer(index, cards);
                }
                else
                {
                    position = VisualManager.Instance.HandPositioning.PositionEnemy(index, cards);
                    rotation = VisualManager.Instance.HandPositioning.RotationEnemy(index, cards);
                }

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
