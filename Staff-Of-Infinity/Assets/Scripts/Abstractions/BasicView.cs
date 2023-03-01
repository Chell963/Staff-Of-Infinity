using Interfaces;
using UnityEngine;

namespace Abstractions
{
    public abstract class BasicView : MonoBehaviour, IControllerContainer, IInitialization, IDestruction
    {
        [field:SerializeField] protected BasicModel BasicModelReference { get; private set; }
        
        public virtual void InjectControllers(params Controller[] controllersToInject) { }
        
        public virtual void Initialize() { }
        
        public virtual void Destruct() { }
    }
}
