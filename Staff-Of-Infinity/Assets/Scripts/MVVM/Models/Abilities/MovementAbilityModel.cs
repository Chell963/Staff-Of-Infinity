using Types;
using UnityEngine;

namespace MVVM.Models.Abilities
{
    [CreateAssetMenu(fileName = "MovementAbilityModel", menuName = "Models/Abilities/MovementAbilityModel")]
    public class MovementAbilityModel : AbilityModel
    {
        [field: SerializeField] public float MaxSpeed { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        
        private EntityMovementState _movementState;
        
        private float Speed { get; set; }
        private float Direction { get; set; }

        public override void ChangeAbilityState(int entityAbilityState, params object[] abilityParameters)
        {
            base.ChangeAbilityState(entityAbilityState, abilityParameters);
            _movementState = (EntityMovementState)CurrentAbilityIntState;
            Direction = (float)abilityParameters[0];
        }

        public override object ChangeAbilityValue()
        {
            var modelSpeed = MaxSpeed;
            var modelAcceleration = Acceleration;
            var nearlyEqualZero = Mathf.Abs(Speed) < 0.1f;
            Speed = Direction switch
            {
                -1 => Speed - modelAcceleration,
                0 => nearlyEqualZero 
                    ? 0 
                    : Speed > 0 
                        ? Speed - modelAcceleration 
                        : Speed + modelAcceleration,
                1 => Speed + modelAcceleration,
                _ => Speed
            };
            Speed = Speed > modelSpeed ? modelSpeed : Speed < -modelSpeed ? -modelSpeed : Speed;
            return Speed;
        }
    }
}
