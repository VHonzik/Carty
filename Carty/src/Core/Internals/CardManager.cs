using Carty.Core.Cards;
using Carty.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Carty.Core.Internals
{
    /// <summary>
    /// Class responsible for creating and keeping track of cards.
    /// Through reflection gathers all user created cards from application assemblies.
    /// </summary>
    internal class CardManager
    {
        /// <summary>
        /// Map between unique card type id and card type.
        /// </summary>
        private Dictionary<string, ICardType> TypeMapping { get; set; }

        private int nextAvailableCardId = 0;

        /// <summary>
        /// All cards created for the currently ongoing match.
        /// Otherwise empty.
        /// </summary>
        public List<CardWrapper> AllCards { get; private set; }

        /// <summary>
        /// Initializes the card manager. 
        /// Scan all application assemblies for classes implementing ICardType.
        /// </summary>
        public void Initialize()
        {
            // A little bit of reflection magic to make creating cards very easy.
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
                {
                    continue;
                }

                foreach (Type type in types)
                {
                    if (type.GetInterfaces().Contains(typeof(ICardType)))
                    {
                        var instance = Activator.CreateInstance(type) as ICardType;

                        string id = instance.UniqueCardTypeId;
                        TypeMapping.Add(id, instance);
                    }
                }
            }
        }

        /// <summary>
        /// Triggered when a card is created.
        /// </summary>
        public event CardCreatedDelegate CardCreated;

        /// <summary>
        /// Assembles a card.
        /// </summary>
        /// <param name="uniqueCardTypeId">Unique card type id. See ICardType.UniqueCardTypeId.</param>
        /// <returns>Created card wrapper.</returns>
        public CardWrapper CreateCard(string uniqueCardTypeId)
        {
            CardWrapper card = new CardWrapper();

            card.CardID = ++nextAvailableCardId;

            // Find in type mapping
            ICardType cardType;
            if (TypeMapping.TryGetValue(uniqueCardTypeId, out cardType))
            {
                card.CardType = cardType;

                if (cardType.GetType().GetInterfaces().Contains(typeof(ISpellType)))
                {
                    card.IsSpell = true;
                    card.Spell = cardType as ISpellType;
                }
            }

            AllCards.Add(card);

            if(CardCreated != null) CardCreated(card.CardID);

            return card;
        }

        /// <summary>
        /// Immediately destroys all remaining cards.
        /// </summary>
        public void CleanUp()
        {
            for (int i = 0; i < AllCards.Count; i++)
            {
                AllCards[i].Destroy();
            }

            AllCards.Clear();
        }

        /// <summary>
        /// Removes the card from AllCards list and destroys it.
        /// </summary>
        /// <param name="card">Card to destroy.</param>
        public void FindAndDestroy(CardWrapper card)
        {
            AllCards.RemoveAll(x => x == card);
            card.Destroy();
        }
    }
}
