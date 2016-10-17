using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CartyLib.Visuals
{
    /// <summary>
    /// Interface for customization of how card outline looks like.
    /// </summary>
    public interface IOutline
    {
        /// <summary>
        /// Create an object which visually represents an outline of a card.
        /// </summary>
        /// <returns>Created game object.</returns>
        GameObject CreateOutlineObject();

        /// <summary>
        /// Apply a color to an outline object.
        /// The change should be immediate since this can be called each frame.
        /// Must support transparency in order to hide the outline.
        /// </summary>
        /// <param name="outline_GO">Outline game object created by CreateOutlineObject.</param>
        /// <param name="wanted_color">Wanted color of  the outline.</param>
        void ApplyColor(GameObject outline_GO, Color wanted_color);
    }
}
