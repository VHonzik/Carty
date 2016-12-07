using Carty.CartyVisuals;
using UnityEngine;

namespace Carty.CartyLib.Internals.CardsComponents
{
    /// <summary>
    /// Component responsible for highlighting card in hand when it is moused over.
    /// </summary>
    public class CanBeHighlighted : MonoBehaviour
    {
        /// <summary>
        /// Whether the card is currently highlighted.
        /// </summary>
        public bool HighLighted { get; set; }

        /// <summary>
        /// Pointers to other components to avoid requesting them all the time.
        /// </summary>
        private CanBeMousedOver _mouseOver;
        private CanBeMoved _move;
        private CanBeInHand _hand;
        private CanBeOwned _owned;
        private CanBeInteractedWith _interact;

        private VisualCardWrapper _wrapper;

        void Start()
        {
            HighLighted = false;
            _mouseOver = GetComponent<CanBeMousedOver>();
            _owned = GetComponent<CanBeOwned>();
            _move = GetComponent<CanBeMoved>();
            _hand = GetComponent<CanBeInHand>();
            _interact = GetComponent<CanBeInteractedWith>();
            _wrapper = new VisualCardWrapper(gameObject);
        }

        void Update()
        {
            if(_interact.InteractionAllowed)
            {
                if (_mouseOver.MouseOver && !HighLighted && _hand.IsInHand && _owned.PlayerOwned)
                {
                    Highlight();
                }
                else if (!_mouseOver.MouseOver && HighLighted && _owned.PlayerOwned)
                {
                    RemoveHighlight();
                }
            }
        }

        private void Highlight()
        {
            HighLighted = true;
            _move.MovementArbitraryCoroutine(VisualManager.Instance.HighLevelCardMovement.HighlightCardInHand(_wrapper));
        }

        private void RemoveHighlight()
        {
            HighLighted = false;
            _move.MovementArbitraryCoroutine(VisualManager.Instance.HighLevelCardMovement.UnhighlightCardInHand(_wrapper));
        }
    }
}
