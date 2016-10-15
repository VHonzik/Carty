using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeMovedRotate : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;
    private Quaternion _wanted_rot;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CartyLib.CardsComponenets.CanBeMoved>();
        _wanted_rot = _card.transform.rotation * Quaternion.Euler(45, 0, 0);
        move.Rotate(_wanted_rot);
    }

    void Update()
    {
        if (UpdateTime >= 2.0f)
        {
            IntegrationTest.Assert(Quaternion.Angle(_card.transform.rotation, _wanted_rot) <= 0.1f);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}


