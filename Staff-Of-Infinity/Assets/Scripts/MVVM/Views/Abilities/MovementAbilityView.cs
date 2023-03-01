using MVVM.Models.Abilities;
using Types;

namespace MVVM.Views.Abilities
{
    public class MovementAbilityView : AbilityView
    {
        public MovementAbilityModel MovementAbilityModelReference => (MovementAbilityModel)AbilityModelReference;
        
        public override void Cast() { }

        public virtual void OnMovementStarted(float value = 0)
        {
            ExecuteAbilityStateChange((int)EntityMovementState.Moving, value);
        }

        public virtual void OnMovementEnded()
        {
            ExecuteAbilityStateChange((int)EntityMovementState.Idle, 0f);
        }

        protected float GetEntitySpeed()
        {
            var speed = (float)ExecuteAbilityValueChange();
            return speed;
        }

        private void Update()
        {
            Cast();
        }
    }
}
