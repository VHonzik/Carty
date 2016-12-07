using UnityEngine;
using Carty.CartyLib;
using Carty.CartyLib.Internals.CardsComponents;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
class GameQueueDrawPlayerEnablesInteraction : MonoBehaviour
{
    private int NoDrawSetting(int turn, bool player, bool playerWentFirst)
    {
        return 0;
    }

    float _updateTime = 0;

    // Use this for initialization
    void Start()
    {
        MatchInfo matchInfo = new MatchInfo();
        matchInfo.PlayerDeckCards = new string[1] { "simplecard" };
        GameManager.Instance.Settings.TurnStartCardDrawSetting = NoDrawSetting;
        GameManager.Instance.StartMatch(matchInfo);
        GameManager.Instance.GameQueue.PlayerDrawCards(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (_updateTime >= 3.0f)
        {
            IntegrationTest.Assert(GameManager.Instance.PlayerHand.Cards.Count == 1);
            IntegrationTest.Assert(GameManager.Instance.PlayerHand.Cards[0].GetComponent<CanBeInteractedWith>().InteractionAllowed);
            GameManager.Instance.CleanUpMatch();
            IntegrationTest.Pass(gameObject);
        }

        _updateTime += Time.deltaTime;
    }
}
