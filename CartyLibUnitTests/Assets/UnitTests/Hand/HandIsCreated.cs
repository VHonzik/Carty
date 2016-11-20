﻿using UnityEngine;
using CartyLib.Internals.BoardComponents;

[IntegrationTest.DynamicTest("CartyLibTests")]
class HandIsCreated : MonoBehaviour
{
    void Awake()
    {
        Hand hand = Hand.CreateHand(true);

        IntegrationTest.Assert(hand != null);
        IntegrationTest.Assert(hand.PlayerOwned == true);
        IntegrationTest.Assert(hand.Cards != null);
        IntegrationTest.Assert(hand.Cards.Count == 0);

        Destroy(hand.gameObject);

        IntegrationTest.Pass(gameObject);
    }
}
