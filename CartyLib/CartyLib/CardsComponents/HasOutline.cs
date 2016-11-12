using CartyVisuals;
using System.Collections.Generic;
using UnityEngine;

namespace CartyLib.CardsComponenets
{
    /// <summary>
    /// Information about a card component requesting displaying or hiding of an outline from HasOutline component.
    /// </summary>
    public class OutlineRequest
    {
        /// <summary>
        /// Component who is requesting outline change.
        /// </summary>
        public Component Component { get; private set; }

        /// <summary>
        /// What color is the component is requesting.
        /// </summary>
        public Color Color { get; private set; }
        public OutlineRequest(Component component, Color color)
        {
            Component = component;
            Color = color;
        }
    }

    /// <summary>
    /// Component to allow a card to have an outline for highlighting purposes.
    /// Other components can request an outline of specified color and responsible for revoking their requests.
    /// </summary>
    public class HasOutline : MonoBehaviour
    {
        /// <summary>
        /// GameObject representing the outline. Created via IOutline.CreateOutlineObject from VisualManager.
        /// </summary>
        private GameObject OutlineGO { get; set; }

        /// <summary>
        /// List of outline requests.
        /// </summary>
        private List<OutlineRequest> _requests = new List<OutlineRequest>();

        /// <summary>
        /// Currently wanted color of the outline.
        /// </summary>
        public Color WantedColor { get; private set;}

        /// <summary>
        /// Previously wanted color of the outline.
        /// </summary>
        public Color OriginalColor { get; private set; }

        /// <summary>
        /// Coefficient of interpolation between OriginalColor and WantedColor.
        /// </summary>
        public float T { get; private set; }

        public static Color HiddenColor = new Color(0,0,0,0);

        private static float SpeedModifier = 4.0f;

        private Color TransparentOfColor(Color color)
        {
            return new Color(color.r, color.g, color.b, 0.0f);
        }

        void Start()
        {
            OutlineGO = VisualManager.Instance.CardOutline.CreateOutlineObject();
            OutlineGO.transform.parent = GetComponent<CanBeDetached>().Handle.transform;
            OutlineGO.transform.localPosition = Vector3.zero;

            OriginalColor = HiddenColor;
            WantedColor = HiddenColor;

            T = 1.0f;
        }

        void Update()
        {
            if(_requests.Count > 0)
            {
                Color wanted = _requests[0].Color;
                if(wanted != WantedColor)
                {                  
                    if(WantedColor == HiddenColor)
                    {
                        OriginalColor = TransparentOfColor(wanted);
                    }
                    else
                    {
                        OriginalColor = WantedColor;
                    }                    
                    WantedColor = wanted;
                    T = 0.0f;
                }
            }
            else if(WantedColor.a > 0.0f)
            {
                OriginalColor = WantedColor;
                WantedColor = TransparentOfColor(WantedColor);
                T = 0.0f;
            }

            if(T < 1.0f)
            {
                Color wanted = Color.Lerp(OriginalColor, WantedColor, T);
                VisualManager.Instance.CardOutline.ApplyColor(OutlineGO, wanted);

                T += SpeedModifier * Time.deltaTime;

                if(T >= 1.0f)
                {
                    T = 1.0f;

                    if (WantedColor.a <= 0.0f) WantedColor = HiddenColor;

                    VisualManager.Instance.CardOutline.ApplyColor(OutlineGO, WantedColor);
                }
            }
            
        }

        /// <summary>
        /// Request an outline of a specified color.
        /// Only one outline can be active at a time, first-come-first-served processing fashion.
        /// You must call Revoke to remove the outline.
        /// </summary>
        /// <param name="who">Component who is requesting the outline. Must not be null.</param>
        /// <param name="color">Wanted color of the outline.</param>
        public void Request(Component who, Color color)
        {
            if(who != null) _requests.Add(new OutlineRequest(who, color));
        }

        /// <summary>
        /// Revoke an request of an outline.
        /// </summary>
        /// <param name="who">Component who is revoking the outline. Must not be null.</param>
        public void Revoke(Component who)
        {
            int index = _requests.FindIndex(x => x.Component == who);
            if (index >= 0 && index < _requests.Count) _requests.RemoveAt(index);
        }
    }
}
