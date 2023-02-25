using Abstractions;

namespace Interfaces
{
    public interface IHolderContainer
    {
        public void InjectHolders(params Holder[] holdersToInject);
    }
}
