using System;
using UnityEngine;

namespace CartyVisuals.Defaults
{
    /// <summary>
    /// Default card implementation of IPhysicalCard.
    /// </summary>
    class DefaultPhysicalCard : IPhysicalCard
    {
        public GameObject CreatePhysicalCardObject()
        {
            GameObject physicalCard = Resources.Load("PhysicalCard") as GameObject;
            if(physicalCard == null)
            {
                Debug.Log("There is no prefab called PhysicalCard in Resources folder. See CartyVisuals for more details.");
                return VisualManager.CreateErrorObject("Error: PhysicalCard not found.");
            }

            GameObject result = GameObject.Instantiate(physicalCard) as GameObject;
            return result;
        }
    }
}
