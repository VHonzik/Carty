using UnityEngine;
using Testing;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
class CanBeMovedMoveShortAndIsMoving : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;
    private CanBeMoved _move;
    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        _move = _card.AddComponent<CanBeMoved>();
        _move.Move(Vector3.one);
    }

    void Update()
    {
        if(UpdateTime <= 0.2f)
        {
            IntegrationTest.Assert(_move.IsMoving == true);
        }
        if (UpdateTime >= 1.0f)
        {
            IntegrationTest.Assert(_card.transform.position == Vector3.one);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}


