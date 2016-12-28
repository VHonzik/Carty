using System;
using System.Collections;
using UnityEngine;

namespace Carty.CartyVisuals.Defaults
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

        public IEnumerator DestroyPhysicalCard(GameObject physicalCardGO)
        {
            GameObject.Destroy(physicalCardGO);
            yield return null;
        }

        public void AttachPhysicalCardCollider(GameObject card)
        {
            GameObject physical = CreatePhysicalCardObject();
            if (physical.GetComponent<MeshFilter>())
            {
                card.AddComponent<MeshCollider>().sharedMesh = physical.GetComponent<MeshFilter>().sharedMesh;
            }
            GameObject.Destroy(physical);
        }

        public void SetCardBack(GameObject physicalCardGO, Texture backTexture)
        {
            string matName = "CardBottom";
            var renderer = physicalCardGO.GetComponent<Renderer>();
            if (renderer != null)
            {
                foreach(var material in renderer.materials)
                {
                    if(material.name.StartsWith(matName))
                    {
                        material.mainTexture = backTexture;
                        return;
                    }
                }
            }

            Debug.Log("Error: Physical card game object has no rendered or material named " + matName
                + ". See implementation of IPhysicalCard.SetCardBack.");
         
        }

        public void SetCardFront(GameObject physicalCardGO, Texture frontTexture)
        {
            string matName = "CardTop";
            var renderer = physicalCardGO.GetComponent<Renderer>();
            if (renderer != null)
            {
                foreach (var material in renderer.materials)
                {
                    if (material.name.StartsWith(matName))
                    {
                        material.mainTexture = frontTexture;
                        return;
                    }
                }
            }

            Debug.Log("Error: Physical card game object has no rendered or material named " + matName
                + ". See implementation of IPhysicalCard.SetCardFront.");
        }
    }
}
