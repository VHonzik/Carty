using System;
using System.Collections;
using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyLib;
using UnityEngine;

namespace Carty.CartyVisuals.Defaults
{
    class DefaultHighLevelCardMovement : IHighLevelCardMovement
    {
        public IEnumerator HighlightCardInHand(VisualCardWrapper card)
        {
            Vector3 previousPosition = card.CardGO.transform.position;
            Vector3 cameraPosition = Camera.main.transform.position;
            Vector3 direction = (cameraPosition - previousPosition).normalized;
            float t = 1.0f / direction.y;
            float wantedChangeInY = 2.0f;

            Vector3 wantedPosition = previousPosition + wantedChangeInY * t * direction;
            wantedPosition.z = -0.95f;

            card.CanBeDetached.Detached = true;
            card.CanBeDetached.DetachedPosition = wantedPosition;
            card.CanBeDetached.DetachedRotation = VisualManager.Instance.FlippedOn;

            yield return null;
        }

        public IEnumerator MoveCardFromDeckToDrawDisplayArea(VisualCardWrapper card)
        {
            card.CanBeMoved.PauseRotation(0.5f).Flip()
                .Move(VisualManager.Instance.PlayerShowDrawnCardPosition)
                .PauseMovement(1.0f)
                .PauseRotation(1.5f);

            yield return card.CanBeMoved.WaitUntilMoveReachesThis();
        }

        public IEnumerator MoveCardFromDisplayAreaToHand(VisualCardWrapper card, Vector3 wantedPosition, Quaternion wantedRotation)
        {
            card.CanBeMoved.Move(wantedPosition).Rotate(wantedRotation);
            yield return card.CanBeMoved.WaitUntilMoveReachesThis();
        }

        public IEnumerator UnhighlightCardInHand(VisualCardWrapper card)
        {
            card.CanBeDetached.Detached = false;
            yield return null;
        }
    }
}
