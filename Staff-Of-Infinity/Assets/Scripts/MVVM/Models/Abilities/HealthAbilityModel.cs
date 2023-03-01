using System;
using UnityEngine;

namespace MVVM.Models.Abilities
{
    [CreateAssetMenu(fileName = "HealthAbilityModel", menuName = "Models/Abilities/HealthAbilityModel")]
    public class HealthAbilityModel : AbilityModel
    {
        public event Action OnDeathEvoked;
        
        [field: SerializeField] public int MaxHealth { get; private set; }

        private int Health { get; set; }

        public override void Initialize()
        {
            Health = MaxHealth;
        }

        public void ChangeHealth(int changeAmount)
        {
            if(changeAmount < 0)
                TakeDamage();
            if(changeAmount > 0)
                HealDamage();
        }

        protected virtual void TakeDamage(int damageAmount = -1)
        {
            if (Health + damageAmount > 0)
            {
                Health += damageAmount;
            }
            else
            {
                OnDeathEvoked?.Invoke();
            }
        }

        private void HealDamage(int healAmount = 1)
        {
            if (Health + healAmount < MaxHealth)
            {
                Health += healAmount;
            }
        }
    }
}
