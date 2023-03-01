using System.Linq;
using Abstractions;
using Implementations.Controllers;
using Types;
using UnityEngine;
using UnityEngine.UI;
using Screen = Abstractions.Screen;

namespace Implementations.Screens
{
    public class MenuLevelSelection : Screen
    {
        protected override ScreenType screenType => ScreenType.MenuLevelSelection;
        protected override SceneType sceneType => SceneType.Menu;

        [SerializeField] private Button button;

        private LevelController _localLevelController;

        public override void InjectControllers(params Controller[] controllersToInject)
        {
            base.InjectControllers(controllersToInject);
            _localLevelController
                = (LevelController)controllersToInject.ToList().Find(controller => controller is LevelController);
        }

        public override void Initialize()
        {
            button.onClick.AddListener(() =>
            {
                SwitchToGameplayCore(1);
            });
        }

        private async void SwitchToGameplayCore(int levelIndex)
        {
            await Switch(ScreenType.GameplayCore);
            _localLevelController.OpenLevel(levelIndex);
        }
    }
}
