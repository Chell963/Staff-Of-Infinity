using System;
using MVVM.Models.Entities;
using MVVM.Views.Abilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MVVM.Views.Entities
{
    public class PlayerView : EntityView
    {
        public event Action<float> OnMovementInputStarted;
        public event Action OnMovementInputEnded;
        public event Action<float> OnHoldingInputStarted;
        public event Action OnHoldingInputEnded;
        
        public PlayerModel PlayerModelReference => (PlayerModel)EntityModelReference;
        
        [SerializeField] private SpriteRenderer staffSprite;

        public override void Initialize()
        {
            staffSprite.sprite = PlayerModelReference.StaffSprite;
            
            var movementAbility 
                = (HorizontalMovementAbilityView)ViewAbilities
                    .Find(ability => ability is HorizontalMovementAbilityView);

            if (movementAbility != null)
            {
                OnMovementInputStarted += movementAbility.OnMovementStarted;
                OnMovementInputEnded += movementAbility.OnMovementEnded;
            }
            
            var flyingAbility 
                = (FlyingMovementAbilityView)ViewAbilities
                    .Find(ability => ability is FlyingMovementAbilityView);
            
            if (flyingAbility != null)
            {
                OnHoldingInputStarted += flyingAbility.OnMovementStarted;
                OnHoldingInputEnded += flyingAbility.OnMovementEnded;
            }
        }

        public override void Destruct()
        {
            var movementAbility 
                = (MovementAbilityView)ViewAbilities
                    .Find(ability => ability is MovementAbilityView);

            if (movementAbility != null)
            {
                OnMovementInputStarted -= movementAbility.OnMovementStarted;
                OnMovementInputEnded -= movementAbility.OnMovementEnded;
            }
            
            var flyingAbility 
                = (FlyingMovementAbilityView)ViewAbilities
                    .Find(ability => ability is FlyingMovementAbilityView);
            
            if (flyingAbility != null)
            {
                OnHoldingInputStarted -= flyingAbility.OnMovementStarted;
                OnHoldingInputEnded -= flyingAbility.OnMovementEnded;
            }
        }

        private void OnMove(InputValue value)
        {
            var moveValue = value.Get<float>();
            if (moveValue == 0)
            {
                OnMovementInputEnded?.Invoke();
            }
            else
            {
                OnMovementInputStarted?.Invoke(moveValue);
            }
        }

        private void OnHolding(InputValue value)
        {
            if (value.isPressed)
            {
                OnHoldingInputStarted?.Invoke(1);
            }
            else
            {
                OnHoldingInputEnded?.Invoke();
            }
        }
    }
}
