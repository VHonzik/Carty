using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeMovedMoveShort : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CanBeMoved>();
        move.Move(Vector3.one);
    }

    void Update()
    {
        if (UpdateTime >= 1.0f)
        {
            IntegrationTest.Assert(_card.transform.position == Vector3.one);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}


