using Carty.Core;

namespace Carty.Visuals
{
    public class VisualsManager
    {
        private static VisualsManager TheOneAndOnly;
        /// <summary>
        /// Singleton accessor.
        /// </summary>
        public static VisualsManager Instance
        {
            get
            {
                if (TheOneAndOnly == null)
                {
                    TheOneAndOnly = new VisualsManager();
                }

                return TheOneAndOnly;
            }
        }

        private Visuals _Visuals;
        public Visuals Visuals {
            get
            {
                if(_Visuals == null)
                {
                    Visuals = new Visuals();
                }
                return _Visuals;
            }
            set
            {
                if (_Visuals != value)
                {
                    UnHookUpEvents(GameManager.Instance);
                    _Visuals = value;
                    if (_Visuals != null)
                    {
                        HookUpEvents(GameManager.Instance);
                    }
                }
            }
        }

        /// <summary>
        /// Subscribe to all of the visuals events in Core.
        /// </summary>
        /// <param name="gameManager">GameManager instance to avoid going through singleton.</param>
        private void HookUpEvents(GameManager gameManager)
        {
            gameManager.PlayerDeck.CardInDeckInstantPositionChange += Visuals.PositionCardInPlayerDeckInstantly;
            gameManager.CardManager.CardCreated += Visuals.AssembleCard;
        }

        private void UnHookUpEvents(GameManager gameManager)
        {
            gameManager.PlayerDeck.CardInDeckInstantPositionChange -= Visuals.PositionCardInPlayerDeckInstantly;
            gameManager.CardManager.CardCreated -= Visuals.AssembleCard;
        }
    }
}