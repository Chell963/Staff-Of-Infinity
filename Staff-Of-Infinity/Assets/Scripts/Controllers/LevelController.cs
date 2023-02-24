using System.Collections.Generic;
using System.Linq;
using Data;
using Implementations;
using Interfaces;
using UnityEngine;

namespace Controllers
{
    public class LevelController : Controller, IInjection
    {
        [SerializeField] private List<LevelData> levels;

        private Level _currentLevel;
        
        private LevelHolder _levelHolder;
        
        private List<Controller> _controllers;
        
        public void Inject(params Controller[] controllersToInject)
        {
            _controllers = controllersToInject.ToList();
        }
        
        public void SetLevelHolder(LevelHolder levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void OpenLevel(int levelIndex)
        {
            var levelToOpen = levels.Find(level => level.Id == levelIndex).Level;
            _currentLevel = Instantiate(levelToOpen, _levelHolder.transform);
            _currentLevel.Initialize();
        }

        public async void CloseLevel()
        {
            _currentLevel.Destruct();
        }
    }
}
