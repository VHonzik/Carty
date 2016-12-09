using Carty.CartyLib.Internals.BoardComponents;
using UnityEngine;

namespace Carty.CartyLib.Internals.CardsComponents
{
    /// <summary>
    /// Component to keep track of card cost in resources.
    /// </summary>
    class HasCost : MonoBehaviour
    {
        /// <summary>
        /// Current cost of the card.
        /// </summary>
        public int CurrentCost { get; private set; }

        /// <summary>
        /// Original cost of the card.
        /// </summary>
        public int DefaultCost { get; private set; }

        private CanBeOwned _owned;
        private HasOutline _outline;
        private CanBeInHand _hand;

        private bool _previouslyCouldBePlayed;
        private bool _canBePlayed;

        public static Color GreenOutlineColor = new Color(0.3929f, 0.6034f, 0.2710f);

        void Start()
        {
            _owned = GetComponent<CanBeOwned>();
            _outline = GetComponent<HasOutline>();
            _hand = GetComponent<CanBeInHand>();

            var info = GameManager.Instance.CardManager.FindCardInfo(gameObject).CardType.GetInfo();
            DefaultCost = CurrentCost = info.Cost;
            _previouslyCouldBePlayed = false;
            _canBePlayed = false;
        }

        /// <summary>
        /// Checks if the card can be played with current cost and current state of resources.
        /// </summary>
        /// <returns>Whether the card can be played.</returns>
        public bool CanBePlayed()
        {
            return _canBePlayed;
        }

        void Update()
        {
            GameResources resources = _owned.PlayerOwned ? GameManager.Instance.PlayerResources :
                GameManager.Instance.EnemyResources;
            _canBePlayed = _owned.PlayerOwned && _hand.IsInHand && resources.CanAfford(CurrentCost);

            if (_canBePlayed != _previouslyCouldBePlayed)
            {
                if (_canBePlayed == true)
                {
                    _outline.Request(this, GreenOutlineColor);
                }
                else
                {
                    _outline.Revoke(this);
                }
            }

            _previouslyCouldBePlayed = _canBePlayed;
        }
    }
}
