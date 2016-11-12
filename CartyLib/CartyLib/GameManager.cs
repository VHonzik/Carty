using UnityEngine;

namespace CartyLib
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

        private CardManager _cardManager;
        public CardManager CardManager
        {
            get
            {
                if (_cardManager == null)
                {
                    _cardManager = new CardManager();
                }

                return _cardManager;
            }
        }

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            CardManager.Initialize();   
        }
    }
}
