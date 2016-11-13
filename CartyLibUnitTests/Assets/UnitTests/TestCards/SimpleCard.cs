using UnityEngine;
using CartyLib;
using System;

public class SimpleCard : MonoBehaviour, ICardType
{
    public CardInfo GetInfo()
    {
        return new CardInfo { Cost = 0, Description = "I don't do much.", Title = "Simple card", UniqueCardTypeId = "simplecard" };
    }
}
