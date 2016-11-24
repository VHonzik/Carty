using UnityEngine;
using Testing;
using Carty.CartyVisuals;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsCardComponents")]
class CanBeMovedPauseRotation : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        var move = _card.AddComponent<CanBeMoved>();
        move.PauseRotation(1.0f).RotateInstantly(Quaternion.Euler(90, 0, 0));
    }

    void Update()
    {
        if (UpdateTime <= 1.0f)
        {
            IntegrationTest.Assert(_card.transform.rotation == VisualManager.Instance.FlippedOn);
        }
        else if (UpdateTime >= 1.1f)
        {
            IntegrationTest.Assert(_card.transform.rotation == Quaternion.Euler(90, 0, 0));
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



