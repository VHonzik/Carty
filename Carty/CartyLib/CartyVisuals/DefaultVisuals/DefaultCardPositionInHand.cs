using Carty.CartyLib;
using System;
using UnityEngine;

namespace Carty.CartyVisuals.Defaults
{
    /// <summary>
    /// Default implementation of IHandCardPositioning.
    /// Emulates fan-like holding of cards.
    /// </summary>
    class DefaultCardPositionInHand : IHandCardPositioning
    {
        private static float MaxPosAngleDif = 10.0f;
        private static float MinPosAngleDif = 5.0f;

        private static float Radius = 6.0f;

        private Quaternion Rotation(int index, int cards, bool player)
        {
            bool even_cards = cards % 2 == 0;
            if (!even_cards && (index == (cards / 2)))
            {
                return player ? VisualManager.Instance.FlippedOn : VisualManager.Instance.FlippedOff;
            }

            float how_full = Mathf.Clamp((float)cards / (float)GameManager.Instance.Settings.MaxCardsInHand, 0, 1);
            float angle_pos_dif = Mathf.Lerp(MaxPosAngleDif, MinPosAngleDif, how_full);

            float index_relative_to_center = index - (cards / 2);
            if (even_cards && index >= (cards / 2)) index_relative_to_center += 1.0f;
            int sign = Math.Sign(index_relative_to_center);
            if (even_cards) index_relative_to_center += -sign * 0.5f;

            float angle = index_relative_to_center * angle_pos_dif;

            Quaternion result = (player ? VisualManager.Instance.FlippedOn : VisualManager.Instance.FlippedOff)
                * Quaternion.Euler(0, angle, 0);

            return result;
        }

        private Vector3 Position(int index, int cards, bool player)
        {
            Vector3 hand_pos = player ? VisualManager.Instance.PlayerHandPosition : VisualManager.Instance.EnemyHandPosition;
            bool even_cards = cards % 2 == 0;
            if (!even_cards && (index == (cards / 2)))
            {
                return hand_pos;
            }

            float how_full = Mathf.Clamp((float)cards / (float)GameManager.Instance.Settings.MaxCardsInHand, 0, 1);
            float angle_pos_dif = Mathf.Lerp(MaxPosAngleDif, MinPosAngleDif, how_full);

            Vector3 middle_card = new Vector3(0, 0, Radius);

            float index_relative_to_center = index - (cards / 2);
            if (even_cards && index >= (cards / 2)) index_relative_to_center += 1.0f;
            int sign = Math.Sign(index_relative_to_center);
            if (even_cards) index_relative_to_center += -sign * 0.5f; 

            float angle = index_relative_to_center * angle_pos_dif;
            float reference_angle = 0.5f * Mathf.PI - (Mathf.Deg2Rad * angle);
            Vector3 result = new Vector3(Radius * Mathf.Cos(reference_angle), 0, Radius * Mathf.Sin(reference_angle));
            result -= middle_card;
            result.y = VisualManager.Instance.CardHeight * (index_relative_to_center + 1);
            result.z *= (player ? 1 : -1);

            result += hand_pos;

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
