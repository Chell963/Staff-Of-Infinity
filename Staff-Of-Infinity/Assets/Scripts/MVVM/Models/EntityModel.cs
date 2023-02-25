using Abstractions;
using Types;
using UnityEngine;

namespace MVVM.Models
{
    public abstract class EntityModel : BasicModel
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public float MaxSpeed { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        
        protected EntityMovementState MovementState;
        protected EntityFightState FightState;
        
        protected float Speed { get; private set; }
        protected float Direction { get; private set; }

        public float ChangeSpeed()
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
        
        public void ChangeMovementState(EntityMovementState entityMovementState, float direction = 0)
        {
            MovementState = entityMovementState;
            Direction = direction;
        }
        
        public void ChangeFightState(EntityFightState entityFightState)
        {
            FightState = entityFightState;
        }
    }
}
