using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;

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
        _card.AddComponent<CanBeDetached>();
        _outline = _card.AddComponent<HasOutline>();
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



