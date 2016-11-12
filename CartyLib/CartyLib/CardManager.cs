using CartyLib.CardsImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CartyLib
{
    public class CardManager
    {
        private Dictionary<string, Type> _type_mapping;

        public CardManager() {
            _type_mapping = new Dictionary<string, Type>();
        }

        public void AddCardImplementation(MonoBehaviour card, string type)
        {

        }

        public void Initialize()
        {
            var cards = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(type => type.GetInterfaces().Contains(typeof(ICard)) && type.BaseType == typeof(MonoBehaviour));

            foreach(var card in cards)
            {
                GameObject obj = new GameObject();

                string id = (obj.AddComponent(card) as ICard).GetUniqueID();
                _type_mapping.Add(id, card);
                GameObject.Destroy(obj);
            }
        }
    }
}
