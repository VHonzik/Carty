using UnityEngine;
using Carty.CartyLib;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
class GameQueueDrawPlayerCardRemovesFromDeck : MonoBehaviour
{
    private int NoDrawSetting(int turn, bool player, bool playerWentFirst)
    {
        return 0;
    }

    int _updateCount = 0;

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
        if(_updateCount == 1)
        {
            IntegrationTest.Assert(GameManager.Instance.PlayerDeck.Cards.Count == 0);
            IntegrationTest.Pass(gameObject);
        }

        _updateCount++;
    }
}
