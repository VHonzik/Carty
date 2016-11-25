using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyVisuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Carty.CartyLib.Internals
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
        private Dictionary<string, Type> TypeMapping { get; set; }

        public CardManager() {
            TypeMapping = new Dictionary<string, Type>();
            AllCards = new List<GameObject>();
        }

        /// <summary>
        /// All cards created for this match.
        /// </summary>
        public List<GameObject> AllCards { get; private set; }

        /// <summary>
        /// Immediately destroys all remaining cards.
        /// </summary>
        public void CleanUp()
        {
            for(int i=0; i < AllCards.Count; i++)
            {
                GameObject.Destroy(AllCards[i]);
            }

            AllCards.Clear();
        }

        /// <summary>
        /// Initializes the card manager. 
        /// Scan all application assemblies for MonoBehaviours implementing CartyLib.ICardType.
        /// </summary>
        public void Initialize()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type[] types = null;

                try
                {
                    types = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Debug.LogError("Failed to load types from: " + assembly.FullName);
                    foreach (Exception loadEx in ex.LoaderExceptions)
                        Debug.LogException(loadEx);
                }

                if (types == null)
                    continue;

                foreach (Type type in types)
                {
                    if(type.GetInterfaces().Contains(typeof(ICardType)) && type.BaseType == typeof(MonoBehaviour))
                    {
                        GameObject obj = new GameObject();

                        string id = (obj.AddComponent(type) as ICardType).GetInfo().UniqueCardTypeId;
                        TypeMapping.Add(id, type);
                        GameObject.Destroy(obj);
                    }
                }
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

            GameObject detachHandle = new GameObject("handle");
            detachHandle.transform.parent = card.transform;            

            card.AddComponent<CanBeDetached>();
            card.AddComponent<CanBeOwned>().PlayerOwned = player;
            card.AddComponent<CanBeMoved>();
            card.AddComponent<CanBeMousedOver>();
            card.AddComponent<CanBeInHand>();
            card.AddComponent<HasOutline>();
            var physicalCard = card.AddComponent<HasPhysicalCard>();

            Type cardType;
            if (TypeMapping.TryGetValue(uniqueCardTypeId, out cardType))
            {
                var iCard = card.AddComponent(cardType) as ICardType;

                // Attempt to apply front texture
                var frontTextureName = iCard.GetInfo().CardFrontTexture;

                var frontTexture = Resources.Load(VisualManager.Instance.CardTexturesPath + frontTextureName) as Texture;
                if(frontTexture == null)
                {
                    frontTexture = Resources.Load(frontTextureName) as Texture;
                }

                if(frontTexture != null)
                {
                    VisualManager.Instance.PhysicalCard.SetCardFront(physicalCard.PhysicalCardGO, frontTexture);
                }
            }

            AllCards.Add(card);

            return card;
        }
    }
}
