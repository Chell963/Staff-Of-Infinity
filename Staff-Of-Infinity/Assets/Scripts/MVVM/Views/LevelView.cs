using System;
using System.Linq;
using Abstractions;
using Data;
using Implementations.Controllers;
using Interfaces;
using MVVM.Models;
using MVVM.ViewModels;
using UnityEditor;
using UnityEngine;

namespace MVVM.Views
{
    public class LevelView : BasicView
    {
        public event Action OnLevelCompleted;
        public int LevelId => BasicModel.Id;
        public LevelModel LevelModel => (LevelModel)BasicModel;

        [SerializeField] private GameObject entityParent;
        [field: SerializeField] public HorizontalBounds HorizontalBounds { get; private set; }
        [field: SerializeField] public VerticalBounds VerticalBounds { get; private set; }

        private EntityController _localEntityController;
        
        public override void InjectControllers(params Controller[] controllersToInject)
        {
            _localEntityController =
                (EntityController)controllersToInject.ToList().Find(controller => controller is EntityController);
        }

        public override void Initialize()
        {
            foreach (Transform child in entityParent.transform)
            {
                if (child.gameObject.TryGetComponent<StaffView>(component: out var staffView))
                {
                    var staffModel = Instantiate(staffView.StaffModel);
                    var entityStaffViewModel 
                        = new StaffViewModel(staffView, staffModel).BindViewModel();
                    _localEntityController.player = (StaffViewModel)entityStaffViewModel;
                    staffView.Initialize();
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
