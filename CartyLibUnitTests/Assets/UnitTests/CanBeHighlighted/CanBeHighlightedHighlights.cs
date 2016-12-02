using UnityEngine;
using Testing;
using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyLib.Internals;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
public class CanBeHighlightedHighlights : MonoBehaviour
{
    private GameObject _card;
    private CanBeHighlighted _highlight;

    private int UpdateCount;

    void Awake()
    {
        _card = CardsGameObjects.DetachHandleWithCollisionBox();
        _card.AddComponent<CanBeDetached>();
        _card.AddComponent<CanBeMoved>();
        _card.AddComponent<CanBeMousedOver>();
        _card.AddComponent<CanBeInHand>().IsInHand = true;
        _highlight = _card.AddComponent<CanBeHighlighted>();
    }

    void Update()
    {
        if(UpdateCount == 0)
        {
            Vector3 middle_of_screen = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.0f);
            UnityBridge.Instance.OverrideMousePosition(true, middle_of_screen);
        }
        else if(UpdateCount == 1)
        {
            IntegrationTest.Assert(_highlight.HighLighted == true);
            Destroy(_card);

            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}
