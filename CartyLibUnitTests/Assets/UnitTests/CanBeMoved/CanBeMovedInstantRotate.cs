using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeMovedInstantRotate : MonoBehaviour
{
    private int UpdateCount { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateCount = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CanBeMoved>();
        move.RotateInstantly(Quaternion.Euler(90, 0, 0));
    }

    void Update()
    {
        if (UpdateCount == 1)
        {
            IntegrationTest.Assert(_card.transform.rotation == Quaternion.Euler(90, 0, 0));
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}


