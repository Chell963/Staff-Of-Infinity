using System.Collections.Generic;
using System.Linq;
using Abstractions;
using Implementations.Holders;
using Interfaces;
using MVVM.Models.Entities;
using MVVM.ViewModels;
using MVVM.Views;
using UnityEngine;

namespace Implementations.Controllers
{
    public class LevelController : Controller, IControllerContainer, IHolderContainer
    {
        [SerializeField] private List<LevelView> levels;
        [SerializeField] private List<PlayerModel> playerModels;
        
        private List<Controller> _controllers;
        private List<Holder> _holders;
        
        private LevelHolder _levelHolder;
        private GameplayCamera _gameplayCamera;

        private LevelViewModel _currentLevel;
        private int _currentPlayerSetupIndex = 0;

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

            var localPlayer = localEntitiesController.player.PlayerView;
            
            _gameplayCamera.InitializeCamera(instantiatedView, localPlayer);
        }

        //TODO IMPLEMENT STAFF SWITCHING
        /*public void OnSwitchPlayer(InputValue value)
        {
            var index = (int)value.Get<float>();
            if(index == 0) return;
            if(_currentLevel == null) return;
            _currentPlayerIndex += index;
            if (_currentPlayerIndex < 0)
                _currentPlayerIndex = playerModels.Count - 1;
            if (_currentPlayerIndex >= playerModels.Count)
                _currentPlayerIndex = 0;
            _currentLevel.LevelView.InitializePlayer(playerModels[_currentPlayerIndex]);
        }*/
    }
}
