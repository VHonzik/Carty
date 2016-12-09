using UnityEngine;
using System.Collections;
using Carty.CartyLib;
using System;

public class SpellDeal1DamageToEnemyHero : MonoBehaviour, ICardType, ISpell
{
    public CardInfo GetInfo()
    {
        CardInfo info = new CardInfo();
        // Unique id of the card type. Used for example when creating card. See SampleGame.
        info.UniqueCardTypeId = "spell1dmgoponnent";
        // How many resources the card costs.
        info.Cost = 1;
        // Texture of the card front.
        info.CardFrontTexture = "Spell1DmgOponnnent";
        return info;
    }

    public void OnCast(IGameState state)
    {
        throw new NotImplementedException();
    }
}
