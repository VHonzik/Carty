using System;
using UnityEngine;

namespace Carty.CartyVisuals.Defaults
{
    /// <summary>
    /// Default implementation of IDeckCardPositioning.
    /// Cards are placed directly on top of each other and facing down.
    /// </summary>
    class DefaultCardPositionInDeck : IDeckCardPositioning
    {
        public Vector3 PositionEnemy(int index, int cards)
        {
            Vector3 height = new Vector3(0, index * VisualManager.Instance.CardHeight, 0);
            return VisualManager.Instance.EnemyDeckPosition + height;
        }

        public Vector3 PositionPlayer(int index, int cards)
        {
            Vector3 height = new Vector3(0, index * VisualManager.Instance.CardHeight, 0);
            return VisualManager.Instance.PlayerDeckPosition + height;
        }

        public Quaternion RotationEnemy(int index, int cards)
        {
            return VisualManager.Instance.FlippedOff;
        }

        public Quaternion RotationPlayer(int index, int cards)
        {
            return VisualManager.Instance.FlippedOff;
        }
    }
}
