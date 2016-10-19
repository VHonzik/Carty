using CartyLib.BoardComponents;
using CartyVisuals;
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
            root.transform.rotation = VisualManager.Instance.FlippedOn;
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

        public static Hand PlayerHand()
        {
            GameObject hand = new GameObject();
            var result = hand.AddComponent<Hand>();
            result.PlayerOwned = true;
            return result;
        }
    }
}
