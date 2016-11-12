using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;
using CartyLib.CardsComponenets;

[IntegrationTest.DynamicTest("CartyLibTests")]
class CanBeInHandNotInHand : MonoBehaviour
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
        _card.transform.position = Vector3.zero;
        _card.transform.rotation = Quaternion.identity;

        _hand.OnIndexChanged(1, 2);
    }

    void Update()
    {
        if (UpdateTime >= 0.5f)
        {
            IntegrationTest.Assert(_card.transform.position == Vector3.zero);
            IntegrationTest.Assert(_card.transform.rotation == Quaternion.identity);

            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}




