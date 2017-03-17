using UnityEngine;

namespace Carty.Visuals.CardComponents
{
    internal class CanBeInDeck : MonoBehaviour
    {
        internal DefaultVisuals DVisuals;

        internal void ChangePosition(bool playerDeck, int deckIndex, int deckSize)
        {
            Vector3 height = new Vector3(0, (deckSize - (deckIndex+1)) * DVisuals.CardHeight, 0);
            Vector3 position = Vector3.zero;

            if(playerDeck == true)
            {
                position = DVisuals.PlayerDeckPosition;
            }
            else
            {
                position = DVisuals.EnemyDeckPosition;
            }

            transform.rotation = DVisuals.FlippedOff;
            transform.position = position + height;
        }
    }
}