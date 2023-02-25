using Abstractions;
using MVVM.Models;
using MVVM.Views;

namespace MVVM.ViewModels
{
    public class LevelViewModel : BasicViewModel
    {
        public LevelView LevelView => (LevelView)BasicView;
        public LevelModel LevelModel => (LevelModel)BasicModel;
        
        public LevelViewModel(LevelView basicView, LevelModel basicModel) : base(basicView, basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }

        public override BasicViewModel BindViewModel()
        {
            var view = (LevelView)BasicView;
            var model = (LevelModel)BasicModel;
            view.OnLevelCompleted += model.CompleteLevel;
            return this;
        }
    }
}
