using System;
using Abstractions;
using MVVM.Models.Abilities;
using MVVM.Views.Entities;

namespace MVVM.Views.Abilities
{
    public abstract class AbilityView : BasicView
    {
        public event Action<int, object[]> OnAbilityStateChanged;
        public event Func<object> OnAbilityValueChanged;
        
        public AbilityModel AbilityModelReference => (AbilityModel)BasicModelReference;
        
        protected EntityView Owner;
        
        public void SetOwner(EntityView owner)
        {
            Owner = owner;
        }

        public virtual void Cast() { }

        protected void ExecuteAbilityStateChange(int entityAbilityState, params object[] abilityParameters)
        {
            OnAbilityStateChanged?.Invoke(entityAbilityState, abilityParameters);
        }
        
        protected object ExecuteAbilityValueChange()
        {
            return OnAbilityValueChanged?.Invoke();
        }
    }
}
