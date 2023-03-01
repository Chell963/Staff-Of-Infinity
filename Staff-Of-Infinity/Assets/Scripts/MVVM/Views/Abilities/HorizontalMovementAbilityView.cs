using UnityEngine;

namespace MVVM.Views.Abilities
{
    public class HorizontalMovementAbilityView : MovementAbilityView
    {
        public override void Cast()
        {
            var speed = GetEntitySpeed();
            var movementVector = new Vector3(speed, 0);
            Owner.transform.position += movementVector * Time.deltaTime;
        }
    }
}
