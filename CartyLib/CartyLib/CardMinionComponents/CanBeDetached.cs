using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CartyLib.CardsComponenets
{
    /// <summary>
    /// Component to allow a card or a minion rendering and simulation transforms being detached from each other.
    /// Transform of gameObject is the simulated transform.
    /// The only child game object transform is the rendered transform.
    /// The child game object moves independently to the gameObject. 
    /// </summary>
    public class CanBeDetached : MonoBehaviour
    {
        /// <summary>
        /// True if the card or the minion is detached.
        /// </summary>
        private bool _detached;

        /// <summary>
        /// GameObject serving as a handle for the rendered transform of the card or the minion.
        /// </summary>
        public GameObject Handle;

        /// <summary>
        /// If true the rendered and simulated transform are different.
        /// </summary>
        public bool Detached
        {
            get { return _detached; }
            set
            {
                if (value != _detached && value == false)
                {
                    UpdateAttached();
                }
                else if(value != _detached && value == true)
                {
                    DetachedPosition = transform.position;
                    DetachedRotation = transform.rotation;
                    UpdateDetached();
                }

                _detached = value;
            }
        }

        /// <summary>
        /// World position for the rendered transform of the card or the minion.
        /// Simulated position is transform.position.
        /// </summary>
        public Vector3 DetachedPosition { get; set; }

        /// <summary>
        /// Rotation for the rendered transform of the card or the minion.
        /// Simulated rotation is transform.rotation.
        /// </summary>
        public Quaternion DetachedRotation { get; set; }

        void Awake()
        {
            // Handle is the only child of root game object
            Handle = transform.GetChild(0).gameObject;
            Detached = false;
        }

        void Update()
        {
            if (Detached)
            {
                UpdateDetached();
            }
            else
            {
                UpdateAttached();
            }
        }

        private void UpdateDetached()
        {
            Handle.transform.localPosition = Quaternion.Inverse(transform.rotation) * (DetachedPosition - transform.position);
            Handle.transform.localRotation = Quaternion.Inverse(transform.rotation) * DetachedRotation;
        }

        private void UpdateAttached()
        {
            Handle.transform.localPosition = Vector3.zero;
            Handle.transform.localRotation = Quaternion.identity;
        }
    }
}
