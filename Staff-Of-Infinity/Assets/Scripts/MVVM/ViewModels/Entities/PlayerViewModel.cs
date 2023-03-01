using System;
using Abstractions;
using MVVM.Models.Entities;
using MVVM.Views.Entities;

namespace MVVM.ViewModels.Entities
{
    [Serializable]
    public class PlayerViewModel : EntityViewModel
    {
        public PlayerView PlayerView => (PlayerView)EntityView;
        public PlayerModel PlayerModel => (PlayerModel)EntityModel;
        
        public override BasicViewModel BindViewModel()
        {
            base.BindViewModel();
            return this;
        }

        public PlayerViewModel(PlayerView basicView, PlayerModel basicModel) : base(basicView, basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }
    }
}
