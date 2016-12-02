using UnityEngine;
using Testing;
using Carty.CartyVisuals;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
class CanBeMovedFlipAndIsMoving : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;
    private CanBeMoved _move;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        _move = _card.AddComponent<CanBeMoved>();
        _move.Flip();
    }

    void Update()
    {
        if(UpdateTime <= 0.5f)
        {
            IntegrationTest.Assert(_move.IsMoving == true);
        }
        else if (UpdateTime >= 2.0f)
        {
            IntegrationTest.Assert(Quaternion.Angle(_card.transform.rotation, VisualManager.Instance.FlippedOff) <= 0.1f);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



