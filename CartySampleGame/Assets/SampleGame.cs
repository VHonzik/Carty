﻿using UnityEngine;
using Carty.CartyLib;
using Carty.CartyVisuals;

/// <summary>
/// Example of how to start a sample game.
/// </summary>
public class SampleGame : MonoBehaviour {

	void Start () {

        VisualManager.Instance.CardTexturesPath = "CardsFronts";

        // Basic match info needed for GameManager.StartMatch
        MatchInfo match = new MatchInfo();
        match.PlayerAmountOfCardDrawBeforeGame = 3;
        match.EnemyAmountOfCardDrawBeforeGame = 2;
        match.PlayerGoesFirst = true;
        match.PlayerStartingResource = 1;
        match.EnemyStartingResource = 1;

        // Use deck builder utility class
        DeckBuilder deckBuilder = new DeckBuilder();
        deckBuilder.Add("bowarrowhat", 20);

        match.PlayerDeckCards = deckBuilder.ToArray();
        match.EnemyDeckCards = deckBuilder.ToArray();

        GameManager.Instance.StartMatch(match);
	}
	
}
