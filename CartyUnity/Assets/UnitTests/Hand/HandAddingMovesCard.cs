using UnityEngine;
using Testing;
using CartyLib.CardsComponenets;
using CartyVisuals;
using CartyLib.BoardComponents;
using CartyLib;

[IntegrationTest.DynamicTest("CartyLibTests")]
class HandAddingMovesCard : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;
    private CanBeInHand _canbeinhand;
    private Hand _hand;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        _card.AddComponent<CartyLib.CardsComponenets.CanBeDetached>();
        _card.AddComponent<CartyLib.CardsComponenets.CanBeMoved>();
        var owned = _card.AddComponent<CartyLib.CardsComponenets.CanBeOwned>();
        owned.PlayerOwned = true;

        _hand = CartyEntitiesConstructors.CreateHand(true);
        _canbeinhand = _card.AddComponent<CartyLib.CardsComponenets.CanBeInHand>();

        _hand.Add(_canbeinhand);
    }

    void Update()
    {
        if (UpdateTime >= 2.0f)
        {
            Vector3 wanted = VisualManager.Instance.HandPositioning.PositionPlayer(0, 1);
            IntegrationTest.Assert(_card.transform.position == wanted);

            var wanted_rot = VisualManager.Instance.HandPositioning.RotationPlayer(0, 1);
            IntegrationTest.Assert(_card.transform.rotation == wanted_rot);

            Destroy(_card);
            Destroy(_hand);

            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



