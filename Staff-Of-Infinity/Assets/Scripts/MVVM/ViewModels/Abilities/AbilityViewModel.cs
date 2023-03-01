using Abstractions;
using MVVM.Models.Abilities;
using MVVM.Views.Abilities;

namespace MVVM.ViewModels.Abilities
{
    public class AbilityViewModel : BasicViewModel
    {
        private AbilityView AbilityView => (AbilityView)BasicView;
        private AbilityModel AbilityModel => (AbilityModel)BasicModel;
        
        public override BasicViewModel BindViewModel()
        {
            AbilityView.OnAbilityStateChanged += AbilityModel.ChangeAbilityState;
            AbilityView.OnAbilityValueChanged += AbilityModel.ChangeAbilityValue;
            return this;
        }

        public override void Destruct()
        {
            AbilityView.OnAbilityStateChanged -= AbilityModel.ChangeAbilityState;
            AbilityView.OnAbilityValueChanged -= AbilityModel.ChangeAbilityValue;
        }

        public AbilityViewModel(AbilityView basicView, AbilityModel basicModel) : base(basicView, basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }
    }
}
