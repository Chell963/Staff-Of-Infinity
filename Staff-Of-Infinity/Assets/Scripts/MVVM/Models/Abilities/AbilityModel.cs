using Abstractions;

namespace MVVM.Models.Abilities
{
    public abstract class AbilityModel : BasicModel
    {
        protected int CurrentAbilityIntState;
        
        public virtual void ChangeAbilityState(int entityAbilityState, params object[] abilityParameters)
        {
            CurrentAbilityIntState = entityAbilityState;
        }

        public virtual object ChangeAbilityValue()
        {
            return null;
        }
    }
}
