using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;
using CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CanBeMousedOverAcrossFrames : MonoBehaviour
{
    private int UpdateCount { get; set; }

    private GameObject _card;
    private CanBeMousedOver _mouse_over;

    void Awake()
    {
        _card = CardsGameObjects.DetachHandleWithCollisionBox();
        _mouse_over = _card.AddComponent<CanBeMousedOver>();

        Vector3 right_of_screen = new Vector3(Screen.width * 0.75f, Screen.height * 0.5f, 0.0f);
       UnityBridge.Instance.OverrideMousePosition(true, right_of_screen);

        UpdateCount = 0;
    }

    void Update()
    {
        if (UpdateCount == 0)
        {
            IntegrationTest.Assert(_mouse_over.MouseOver == false);
        }
        else if(UpdateCount == 1)
        {
            Vector3 middle_of_screen = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.0f);
            UnityBridge.Instance.OverrideMousePosition(true, middle_of_screen);
        }
        else if (UpdateCount == 2)
        {
            IntegrationTest.Assert(_mouse_over.MouserOverPreviousFrame == false);
            IntegrationTest.Assert(_mouse_over.MouseOver == true);
        }
        else if (UpdateCount == 3)
        {
            Vector3 left_of_screen = new Vector3(Screen.width * 0.25f, Screen.height * 0.5f, 0.0f);
            UnityBridge.Instance.OverrideMousePosition(true, left_of_screen);
        }
        else if (UpdateCount == 4)
        {
            IntegrationTest.Assert(_mouse_over.MouserOverPreviousFrame == true);
            IntegrationTest.Assert(_mouse_over.MouseOver == false);

            Destroy(_card);

            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}
