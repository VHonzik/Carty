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
            GameObject result = GameObject.Instantiate(Resources.Load("PhysicalCard") as GameObject) as GameObject;
            return result;
        }
    }
}
