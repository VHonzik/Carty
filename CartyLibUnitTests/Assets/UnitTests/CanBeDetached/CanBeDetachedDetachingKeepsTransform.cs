﻿using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CanBeDetachedDetachingKeepsTransform : MonoBehaviour
{
    private GameObject _card;
    private GameObject _handle;
    private CartyLib.CardsComponenets.CanBeDetached _detachable;

    void Awake()
    {
        _card = CardsGameObjects.OnlyDetachHandle();
        _detachable = _card.AddComponent<CartyLib.CardsComponenets.CanBeDetached>();
        _handle = _detachable.Handle;

        _detachable.Detached = true;

        IntegrationTest.Assert(Vector3.Distance(_card.transform.position, _handle.transform.position) <= 0.0f);
        IntegrationTest.Assert(Quaternion.Angle(_card.transform.rotation, _handle.transform.rotation) <= 0.1f);
        IntegrationTest.Assert(Vector3.Distance(_card.transform.position, _detachable.DetachedPosition) <= 0.0f);
        IntegrationTest.Assert(Quaternion.Angle(_card.transform.rotation, _detachable.DetachedRotation) <= 0.1f);

        Destroy(_card);

        IntegrationTest.Pass(gameObject);
    }
}
