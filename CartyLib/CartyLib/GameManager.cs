using UnityEngine;

namespace CartyLib
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

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
        }
    }
}
