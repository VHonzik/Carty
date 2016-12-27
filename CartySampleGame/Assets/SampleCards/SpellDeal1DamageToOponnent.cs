using UnityEngine;
using System.Collections;
using Carty.CartyLib;
using System;

public class SpellDeal1DamageToOponnent : MonoBehaviour, ICardType, ISpell
{
    // ICardType, bare minimum information about the card
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

    // ISpell, triggered when the card is played
    public void OnCast(IGameState state)
    {
        state.DealDamageToOpponent(1);
    }
}
