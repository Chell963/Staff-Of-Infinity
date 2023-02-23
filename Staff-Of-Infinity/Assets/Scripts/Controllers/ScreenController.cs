using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Implementations;
using Interfaces;
using Types;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Utils.Extensions;
using Screen = Implementations.Screen;

namespace Controllers
{
    [Serializable]
    public struct ScreenValue
    {
        [field: SerializeField] public AssetReference ScreenReference { get; private set; }
        [field: SerializeField] public SceneType SceneType { get; private set; }
        [field: SerializeField] public ScreenType ScreenType { get; private set; }
        [field: SerializeField] public bool IsStartingScreen { get; private set; }
        [field: SerializeField] public bool CanBeOpenedTwice { get; private set; }
    }
    public class ScreenController : Controller, IInjection, IInitialization
    {
        [SerializeField] private List<ScreenValue> screenValues;
        
        private readonly List<SceneType> _loadedScenes     = new();
        private readonly List<Screen>    _availableScreens = new();
        private readonly List<Screen>    _openedScreens    = new();

        private Screen       _lastOpenedScreen;

        private ScreenHolder _screenHolder;

        private List<Controller> _controllers;

        public void Inject(params Controller[] controllersToInject)
        {
            _controllers = controllersToInject.ToList();
        }
        
        public void SetScreenHolder(ScreenHolder screenHolder)
        {
            _screenHolder = screenHolder;
        }
        
        public async Task<Screen> OpenScreen(ScreenType screenType)
        {
            var screen = screenValues.Find(screen => screen.ScreenType == screenType);
            return await HandleScreen(screen);
        }
        
        public async void CloseScreen(ScreenValue screenValue = new())
        {
            //if screen was selected - close it, else - close last opened
            var closeLastOpened = screenValue.ScreenType == ScreenType.None;
            var screenToClose = closeLastOpened ? _openedScreens[^1] : GetOpenedScreen(screenValue);
            if (screenToClose == null && closeLastOpened)
            {
                Debug.LogError("Closing screen null reference!");
            }
            var screenToCloseValue = screenValue;
            _openedScreens.Remove(screenToClose);
            if (screenToCloseValue.CanBeOpenedTwice)
            {
                if (!closeLastOpened)
                {
                    _lastOpenedScreen = screenToClose;
                }
                screenToClose.Close();
            }
            else
            {
                _availableScreens.Remove(screenToClose);
                Destroy(screenToClose.gameObject);
            }
            if (closeLastOpened)
            {
                if (_lastOpenedScreen == null)
                {
                    Debug.LogError("Check last opened screen reference!");
                }
                await OpenScreen(_lastOpenedScreen.ScreenType);
            }
        }
        
        private async Task<Screen> HandleScreen(ScreenValue screenValue)
        {
            var selectedScene = GetSceneType(screenValue);
            Debug.Log($"{"[ScreenController]".ApplyColorTag("blue")} Try to open {screenValue.ScreenType}");
            if (_loadedScenes.Count == 0)
            {
                _loadedScenes.Add(selectedScene);
            }
            if (!IsSceneAvailable(screenValue))
            {
                var loadingOperation = SceneManager.LoadSceneAsync((int)selectedScene, LoadSceneMode.Additive);
                while (loadingOperation.isDone == false)
                {
                    await Task.Yield();
                }
                _loadedScenes.Add(selectedScene);
            }
            foreach (var screen in _openedScreens.Where(screen => screen.SceneType != selectedScene).ToList())
            {
                var screenToClose = 
                    screenValues.Find(screenToClose => screen.ScreenType == screenToClose.ScreenType);
                CloseScreen(screenToClose);
            }
            if (_loadedScenes.Count > 1)
            {
                var sceneToUnload = _loadedScenes.First(scene => scene != selectedScene);
                var unloadingOperation = SceneManager.UnloadSceneAsync((int)sceneToUnload);
                while (unloadingOperation.isDone == false)
                {
                    await Task.Yield();
                }
                _loadedScenes.Remove(sceneToUnload);
            }
            foreach (var screen in _availableScreens.Where(screen => screen.SceneType != selectedScene).ToList())
            {
                _availableScreens.Remove(screen);
            }
            var isScreenAvailable = IsScreenAvailable(screenValue);
            var screenToShow = isScreenAvailable
                ? GetAvailableScreen(screenValue)
                : await AssetController.LoadAssetAsync<Screen>
                    (screenValue.ScreenReference, _screenHolder.transform);
            if (!isScreenAvailable)
            {
                _availableScreens.Add(screenToShow);
            }
            screenToShow.Inject(_controllers.ToArray());
            screenToShow.Show();
            _openedScreens.Add(screenToShow);
            return screenToShow;
        }
        
        private void CloseAllScreens(SceneType sceneType)
        {
            foreach (var screen in _openedScreens.Where(screen => screen.SceneType == sceneType).ToList())
            {
                var screenToClose = 
                    screenValues.Find(screenConfig => screen.ScreenType == screenConfig.ScreenType);
                CloseScreen(screenToClose);
            }
        }

        private SceneType GetSceneType(ScreenValue screenValue) =>
            screenValue.SceneType;

        private bool IsScreenAvailable(ScreenValue screenValue) =>
            _availableScreens.Find(screen => screen.ScreenType == screenValue.ScreenType);
        
        private bool IsSceneAvailable(ScreenValue screenValue) =>
            (int)screenValue.SceneType == SceneManager.GetActiveScene().buildIndex;
        private Screen GetAvailableScreen(ScreenValue sceneValue) =>
            _availableScreens.Find(screen => screen.ScreenType == sceneValue.ScreenType);
        
        private Screen GetOpenedScreen(ScreenValue sceneValue) =>
            _openedScreens.Find(screen => screen.ScreenType == sceneValue.ScreenType);

        public async void Initialize()
        {
            var sceneIndex = SceneManager.GetActiveScene().buildIndex;
            var startingScreen = screenValues.Find(screen => 
                screen.IsStartingScreen && (int)screen.SceneType == sceneIndex);
            await OpenScreen(startingScreen.ScreenType);
        }
    }
}
