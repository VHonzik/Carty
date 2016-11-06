using CartyLib.BoardComponents;
using CartyLib.CardsComponenets;
using CartyVisuals;
using UnityEngine;

namespace CartyLib
{
    /// <summary>
    /// Class responsible for assembling cards and other board game objects and adding all necessary components.
    /// </summary>
    public class CartyEntitiesConstructors
    {
        /// <summary>
        /// Assembles a card.
        /// </summary>
        /// <returns>Created card game object.</returns>
        public static GameObject CreateCard()
        {
            GameObject card = new GameObject("card");

            GameObject detach_handle = new GameObject("handle");
            detach_handle.transform.parent = card.transform;

            GameObject physical_card = CartyVisuals.VisualManager.Instance.PhysicalCard.CreatePhysicalCardObject();
            physical_card.transform.parent = detach_handle.transform;

            card.AddComponent<CanBeDetached>();
            card.AddComponent<CanBeOwned>();
            card.AddComponent<CanBeMoved>();
            card.AddComponent<CanBeMousedOver>();
            card.AddComponent<CanBeInHand>();
            card.AddComponent<HasOutline>();

            return card;
        }

        public static Hand CreateHand(bool player)
        {
            GameObject go = new GameObject( player ? "PlayerHand" : "EnemyHand");
            go.transform.position = player ? VisualManager.Instance.PlayerHandPosition : VisualManager.Instance.EnemyHandPosition;
            var result = go.AddComponent<Hand>();
            result.PlayerOwned = player;
            return result;
        }
    }
}
