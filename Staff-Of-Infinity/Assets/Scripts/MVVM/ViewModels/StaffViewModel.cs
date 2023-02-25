using System;
using Abstractions;
using MVVM.Models;
using MVVM.Views;

namespace MVVM.ViewModels
{
    [Serializable]
    public class StaffViewModel : EntityViewModel
    {
        public StaffView StaffView => (StaffView)EntityView;
        public StaffModel StaffModel => (StaffModel)EntityModel;
        public override BasicViewModel BindViewModel()
        {
            var view = (StaffView)EntityView;
            var model = (StaffModel)EntityModel;
            return this;
        }
        
        public StaffViewModel(StaffView basicView, StaffModel basicModel) : base(basicView, basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }
    }
}
