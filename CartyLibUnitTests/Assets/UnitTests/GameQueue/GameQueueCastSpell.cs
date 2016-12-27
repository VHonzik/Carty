using UnityEngine;
using Carty.CartyLib;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
class GameQueueCastSpell : MonoBehaviour
{
    private int NoDrawSetting(int turn, bool player, bool playerWentFirst)
    {
        return 0;
    }

    int _updateCount = 0;
    private GameObject _card;

    // Use this for initialization
    void Start()
    {
        MatchInfo matchInfo = new MatchInfo();
        matchInfo.PlayerStartingHandCards = new string[1] { "simplespell" };
        GameManager.Instance.Settings.TurnStartCardDrawSetting = NoDrawSetting;
        GameManager.Instance.StartMatch(matchInfo);
    }

    // Update is called once per frame
    void Update()
    {
        if (_updateCount == 1)
        {
            IntegrationTest.Assert(GameManager.Instance.PlayerHand.Cards.Count == 1);

            _card = GameManager.Instance.PlayerHand.Cards[0].gameObject;

            GameManager.Instance.GameQueue.PlayCard(_card);
          
        }
        else if(_updateCount == 2)
        {
            IntegrationTest.Assert(_card.GetComponent<SimpleSpell>().CastCount == 1);

            GameManager.Instance.CleanUpMatch();
            IntegrationTest.Pass(gameObject);

        }

        _updateCount++;
    }
}
