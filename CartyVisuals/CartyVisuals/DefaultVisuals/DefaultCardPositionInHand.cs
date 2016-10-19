using System;
using UnityEngine;

namespace CartyVisuals.Defaults
{
    /// <summary>
    /// Default implementation of IHandCardPositioning.
    /// Emulates fan-like holding of cards.
    /// </summary>
    class DefaultCardPositionInHand : IHandCardPositioning
    {
        private static float MaxPosAngleDif = 10.0f;
        private static float MinPosAngleDif = 3.0f;

        private static float Radius = 6.0f;

        private Quaternion Rotation(int index, int cards, bool player)
        {
            bool even_cards = cards % 2 == 0;
            if (!even_cards && (index == (cards / 2)))
            {
                return player ? VisualManager.Instance.FlippedOn : VisualManager.Instance.FlippedOff;
            }

            float how_full = Mathf.Clamp((float)cards / (float)VisualManager.Instance.MaxCardsInHand, 0, 1);
            float angle_pos_dif = Mathf.Lerp(MaxPosAngleDif, MinPosAngleDif, how_full);

            float initial_offset_pos = angle_pos_dif;

            if (even_cards)
            {
                initial_offset_pos = 0.5f * angle_pos_dif;
            }

            int index_relative_to_center = index - (cards / 2);
            if (even_cards && index >= (cards / 2)) index_relative_to_center++;
            int sign = Math.Sign(index_relative_to_center);

            float angle = sign * initial_offset_pos + index_relative_to_center * angle_pos_dif;

            Quaternion result = (player ? VisualManager.Instance.FlippedOn : VisualManager.Instance.FlippedOff)
                * Quaternion.Euler(0, 0, angle);

            return result;
        }

        private Vector3 Position(int index, int cards, bool player)
        {
            bool even_cards = cards % 2 == 0;
            if (!even_cards && (index == (cards / 2)))
            {
                return VisualManager.Instance.PlayerHandPosition;
            }

            float how_full = Mathf.Clamp((float)cards / (float)VisualManager.Instance.MaxCardsInHand, 0, 1);
            float angle_pos_dif = Mathf.Lerp(MaxPosAngleDif, MinPosAngleDif, how_full);

            Vector3 middle_card = new Vector3(0, 0, Radius);

            float initial_offset_pos = angle_pos_dif;

            if (even_cards)
            {
                initial_offset_pos = 0.5f * angle_pos_dif;
            }

            int index_relative_to_center = index - (cards / 2);
            if (even_cards && index >= (cards / 2)) index_relative_to_center++;
            int sign = Math.Sign(index_relative_to_center);

            float angle = sign * initial_offset_pos + index_relative_to_center * angle_pos_dif;
            float reference_angle = 0.5f * Mathf.PI - (Mathf.Deg2Rad * angle);
            Vector3 result = new Vector3(Radius * Mathf.Cos(reference_angle), 0, Radius * Mathf.Sin(reference_angle));
            result -= middle_card;
            result.y = (player ? sign : -sign) * VisualManager.Instance.CardHeight * (index_relative_to_center + 1);
            result.z *= (player ? 1 : -1);

            return result;
        }

        public Vector3 PositionPlayer(int index, int cards)
        {
            return Position(index, cards, true);
        }

        public Quaternion RotationPlayer(int index, int cards)
        {
            return Rotation(index, cards, true);
        }

        public Vector3 PositionEnemy(int index, int cards)
        {
            return Position(index, cards, false);
        }

        public Quaternion RotationEnemy(int index, int cards)
        {
            return Rotation(index, cards, false);
        }
    }
}
