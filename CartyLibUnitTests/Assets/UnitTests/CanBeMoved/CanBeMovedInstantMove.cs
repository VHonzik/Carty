using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeMovedInstantMove : MonoBehaviour
{
    private int UpdateCount { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateCount = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CanBeMoved>();
        move.MoveInstantly(Vector3.one);
    }

    void Update()
    {
        if(UpdateCount == 1)
        {
            IntegrationTest.Assert(_card.transform.position == Vector3.one);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}

