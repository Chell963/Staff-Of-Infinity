using Abstractions;

namespace Interfaces
{
    public interface IControllerContainer
    {
        public void InjectControllers(params Controller[] controllersToInject);
    }
}
