﻿using UnityEngine;
using Carty.CartyLib;

[IntegrationTest.DynamicTest("CartyLibTestsBoardComponents")]
class GameManagerStartsGame : MonoBehaviour
{
    private int UpdateCount = 0;
    private float UpdateTime = 0;

    void Start()
    {
        MatchInfo match = new MatchInfo();
        match.PlayerGoesFirst = true;
        match.PlayerDeckCards = new string[2] { "simplecard", "simplecard" };
        match.EnemyDeckCards = new string[1] { "simplecard" };
        match.PlayerStartingHandCards = new string[1] { "simplecard" };
        match.EnemyStartingHandCards = new string[2] { "simplecard", "simplecard" };
        GameManager.Instance.StartMatch(match);

        IntegrationTest.Assert(GameManager.Instance.PlayerHand != null);
        IntegrationTest.Assert(GameManager.Instance.PlayerDeck != null);
        IntegrationTest.Assert(GameManager.Instance.EnemyDeck != null);
        IntegrationTest.Assert(GameManager.Instance.EnemyHand != null);

        IntegrationTest.Assert(GameManager.Instance.Settings != null);

        IntegrationTest.Assert(GameManager.Instance.PlayerDeck.Cards.Count == 1);
        IntegrationTest.Assert(GameManager.Instance.EnemyDeck.Cards.Count == 1);

        IntegrationTest.Assert(GameManager.Instance.PlayerHand.Cards.Count == 1);
        IntegrationTest.Assert(GameManager.Instance.EnemyHand.Cards.Count == 2);

    }

    void Update()
    {
        if(UpdateCount == 1)
        {
            GameManager.Instance.CleanUpMatch();
        }
        else if (UpdateTime >= 1.5f)
        {
            IntegrationTest.Pass(gameObject);
        }

        UpdateTime += Time.deltaTime;
        UpdateCount++;
    }
}
