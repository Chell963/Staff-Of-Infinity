using Interfaces;
using UnityEngine;

namespace Abstractions
{
    public abstract class BasicModel : ScriptableObject, IControllerContainer, IInitialization, IDestruction
    {
        [field: SerializeField] public int Id { get; private set; }

        public virtual void InjectControllers(params Controller[] controllersToInject) { }
        
        public virtual void Initialize() { }
        
        public virtual void Destruct() { }
    }
}
