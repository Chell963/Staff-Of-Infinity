using Interfaces;
using UnityEngine;

namespace Abstractions
{
    public abstract class BasicModel : ScriptableObject, IControllerContainer, IInitialization, IDestruction
    {
        [field: SerializeField] public int Id { get; private set; }

        protected BasicView BasicView;
        
        public virtual void InjectControllers(params Controller[] controllersToInject) { }
        
        public virtual void Initialize() { }
        
        public virtual void Destruct() { }

        public void BindModel(BasicView view)
        {
            BasicView = view;
        }
    }
}
