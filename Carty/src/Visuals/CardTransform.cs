using UnityEngine;

namespace Carty.Visuals
{
    /// <summary>
    /// Tuple of position and rotation of card.
    /// </summary>
    public class CardTransform
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }

        public CardTransform()
        {
            Position = Vector3.zero;
            Rotation = Quaternion.identity;
        }

        public CardTransform(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}