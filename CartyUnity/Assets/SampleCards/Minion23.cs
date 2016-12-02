using System;
using Carty.CartyLib;
using UnityEngine;

/// <summary>
/// Minion with 2 attack and 3 health. No special effects.
/// Your card must implement at least ICardType and be MonoBehaviour to be considered a card.
/// </summary>
class Minion23 : MonoBehaviour, ICardType
{
    public CardInfo GetInfo()
    {
        CardInfo info = new CardInfo();
        // Unique id of the card type. Used for example when creating card. See SampleGame.
        info.UniqueCardTypeId = "minion23";
        // How many resources the card costs.
        info.Cost = 2;
        // Texture of the card front.
        info.CardFrontTexture = "Minion23";
        return info;
    }
}

