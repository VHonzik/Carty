using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyVisuals;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Carty.CartyLib.Internals.BoardComponents
{
    /// <summary>
    /// Component representing the player or enemy entity.
    /// </summary>
    public class Hero : MonoBehaviour
    {
        /// <summary>
        /// Whether the hero is a player or enemy.
        /// </summary>
        public bool IsPlayer;

        /// <summary>
        /// Maximal health the hero can have at the time.
        /// </summary>
        public int MaxHealth { get; set; }

        /// <summary>
        /// Current amount of health.
        /// </summary>
        public int CurrentHealth { get; set; }

        /// <summary>
        /// Assembles a hero.
        /// </summary>
        /// <param name="player">Whether it is players' hero.</param>
        /// <returns>Created Hero object.</returns>
        public static Hero CreateHero(bool player)
        {
            GameObject go = new GameObject(player ? "PlayerHero" : "EnemyHero");
            var result = go.AddComponent<Hero>();
            result.IsPlayer = player;
            return result;
        }

        /// <summary>
        /// Deal an amount of damage to the hero.
        /// </summary>
        /// <param name="amount">Amount of damage to deal.</param>
        public void DealDamage(int amount)
        {
            CurrentHealth -= amount;
            CurrentHealth = Math.Max(0, CurrentHealth);
        }

        /// <summary>
        /// Heal the hero by an amount of damage .
        /// </summary>
        /// <param name="amount">mount of damage to heal.</param>
        public void Heal(int amount)
        {
            CurrentHealth += amount;
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth);
        }
    }
}
