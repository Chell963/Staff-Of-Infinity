using Types;

namespace Interfaces
{
    public interface IScreen
    {
        ScreenType ScreenType { get; }
        SceneType SceneType { get; }
    }
}
