using Types;
using UnityEngine;
using UnityEngine.UI;
using Screen = Abstractions.Screen;

namespace Implementations.Screens
{
    public class MenuEntry : Screen
    {
        protected override ScreenType screenType => ScreenType.MenuEntry;
        protected override SceneType sceneType => SceneType.Menu;

        [SerializeField] private Button switchToGameplayButton;

        public override void Initialize()
        {
            switchToGameplayButton.onClick.AddListener(SwitchToLevelSelection);
        }

        private async void SwitchToLevelSelection()
        {
            await Switch(ScreenType.MenuLevelSelection);
        }
    }
}
