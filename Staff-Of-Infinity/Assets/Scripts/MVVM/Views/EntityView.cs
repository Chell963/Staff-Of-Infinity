using System;
using Abstractions;
using MVVM.Models;
using Types;
using UnityEngine;

namespace MVVM.Views
{
    public class EntityView : BasicView
    {
        public event Func<float> OnMoved;
        public event Action<EntityMovementState, float> OnMovementStateChanged;
        
        protected EntityModel EntityModel => (EntityModel)BasicModel;

        [SerializeField] protected Rigidbody2D entityBody;
        [SerializeField] protected Collider2D  entityCollider;
        
        protected void OnMovementStarted(float value)
        {
            OnMovementStateChanged?.Invoke(EntityMovementState.Move, value);
        }

        protected void OnMovementEnded()
        {
            OnMovementStateChanged?.Invoke(EntityMovementState.Idle, 0);
        }

        protected float GetEntitySpeedOnMove()
        {
            if (OnMoved == null) return 0;
            var speed = OnMoved.Invoke();
            return speed;
        }

        protected virtual void HandleMovement() { }
    }
}
