using UnityEngine;
using Carty.CartyLib;
using System;

public class SimpleSpell : MonoBehaviour, ICardType, ISpell
{
    public int CastCount { get; set; }

    public CardInfo GetInfo()
    {
        return new CardInfo { Cost = 0, UniqueCardTypeId = "simplespell" };
    }

    public void OnCast(IGameState state)
    {
        CastCount++;
    }
}
