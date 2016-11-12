using UnityEngine;

namespace CartyVisuals.Defaults
{
    /// <summary>
    /// Default card implementation of IOutline.
    /// Outline uses the same model as a card but which is slightly larger and has texture which gradients to transparency.
    /// </summary>
    class DefaultCardOutline : IOutline
    {
        public void ApplyColor(GameObject outline_GO, Color wanted_color)
        {
            outline_GO.GetComponent<Renderer>().material.color = wanted_color;
        }

        public GameObject CreateOutlineObject()
        {
            GameObject outline = Resources.Load("CardOutline") as GameObject;
            if (outline == null)
            {
                Debug.Log("There is no prefab called CardOutline in Resources folder. See CartyVisuals for more details.");
                return VisualManager.CreateErrorObject("Error: Outline not found.");
            }

            GameObject result = GameObject.Instantiate(outline) as GameObject;
            return result;
        }
    }
}
