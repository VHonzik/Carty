using UnityEngine;
using Testing;
using Carty.CartyVisuals;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
class CanBeMovedInstantFlip : MonoBehaviour
{
    private int UpdateCount { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateCount = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CanBeMoved>();
        move.FlipInstantly();
    }

    void Update()
    {
        if (UpdateCount == 1)
        {
            IntegrationTest.Assert(_card.transform.rotation == VisualManager.Instance.FlippedOff);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}



