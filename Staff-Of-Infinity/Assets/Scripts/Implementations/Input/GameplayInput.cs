using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Implementations.Input
{
    public class GameplayInput : MonoBehaviour
    {
        public event Action<float> OnMovementInputStarted;
        public event Action OnMovementInputEnded;
        
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
    }
}
