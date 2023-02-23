using Types;
using UnityEngine;
using UnityEngine.UI;
using Screen = Implementations.Screen;

namespace Screens
{
    public class MenuEntry : Screen
    {
        protected override ScreenType screenType => ScreenType.MenuEntry;
        protected override SceneType sceneType => SceneType.Menu;

        [SerializeField] private Button switchToGameplayButton;

        public override void Initialize()
        {
            switchToGameplayButton.onClick.AddListener(SwitchToGameplay);
        }

        private async void SwitchToGameplay()
        {
            await Switch(ScreenType.GameplayCore);
        }
    }
}
