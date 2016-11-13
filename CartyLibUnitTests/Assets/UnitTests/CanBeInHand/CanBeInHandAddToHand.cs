using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;
using CartyLib.Internals.CardsComponents;
using CartyVisuals;
using CartyLib.Internals.BoardComponents;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeInHandAddToHand : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;
    private CanBeInHand _canbeinhand;
    Hand _hand;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        _card.AddComponent<CanBeDetached>();
        _card.AddComponent<CanBeMoved>();
        var owned = _card.AddComponent<CanBeOwned>();
        owned.PlayerOwned = true;

        _hand = Hand.CreateHand(true);
        _canbeinhand = _card.AddComponent<CanBeInHand>();

        _canbeinhand.AddedToHand(0, 1, _hand);
        IntegrationTest.Assert(_canbeinhand.IsInHand == true);
    }

    void Update()
    {
        if (UpdateTime >= 2.0f)
        {
            Vector3 wanted = VisualManager.Instance.HandPositioning.PositionPlayer(0, 1);
            IntegrationTest.Assert(_card.transform.position == wanted);

            var wanted_rot = VisualManager.Instance.HandPositioning.RotationPlayer(0, 1);
            IntegrationTest.Assert(_card.transform.rotation == wanted_rot);

            Destroy(_hand.gameObject);
            Destroy(_card);

            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



