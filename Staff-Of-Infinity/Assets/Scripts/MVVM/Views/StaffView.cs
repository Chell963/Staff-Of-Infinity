using Implementations.Input;
using MVVM.Models;
using UnityEngine;

namespace MVVM.Views
{
    public class StaffView : EntityView
    {
        public StaffModel StaffModel => (StaffModel)EntityModel;

        [SerializeField] private GameplayInput  gameplayInput;
        [SerializeField] private SpriteRenderer staffSprite;

        public override void Initialize()
        {
            gameplayInput.OnMovementInputStarted += OnMovementStarted;
            gameplayInput.OnMovementInputEnded += OnMovementEnded;
        }

        public override void Destruct()
        {
            gameplayInput.OnMovementInputStarted -= OnMovementStarted;
            gameplayInput.OnMovementInputEnded -= OnMovementEnded;
        }

        protected override void HandleMovement()
        {
            var speed = GetEntitySpeedOnMove();
            var movementVector = new Vector3(speed, 0);
            entityBody.transform.position += movementVector * Time.deltaTime;
        }

        private void Update()
        {
            HandleMovement();
        }
    }
}
