using UnityEngine;

namespace Carty.Visuals.CardComponents
{
    internal class CanBeInDeck : MonoBehaviour
    {
        internal void ChangePosition(bool playerDeck, int deckIndex, int deckSize)
        {
            Vector3 height = new Vector3(0, (deckSize - (deckIndex+1)) * VisualsManager.Instance.Visuals.CardHeight, 0);
            Vector3 position = Vector3.zero;

            if(playerDeck == true)
            {
                position = VisualsManager.Instance.Visuals.PlayerDeckPosition;
            }
            else
            {
                position = VisualsManager.Instance.Visuals.EnemyDeckPosition;
            }

            transform.rotation = VisualsManager.Instance.Visuals.FlippedOff;
            transform.position = position + height;
        }
    }
}