using CartyLib;
using UnityEngine;

namespace CartyVisuals
{
    /// <summary>
    /// Manager for assigning visuals implementation to VisualBridge from CartyLib.
    /// </summary>
    public class VisualsManager : MonoBehaviour
    {
        public static VisualsManager Instance { get; set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                VisualBridge.Instance.CardMovement = new DefaultCardMovement();
                VisualBridge.Instance.CardOutline = new DefaultCardOutline();

                VisualBridge.Instance.Flipped_On = Quaternion.Euler(-90, 90, 90);
                VisualBridge.Instance.Flipped_Off = Quaternion.Euler(90, 90, 90);
    }
            else
            {
                Destroy(this);
            }
        }
    }
}