using MVVM.Views;
using UnityEngine;

namespace Implementations.Holders
{
    public class GameplayCamera : CameraHolder
    {
        [SerializeField] private float   interpolationSpeed;
        [SerializeField] private Vector3 cameraOffset = new Vector3(0,0,-10);

        private Vector3 _playerPosition;

        private LevelView _currentLevel;
        private StaffView _currentPlayer;

        public void InitializeCamera(LevelView level, StaffView playerView)
        {
            _currentLevel = level;
            _currentPlayer = playerView;
        }

        private void Update()
        {
            if (_currentPlayer == null || _currentLevel == null) return;
            var horizontalBounds = _currentLevel.HorizontalBounds;
            var verticalBounds = _currentLevel.VerticalBounds;
            var playerPosition = _currentPlayer.transform.position;
            _playerPosition.x = playerPosition.x;
            _playerPosition.y = playerPosition.y;
            var position = transform.position;
            position = 
                Vector3.Lerp(position, _playerPosition + cameraOffset,
                    interpolationSpeed * Time.deltaTime);
            position =
                new Vector3(
                    Mathf.Clamp(position.x, -horizontalBounds.left, horizontalBounds.right),
                    Mathf.Clamp(position.y, -verticalBounds.down, verticalBounds.up), 
                    position.z
                );
            transform.position = position;
        }
    }
}