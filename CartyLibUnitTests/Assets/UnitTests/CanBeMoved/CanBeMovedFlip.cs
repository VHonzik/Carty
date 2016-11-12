using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;
using CartyVisuals;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeMovedFlip : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CartyLib.CardsComponenets.CanBeMoved>();
        move.Flip();
    }

    void Update()
    {
        if (UpdateTime >= 2.0f)
        {
            IntegrationTest.Assert(Quaternion.Angle(_card.transform.rotation, VisualManager.Instance.FlippedOff) <= 0.1f);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



