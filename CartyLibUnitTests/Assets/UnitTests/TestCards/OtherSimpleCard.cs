using UnityEngine;
using CartyLib;
using System;

public class OtherSimpleCard : MonoBehaviour, ICardType
{
    public CardInfo GetInfo()
    {
        return new CardInfo { Cost = 0, UniqueCardTypeId = "othersimplecard" };
    }
}
