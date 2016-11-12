using CartyLib.CardsComponenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CartyLib
{
    /// <summary>
    /// Class responsible for creating and keeping track of cards.
    /// Through reflection gathers all user created cards from application assemblies.
    /// </summary>
    public class CardManager
    {
        /// <summary>
        /// Map between unique card type id <-> card type.
        /// </summary>
        private Dictionary<string, Type> Type_mapping { get; set; }

        public CardManager() {
            Type_mapping = new Dictionary<string, Type>();
        }

        private void AddCardImplementation(GameObject card, string type)
        {
            var card_type = Type_mapping[type];

            if(card_type != null)
            {
                card.AddComponent(card_type);
            }            
        }

        /// <summary>
        /// Initializes the card manager. 
        /// Scan all application assemblies for MonoBehaviours implementing CartyLib.ICard.
        /// </summary>
        public void Initialize()
        {
            var cards = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(type => type.GetInterfaces().Contains(typeof(ICard)) && type.BaseType == typeof(MonoBehaviour));

            foreach(var card in cards)
            {
                GameObject obj = new GameObject();

                string id = (obj.AddComponent(card) as ICard).GetInfo().UniqueCardTypeId;
                Type_mapping.Add(id, card);
                GameObject.Destroy(obj);
            }
        }

        /// <summary>
        /// Assembles a card.
        /// </summary>
        /// <param name="uniqueCardTypeId">Unique card type id. See CardInfo.UniqueCardTypeId.</param>
        /// <param name="player">Whether the card is owned by player.</param>
        /// <returns>Created card game object.</returns>
        public GameObject CreateCard(string uniqueCardTypeId, bool player)
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

            AddCardImplementation(card, uniqueCardTypeId);

            return card;
        }
    }
}
