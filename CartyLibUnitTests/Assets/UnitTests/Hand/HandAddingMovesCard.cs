using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;
using CartyVisuals;
using CartyLib.Internals.BoardComponents;

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
        _card = CardsGameObjects.DetachHandleWithHand(true);

        _hand = Hand.CreateHand(true);
        _canbeinhand = _card.AddComponent<CanBeInHand>();

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



