using CartyLib;
using CartyLib.CardsComponenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Testing
{
    class CardsGameObjects
    {
        public static GameObject OnlyDetachHandle()
        {
            GameObject root = new GameObject("RootCard");
            GameObject handle = new GameObject("Handle");
            handle.transform.parent = root.transform;
            root.transform.rotation = VisualBridge.Instance.Flipped_On;
            return root;
        }

        public static GameObject DetachHandleWithCollisionBox()
        {
            GameObject card = OnlyDetachHandle();
            card.AddComponent<Rigidbody>();
            var collider = card.AddComponent<BoxCollider>();
            collider.center = Vector3.zero;
            collider.size = Vector3.one;
            return card;
        }
    }
}
