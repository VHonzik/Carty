using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;
using CartyVisuals;
using CartyLib.Internals.BoardComponents;
using CartyLib;

[IntegrationTest.DynamicTest("CartyLibTests")]
class HandRemovingMovesCards : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card_stay;
    private GameObject _card_remove;
    private Hand _hand;

    void Start()
    {
        UpdateTime = 0;
        _card_stay = CardsGameObjects.DetachHandleWithHand(true);
        _card_remove = CardsGameObjects.DetachHandleWithHand(true);

        _card_stay.transform.position = VisualManager.Instance.HandPositioning.PositionPlayer(0, 2);
        _card_stay.transform.rotation = VisualManager.Instance.HandPositioning.RotationPlayer(0, 2);

        _card_remove.transform.position = VisualManager.Instance.HandPositioning.PositionPlayer(1, 2);
        _card_remove.transform.rotation = VisualManager.Instance.HandPositioning.RotationPlayer(1, 2);

        _hand = Hand.CreateHand(true);

        _hand.Add(_card_stay.GetComponent<CanBeInHand>());
        _hand.Add(_card_remove.GetComponent<CanBeInHand>());

        _hand.Remove(_card_remove.GetComponent<CanBeInHand>());
    }

    void Update()
    {
        if (UpdateTime >= 2.0f)
        {
            Vector3 wanted = VisualManager.Instance.HandPositioning.PositionPlayer(0, 1);
            IntegrationTest.Assert(_card_stay.transform.position == wanted);

            var wanted_rot = VisualManager.Instance.HandPositioning.RotationPlayer(0, 1);
            IntegrationTest.Assert(_card_stay.transform.rotation == wanted_rot);

            Destroy(_card_stay);
            Destroy(_card_remove);
            Destroy(_hand);

            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}




