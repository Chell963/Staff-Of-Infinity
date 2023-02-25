using Interfaces;
using UnityEngine;

namespace Abstractions
{
    public abstract class BasicView : MonoBehaviour, IControllerContainer, IInitialization, IDestruction
    {
        [field:SerializeField] protected BasicModel BasicModel { get; private set; }
        
        public virtual void InjectControllers(params Controller[] controllersToInject) { }
        
        public virtual void Initialize() { }
        
        public virtual void Destruct() { }

        public void BindView(BasicModel model)
        {
            BasicModel = model;
        }
    }
}
