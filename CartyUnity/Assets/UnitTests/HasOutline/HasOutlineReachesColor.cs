using UnityEngine;
using System.Collections;
using CartyLib;
using Testing;
using CartyLib.CardsComponenets;

[IntegrationTest.DynamicTest("CartyLibTests")]
class HasOutlineReachesColor : MonoBehaviour
{
    private float UpdateTime { get; set; }
    private GameObject _card;
    private HasOutline _outline;

    void Start()
    {
        UpdateTime = 0;
        _card = CardsGameObjects.OnlyDetachHandle();
        _card.AddComponent<CartyLib.CardsComponenets.CanBeDetached>();
        _outline = _card.AddComponent<CartyLib.CardsComponenets.HasOutline>();
        _outline.Request(this, Color.red);
    }

    void Update()
    {
        if (UpdateTime >= 0.5f)
        {
            IntegrationTest.Assert(_outline.WantedColor == Color.red);
            IntegrationTest.Assert(_outline.T >= 1.0f);
            Destroy(_card);
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
    }
}



