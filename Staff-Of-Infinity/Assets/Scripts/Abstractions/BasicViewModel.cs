using System;
using Interfaces;

namespace Abstractions
{
    [Serializable]
    public abstract class BasicViewModel : IDestruction
    {
        protected BasicView  BasicView;
        protected BasicModel BasicModel;

        public virtual BasicViewModel BindViewModel()
        {
            return this;
        }
        
        public virtual void Destruct() { }
        
        protected BasicViewModel(BasicView basicView, BasicModel basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }

        
    }
}
