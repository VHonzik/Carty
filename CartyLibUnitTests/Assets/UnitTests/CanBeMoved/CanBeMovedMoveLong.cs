using UnityEngine;
using Testing;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
class CanBeMovedMoveLong : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CanBeMoved>();
        move.Move(Vector3.one * 5.0f);
    }

    void Update()
    {
        if (UpdateTime >= 3.0f)
        {
            IntegrationTest.Assert(_card.transform.position == Vector3.one * 5.0f);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



