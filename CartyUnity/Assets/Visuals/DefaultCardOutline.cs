using CartyLib.CardsComponenets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using CartyLib.Visuals;

namespace CartyVisuals
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
            GameObject result = GameObject.Instantiate(Resources.Load("CardOutline") as GameObject) as GameObject;
            return result;
        }
    }
}
