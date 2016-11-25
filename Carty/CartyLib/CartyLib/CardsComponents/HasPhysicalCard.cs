using Carty.CartyVisuals;
using UnityEngine;

namespace Carty.CartyLib.Internals.CardsComponents
{
    /// <summary>
    /// Component to allow card have a physical representation.
    /// The physical representation is a GameObject attached to CanBeDetached.Handle.
    /// The representation is created by VisualManager.Instance.PhysicalCard.CreatePhysicalCardObject.
    /// </summary>
    public class HasPhysicalCard : MonoBehaviour
    {
        /// <summary>
        /// GameObject representing the physical card.
        /// </summary>
        public GameObject PhysicalCardGO { get; private set; }

        void Start()
        {
            PhysicalCardGO = VisualManager.Instance.PhysicalCard.CreatePhysicalCardObject();
            PhysicalCardGO.transform.parent = GetComponent<CanBeDetached>().Handle.transform;
            PhysicalCardGO.transform.localPosition = Vector3.zero;
            PhysicalCardGO.transform.localRotation = Quaternion.identity;
        }

    }
}
