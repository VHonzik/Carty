using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTests")]
public class CanBeDetachedDifferentTransform : MonoBehaviour
{
    private int UpdateCount { get; set; }

    private GameObject _card;
    private GameObject _handle;
    private CanBeDetached _detachable;
    private Vector3 _prev_trans_handle_pos;
    private Quaternion _prev_trans_handle_rot;

    void Awake()
    {
        _card = CardsGameObjects.OnlyDetachHandle();
        _detachable = _card.AddComponent<CanBeDetached>();
        _handle = _detachable.Handle;

        _prev_trans_handle_pos = _handle.transform.position;
        _prev_trans_handle_rot = _handle.transform.rotation;

        _detachable.Detached = true;
        UpdateCount = 0;
    }

    void Update()
    {
        if(UpdateCount == 0)
        {
            _card.transform.position = Vector3.right;
            _card.transform.rotation = Quaternion.Euler(90, 0, 0);
            _detachable.DetachedPosition = Vector3.left;
            _detachable.DetachedRotation = Quaternion.Euler(0, 0, 90);
        }
        else if(UpdateCount == 2)
        {
            IntegrationTest.Assert(Vector3.Distance(_prev_trans_handle_pos, _handle.transform.position) > 0.0f);
            IntegrationTest.Assert(Quaternion.Angle(_prev_trans_handle_rot, _handle.transform.rotation) > 0.0f);
            IntegrationTest.Assert(Vector3.Distance(_card.transform.position, _handle.transform.position) > 0.0f);
            IntegrationTest.Assert(Quaternion.Angle(_card.transform.rotation, _handle.transform.rotation) > 0.0f);

            Destroy(_card);

            IntegrationTest.Pass(gameObject);
        }

        UpdateCount++;
    }
}
