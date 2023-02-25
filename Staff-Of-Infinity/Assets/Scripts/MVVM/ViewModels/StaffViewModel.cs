using System;
using Abstractions;
using Interfaces;
using MVVM.Models;
using MVVM.Views;

namespace MVVM.ViewModels
{
    [Serializable]
    public class StaffViewModel : EntityViewModel, IDestruction
    {
        public StaffView StaffView => (StaffView)EntityView;
        public StaffModel StaffModel => (StaffModel)EntityModel;
        public override BasicViewModel BindViewModel()
        {
            var view = (StaffView)EntityView;
            var model = (StaffModel)EntityModel;
            view.OnMoved += model.ChangeSpeed;
            view.OnMovementStateChanged += model.ChangeMovementState;
            return this;
        }
        
        public StaffViewModel(StaffView basicView, StaffModel basicModel) : base(basicView, basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }

        public void Destruct()
        {
            var view = (StaffView)EntityView;
            var model = (StaffModel)EntityModel;
            view.OnMoved -= model.ChangeSpeed;
            view.OnMovementStateChanged -= model.ChangeMovementState;
        }
    }
}
