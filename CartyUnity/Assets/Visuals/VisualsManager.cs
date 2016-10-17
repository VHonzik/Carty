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
                VisualBridge.Instance.HandPositioning = new DefaultCardPositionInHand();

                VisualBridge.Instance.FlippedOn = Quaternion.Euler(-90, 90, 90);
                VisualBridge.Instance.FlippedOff = Quaternion.Euler(90, 90, 90);

                VisualBridge.Instance.MaxCardsInHand = 10;

                VisualBridge.Instance.PlayerHandPosition = new Vector3(0, 4, -3f);

                VisualBridge.Instance.CardHeight = (0.075f + 0.118f) * 0.125f;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}