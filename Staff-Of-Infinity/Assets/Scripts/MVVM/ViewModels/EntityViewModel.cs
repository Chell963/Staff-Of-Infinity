using Abstractions;
using MVVM.Models;
using MVVM.Views;

namespace MVVM.ViewModels
{
    public class EntityViewModel : BasicViewModel
    {
        protected EntityView EntityView => (EntityView)BasicView;
        protected EntityModel EntityModel => (EntityModel)BasicModel;
        public override BasicViewModel BindViewModel()
        {
            var view = (EntityView)BasicView;
            var model = (EntityModel)BasicModel;
            return this;
        }
        
        protected EntityViewModel(EntityView basicView, EntityModel basicModel) : base(basicView, basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }
    }
}
