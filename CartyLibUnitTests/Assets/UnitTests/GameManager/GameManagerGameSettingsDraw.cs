using UnityEngine;
using Carty.CartyLib;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
class GameManagerGameSettingsDraw : MonoBehaviour
{
    private int UpdateCount = 0;
    private float UpdateTime = 0;

    private int DrawSetting(int turn, bool player, bool playerWentFirst)
    {
        if (turn == 1) return 1;
        return 0;
    }

    void Start()
    {
        MatchInfo matchInfo = new MatchInfo();
        matchInfo.PlayerDeckCards = new string[2] { "simplecard", "simplecard" };
        GameManager.Instance.Settings.TurnStartCardDrawSetting = DrawSetting;
        GameManager.Instance.StartMatch(matchInfo);
    }

    void Update()
    {
        if(UpdateCount == 0)
        {
            IntegrationTest.Assert(GameManager.Instance.PlayerDeck.Cards.Count == 2);
            GameManager.Instance.StartPlayerTurn();
        }
        else if(UpdateCount == 1)
        {
            IntegrationTest.Assert(GameManager.Instance.PlayerDeck.Cards.Count == 1);
            GameManager.Instance.StartPlayerTurn();
        }
        else if(UpdateCount == 2)
        {
            IntegrationTest.Assert(GameManager.Instance.PlayerDeck.Cards.Count == 1);

            GameManager.Instance.CleanUpMatch();
        }
        else if(UpdateTime >= 1.5f)
        {
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
        UpdateCount++;
    }
}
