using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyVisuals;
using System.Collections;
using UnityEngine;
using System;

namespace Carty.CartyLib.Internals
{
    /// <summary>
    /// Wrapper around IGameState with assignable methods.
    /// Used in GameQueueManager.
    /// </summary>
    class GameStateWrapper : IGameState
    {
        public delegate void DmgDelegate(int amount);

        public DmgDelegate DmgToOpponentD { get; set; }
        public DmgDelegate DmgToSelfD { get; set; }
        public DmgDelegate HealOpponentD { get; set; }
        public DmgDelegate HealSelfD { get; set; }

        public void DealDamageToOpponent(int amount)
        {
            if (DmgToOpponentD != null) DmgToOpponentD(amount);
        }

        public void DealDamageToSelf(int amount)
        {
            if (DmgToSelfD != null) DmgToSelfD(amount);
        }

        public void HealOpponent(int amount)
        {
            if (HealOpponentD != null) HealOpponentD(amount);
        }

        public void HealSelf(int amount)
        {
            if (HealSelfD != null) HealSelfD(amount);
        }
    }
}
