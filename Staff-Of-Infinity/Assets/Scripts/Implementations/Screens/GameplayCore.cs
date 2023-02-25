using Types;
using Screen = Abstractions.Screen;

namespace Implementations.Screens
{
    public class GameplayCore : Screen
    {
        protected override ScreenType screenType => ScreenType.GameplayCore;
        protected override SceneType sceneType => SceneType.Gameplay;
    }
}
