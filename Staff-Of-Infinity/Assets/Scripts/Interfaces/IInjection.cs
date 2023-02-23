using Implementations;

namespace Interfaces
{
    public interface IInjection
    {
        public void Inject(params Controller[] controllersToInject);
    }
}
