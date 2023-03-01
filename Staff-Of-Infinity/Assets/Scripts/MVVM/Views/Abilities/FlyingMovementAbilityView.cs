using Types;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MVVM.Views.Abilities
{
    public class FlyingMovementAbilityView : MovementAbilityView
    {
        public override void Cast()
        {
            var speed = GetEntitySpeed();
            var mousePosition = Mouse.current.position.ReadValue();
            if (Camera.main == null) return;
            var worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            var movementVector = new Vector3(worldMousePosition.x, worldMousePosition.y);
            var step = Time.deltaTime * speed;
            var ownerTransform = Owner.transform;
            var position = ownerTransform.position;
            var rotation = ownerTransform.eulerAngles;
            Owner.transform.position = Vector3.MoveTowards(position, movementVector, step);
            Owner.transform.eulerAngles += new Vector3(0,0,step * 100f);
            if (speed != 0) return;
            Owner.transform.eulerAngles = Vector3.zero;
            Owner.EntityBody.gravityScale = 1;
        }

        public override void OnMovementStarted(float value = 0)
        {
            ExecuteAbilityStateChange((int)EntityMovementState.Flying, value);
            Owner.EntityBody.gravityScale = 0;
        }

        public override void OnMovementEnded()
        {
            ExecuteAbilityStateChange((int)EntityMovementState.Idle, 0f);
        }

        private void Update()
        {
            Cast();
        }
    }
}
