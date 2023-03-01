using System;
using System.Linq;
using Abstractions;
using Data;
using Implementations.Controllers;
using MVVM.Models;
using MVVM.Models.Entities;
using MVVM.ViewModels.Entities;
using MVVM.Views.Entities;
using UnityEditor;
using UnityEngine;

namespace MVVM.Views
{
    public class LevelView : BasicView
    {
        public event Action OnLevelCompleted;
        public int LevelId => BasicModelReference.Id;
        public LevelModel LevelModel => (LevelModel)BasicModelReference;

        [SerializeField] private GameObject entityParent;
        [field: SerializeField] public HorizontalBounds HorizontalBounds { get; private set; }
        [field: SerializeField] public VerticalBounds VerticalBounds { get; private set; }

        private EntityController _localEntityController;

        private PlayerView _currentPlayer;
        
        public override void InjectControllers(params Controller[] controllersToInject)
        {
            _localEntityController =
                (EntityController)controllersToInject.ToList().Find(controller => controller is EntityController);
        }

        public override void Initialize()
        {
            foreach (Transform child in entityParent.transform)
            {
                if (child.gameObject.TryGetComponent<PlayerView>(out var staffView))
                {
                    _currentPlayer = staffView;
                    var staffModel = Instantiate(_currentPlayer.PlayerModelReference);
                    Debug.Log(staffModel.StaffName);
                    var entityStaffViewModel 
                        = new PlayerViewModel(_currentPlayer, staffModel).BindViewModel();
                    _localEntityController.player = (PlayerViewModel)entityStaffViewModel;
                    _currentPlayer.Initialize();
                    staffModel.Initialize();
                }
            }
        }

        public override void Destruct()
        {
            Destroy(gameObject);
        }

        public void CompleteLevel()
        {
            OnLevelCompleted?.Invoke();
        }
        
#if UNITY_EDITOR            
        private void OnDrawGizmos()
        {
            if (EditorApplication.isPlaying) return;
            
            var currentCamera = Camera.main;
            if (currentCamera == null) return;
            
            var height = currentCamera.orthographicSize;
            var width = height * currentCamera.aspect;

            var size = new Vector3(width,height,0);
                
            Handles.color = Color.blue;
            Handles.DrawWireCube(Vector3.zero, size * 2);
            
            Handles.color = Color.red;
            Handles.DrawLine(new Vector3(-width + HorizontalBounds.left,height + VerticalBounds.up,0),
                new Vector3(-width + HorizontalBounds.left,-height + VerticalBounds.down,0));
            Handles.DrawLine(new Vector3(width + HorizontalBounds.right,-height + VerticalBounds.down,0),
                new Vector3(width + HorizontalBounds.right,height + VerticalBounds.up,0));
            Handles.DrawLine(new Vector3(width + HorizontalBounds.right,height + VerticalBounds.up,0),
                new Vector3(-width + HorizontalBounds.left,height + VerticalBounds.up,0));
            Handles.DrawLine(new Vector3(-width + HorizontalBounds.left,-height + VerticalBounds.down,0),
                new Vector3(width + HorizontalBounds.right,-height + VerticalBounds.down,0));
        }
#endif
    }
}
