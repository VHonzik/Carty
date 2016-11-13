using UnityEngine;
using Testing;
using CartyLib.Internals.CardsComponents;
using CartyVisuals;
using CartyLib.Internals.BoardComponents;
using CartyLib;

[IntegrationTest.DynamicTest("CartyLibTests")]
class GameManagerStartsGame : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.StartMatch();

        IntegrationTest.Assert(GameManager.Instance.PlayerHand != null);
        IntegrationTest.Assert(GameManager.Instance.PlayerDeck != null);
        IntegrationTest.Assert(GameManager.Instance.EnemyDeck != null);
        IntegrationTest.Assert(GameManager.Instance.EnemyHand != null);

        IntegrationTest.Assert(GameManager.Instance.Settings != null);

        IntegrationTest.Pass(gameObject);
    }
}
