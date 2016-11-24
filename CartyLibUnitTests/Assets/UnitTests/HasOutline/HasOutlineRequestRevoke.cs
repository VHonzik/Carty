using UnityEngine;
using Testing;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
public class HasOutlineRequestRevoke : MonoBehaviour
{
    private int UpdateCount { get; set; }

    private GameObject _card;
    private HasOutline _outline;

    void Awake()
    {
        _card = CardsGameObjects.OnlyDetachHandle();
        _card.AddComponent<CanBeDetached>();
        _outline = _card.AddComponent<HasOutline>();

        UpdateCount = 0;
    }

    void Update()
    {
        if (UpdateCount == 0)
        {
            IntegrationTest.Assert(_outline.WantedColor.a <= 0.0f);
        }
        else if (UpdateCount == 1)
        {
            _outline.Request(this, Color.red);
        }
        else if (UpdateCount == 2)
        {
            IntegrationTest.Assert(_outline.WantedColor == Color.red);
            _outline.Request(_outline, Color.black);
        }
        else if (UpdateCount == 3)
        {
            IntegrationTest.Assert(_outline.WantedColor == Color.red);
            _outline.Revoke(this);
        }
        else if (UpdateCount == 4)
        {
            IntegrationTest.Assert(_outline.WantedColor == Color.black);

            Destroy(_card);

            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}
