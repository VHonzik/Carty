using UnityEngine;
using Carty.CartyLib;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
class GameManagerCleanUps : MonoBehaviour
{
    private float UpdateTime;

    private int NoDrawSetting(int turn, bool player, bool playerWentFirst)
    {
        return 0;
    }

    // Use this for initialization
    void Start()
    {
        MatchInfo match = new MatchInfo();
        match.PlayerDeckCards = new string[2] { "simplecard", "simplecard" };
        match.EnemyDeckCards = new string[1] { "simplecard" };
        match.PlayerStartingHandCards = new string[1] { "simplecard" };
        match.EnemyStartingHandCards = new string[2] { "simplecard", "simplecard" };

        GameManager.Instance.Settings.TurnStartCardDrawSetting = NoDrawSetting;
        GameManager.Instance.StartMatch(match);
        GameManager.Instance.CleanUpMatch();
    }

    void Update()
    {
        if(UpdateTime >= 0.5f)
        {
            IntegrationTest.Assert(GameManager.Instance.PlayerDeck.Cards.Count == 0);
            IntegrationTest.Assert(GameManager.Instance.EnemyDeck.Cards.Count == 0);
            IntegrationTest.Assert(GameManager.Instance.PlayerHand.Cards.Count == 0);
            IntegrationTest.Assert(GameManager.Instance.EnemyHand.Cards.Count == 0);
            IntegrationTest.Assert(GameManager.Instance.EnemyTurnCount == 0);
            IntegrationTest.Assert(GameManager.Instance.PlayerTurnCount == 0);

            IntegrationTest.Assert(GameManager.Instance.MatchInfo == null);

            IntegrationTest.Assert(GameManager.Instance.GameQueue.Queue.Empty == true);

            IntegrationTest.Pass(gameObject);
        }
        UpdateTime += Time.deltaTime;
    }

}
