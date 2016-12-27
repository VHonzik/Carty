using Carty.CartyLib.Internals.BoardComponents;
using Carty.CartyVisuals;
using UnityEngine;

namespace Carty.CartyLib.Internals.CardsComponents
{
    /// <summary>
    /// Component responsible for dragging player cards when they are in hand.
    /// </summary>
    public class CanBeDragged : MonoBehaviour
    {
        /// <summary>
        /// Whether the card is currently being dragged.
        /// </summary>
        public bool Dragging { get; private set; }

        private CanBeInteractedWith _interact;
        private CanBeHighlighted _highlight;
        private CanBeDetached _detach;
        private HasCost _cost;

        void Start()
        {
            _detach = GetComponent<CanBeDetached>();
            _highlight = GetComponent<CanBeHighlighted>();
            _interact = GetComponent<CanBeInteractedWith>();
            _cost = GetComponent<HasCost>();
        }

        void Update()
        {
            if (_highlight.HighLighted == true && Dragging == false
                && Input.GetMouseButton(0) == true && _interact.InteractionAllowed == true
                && _cost.CanBePlayed())
            {
                Dragging = true;
                _highlight.HighLighted = false;
                _detach.Detached = true;
                _detach.DetachedRotation = VisualManager.Instance.FlippedOn;
                GameManager.Instance.EnableInteraction(false);
            }

            if (Dragging == true)
            {
                Vector3 point = UnityBridge.Instance.MousePosition();
                point.z = Camera.main.transform.position.y - transform.position.y;
                Vector3 wantedPos = Camera.main.ScreenToWorldPoint(point);
                _detach.DetachedPosition = wantedPos;

                if(Input.GetMouseButton(0) == false)
                {
                    Dragging = false;
                    GameManager.Instance.EnableInteraction(true);
                    if (VisualManager.Instance.CardPlaying.IsOutsideOfHandArea(_detach.DetachedPosition))
                    {
                        GameManager.Instance.CardPlayedFromHand(gameObject);
                    }
                    else
                    {                       
                        _detach.Detached = false;                        
                    }
                    
                }
            }
        }
    }
}
