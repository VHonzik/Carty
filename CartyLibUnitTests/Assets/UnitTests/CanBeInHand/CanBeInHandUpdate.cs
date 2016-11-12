using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;
using CartyLib.CardsComponenets;
using CartyVisuals;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeInHandUpdate : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;
    private CanBeInHand _hand;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        _card.AddComponent<CartyLib.CardsComponenets.CanBeDetached>();
        _card.AddComponent<CartyLib.CardsComponenets.CanBeMoved>();
        var owned = _card.AddComponent<CartyLib.CardsComponenets.CanBeOwned>();
        owned.PlayerOwned = true;

        _hand = _card.AddComponent<CartyLib.CardsComponenets.CanBeInHand>();
        _card.transform.position = VisualManager.Instance.HandPositioning.PositionPlayer(0, 1);
        _card.transform.rotation = VisualManager.Instance.HandPositioning.RotationPlayer(0, 1);
        _hand.IsInHand = true;

        _hand.OnIndexChanged(1, 2);
    }

    void Update()
    {
        if (UpdateTime >= 2.0f)
        {
            Vector3 wanted = VisualManager.Instance.HandPositioning.PositionPlayer(1, 2);
            IntegrationTest.Assert(_card.transform.position == wanted);

            var wanted_rot = VisualManager.Instance.HandPositioning.RotationPlayer(1, 2);
            IntegrationTest.Assert(_card.transform.rotation == wanted_rot);

            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



