using System;
using System.Collections;
using Carty.CartyLib.Internals.CardsComponents;

namespace Carty.CartyVisuals.Defaults
{
    class DefaultHighLevelCardMovement : IHighLevelCardMovement
    {
        public IEnumerator MoveCardFromDeckToDrawDisplayArea(CanBeMoved card)
        {
            card.PauseRotation(0.5f).Flip()
                .Move(VisualManager.Instance.PlayerShowDrawnCardPosition)
                .PauseMovement(1.0f)
                .PauseRotation(1.5f);

            // Wait for the above to finish
            yield return card.WaitUntilMoveReachesThis();
        }

    }
}
