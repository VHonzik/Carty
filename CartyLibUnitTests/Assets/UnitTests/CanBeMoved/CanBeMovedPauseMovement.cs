using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
class CanBeMovedPauseMovement : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CanBeMoved>();
        move.PauseMovement(1.0f).MoveInstantly(Vector3.one);
    }

    void Update()
    {
        if (UpdateTime <= 1.0f)
        {
            IntegrationTest.Assert(_card.transform.position == Vector3.zero);
        }
        else if(UpdateTime >= 1.1f)
        {
            IntegrationTest.Assert(_card.transform.position == Vector3.one);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



