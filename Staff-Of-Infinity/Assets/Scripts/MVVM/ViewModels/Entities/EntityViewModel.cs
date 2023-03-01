using System.Collections.Generic;
using Abstractions;
using Interfaces;
using MVVM.Models.Entities;
using MVVM.ViewModels.Abilities;
using MVVM.Views.Entities;

namespace MVVM.ViewModels.Entities
{
    public class EntityViewModel : BasicViewModel, IDestruction
    {
        protected EntityView EntityView => (EntityView)BasicView;
        protected EntityModel EntityModel => (EntityModel)BasicModel;

        protected readonly List<AbilityViewModel> Abilities = new List<AbilityViewModel>();

        public override BasicViewModel BindViewModel()
        {
            base.BindViewModel();
            foreach (var abilityToInitialize in EntityModel.ModelAbilities)
            {
                var newAbility = EntityView.InitializeAbility<AbilityViewModel>(abilityToInitialize);
                Abilities.Add(newAbility);
            }
            return this;
        }
        
        public override void Destruct() { }

        protected List<T> TryGetAbilities<T>() where T : AbilityViewModel
        {
            var abilityList = new List<T>();
            foreach (var ability in Abilities)
            {
                if (ability is T movementAbility)
                {
                    abilityList.Add(movementAbility);
                }
            }
            return abilityList;
        }

        protected EntityViewModel(EntityView basicView, EntityModel basicModel) : base(basicView, basicModel)
        {
            BasicView = basicView;
            BasicModel = basicModel;
        }
    }
}
