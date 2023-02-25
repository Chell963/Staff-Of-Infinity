using System.Collections.Generic;
using System.Linq;
using Abstractions;
using Implementations.Holders;
using Interfaces;
using MVVM.ViewModels;
using MVVM.Views;
using UnityEngine;

namespace Implementations.Controllers
{
    public class LevelController : Controller, IControllerContainer, IHolderContainer
    {
        [SerializeField] private List<LevelView> levels;
        
        private List<Controller> _controllers;
        private List<Holder> _holders;
        
        private LevelHolder _levelHolder;
        private GameplayCamera _gameplayCamera;

        private LevelViewModel _currentLevel;

        public void InjectControllers(params Controller[] controllersToInject)
        {
            _controllers = controllersToInject.ToList();
        }

        public void InjectHolders(params Holder[] holdersToInject)
        {
            _holders = holdersToInject.ToList();
            _levelHolder = (LevelHolder)_holders.Find(holder => holder is LevelHolder);
            _gameplayCamera = (GameplayCamera)_holders.Find(holder => holder is GameplayCamera);
        }

        public void OpenLevel(int levelIndex)
        {
            var levelToOpen = levels.Find(level => level.LevelId == levelIndex);
            var instantiatedView = Instantiate(levelToOpen, _levelHolder.transform);
            var instantiatedModel = Instantiate(levelToOpen.LevelModel);
            
            var localEntitiesController
                = (EntityController)_controllers.ToList().Find(controller => controller is EntityController);

            instantiatedView.InjectControllers(localEntitiesController);
            instantiatedModel.InjectControllers();
            var entityLevelViewModel
                = new LevelViewModel(instantiatedView, instantiatedModel).BindViewModel();
            _currentLevel = (LevelViewModel)entityLevelViewModel;
            instantiatedView.Initialize();
            instantiatedModel.Initialize();

            var localPlayer = localEntitiesController.player.StaffView;
            
            _gameplayCamera.InitializeCamera(instantiatedView, localPlayer);
        }
    }
}
