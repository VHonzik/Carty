using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;
using CartyLib.CardsComponenets;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeInHandAddToHand : MonoBehaviour
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

        _hand.AddedToHand(0, 1);
        IntegrationTest.Assert(_hand.IsInHand == true);
    }

    void Update()
    {
        if (UpdateTime >= 2.0f)
        {
            Vector3 wanted = VisualBridge.Instance.HandPositioning.PositionPlayer(0, 1);
            IntegrationTest.Assert(_card.transform.position == wanted);

            var wanted_rot = VisualBridge.Instance.HandPositioning.RotationPlayer(0, 1);
            IntegrationTest.Assert(_card.transform.rotation == wanted_rot);

            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



