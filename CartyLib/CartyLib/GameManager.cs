using UnityEngine;

namespace CartyLib
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

        private CardManager _card_manager;
        public CardManager CardManager
        {
            get
            {
                if (_card_manager == null)
                {
                    _card_manager = new CardManager();
                }

                return _card_manager;
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
