using System.Collections;
using UnityEngine;

namespace Carty.CartyVisuals.Defaults
{
    /// <summary>
    /// Default implementation of ILowLevelCardMovement.
    /// Generally lerps between values with constant speed.
    /// However move over larger distances lerps with speed being triangular function over the distance.
    /// </summary>
    class DefaultLowLevelCardMovement : ILowLevelCardMovement
    {
        private static float MaxSpeed = 7.0f;
        private static float MinSpeed = 3.0f;

        public IEnumerator Flip(GameObject card)
        {
            if (card == null) yield break;

            float t = 0.0f;

            float difference = Quaternion.Angle(card.transform.rotation, VisualManager.Instance.FlippedOn);
            bool initialy_flipped_on = difference < 5.0f;

            Quaternion initial_state = initialy_flipped_on ? VisualManager.Instance.FlippedOn : VisualManager.Instance.FlippedOff;
            Quaternion wanted_state = (!initialy_flipped_on) ? VisualManager.Instance.FlippedOn : VisualManager.Instance.FlippedOff;

            while (true)
            {

                card.transform.rotation = Quaternion.Lerp(initial_state, wanted_state, t);
                t += Time.deltaTime;

                if (t >= 1.0f)
                {
                    card.transform.rotation = wanted_state;
                    break;
                }

                yield return null;
            }
        }

        public IEnumerator FlipInstantly(GameObject card)
        {
            if (card == null) yield break;

            card.transform.rotation = Quaternion.Angle(card.transform.rotation, VisualManager.Instance.FlippedOn) < 5.0f ?
                VisualManager.Instance.FlippedOff : VisualManager.Instance.FlippedOn;
            yield break;
        }

        public IEnumerator Move(GameObject card, Vector3 position)
        {
            if (card == null) yield break;

            Vector3 previous_position = card.transform.position;
            Vector3 middle = Vector3.Lerp(position, previous_position, 0.5f);
            float distance = Vector3.Distance(previous_position, position);

            float speed_modifier = 2.0f;

            if (distance < MinSpeed)
            {
                float t = 0.0f;
                while (true)
                {
                    if (card == null) yield break;

                    card.transform.position = Vector3.Lerp(previous_position, position, t);
                    t += Time.deltaTime * speed_modifier;

                    if (t >= 1.0f)
                    {
                        card.transform.position = position;
                        break;
                    }

                    yield return null;
                }
            }
            else
            {
                float speed = 0.0f;

                while (true)
                {
                    if (card == null) yield break;

                    if (position == card.transform.position) break;

                    float t = 1.0f - (Vector3.Distance(card.transform.position, middle) /
                        (Vector3.Distance(position, previous_position) * 0.5f));
                    speed = Mathf.Lerp(MinSpeed, MaxSpeed, t);
                    card.transform.position = Vector3.MoveTowards(card.transform.position,
                        position, speed * Time.deltaTime);

                    yield return null;
                }
            }
        }

        public IEnumerator MoveInstantly(GameObject card, Vector3 position)
        {
            if (card == null) yield break;

            card.transform.position = position;
            yield break;
        }

        public IEnumerator Rotate(GameObject card, Quaternion rotation)
        {
            if (card == null) yield break;

            float t = 0.0f;
            float speed_modifier = 3.0f;

            Quaternion initial_state = card.transform.rotation;
            Quaternion wanted_state = rotation;

            while (true)
            {
                if (card == null) yield break;

                card.transform.rotation = Quaternion.Lerp(initial_state, wanted_state, t);
                t += speed_modifier * Time.deltaTime;

                if (t >= 1.0f)
                {
                    card.transform.rotation = wanted_state;
                    break;
                }

                yield return null;
            }
        }

        public IEnumerator RotateInstantly(GameObject card, Quaternion rotation)
        {
            if (card == null) yield break;

            card.transform.rotation = rotation;
            yield break;
        }
    }
}
