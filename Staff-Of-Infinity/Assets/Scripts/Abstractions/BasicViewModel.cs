using System;

namespace Abstractions
{
    [Serializable]
    public abstract class BasicViewModel
    {
        protected BasicView  BasicView;
        protected BasicModel BasicModel;

        public virtual BasicViewModel BindViewModel()
        {
            BasicView.BindView(BasicModel);
            BasicModel.BindModel(BasicView);
            return this;
        }

        protected BasicViewModel(BasicView basicView, BasicModel basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }
    }
}
