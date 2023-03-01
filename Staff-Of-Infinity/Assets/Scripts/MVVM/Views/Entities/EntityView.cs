using System;
using System.Collections.Generic;
using Abstractions;
using MVVM.Models.Entities;
using MVVM.ViewModels.Abilities;
using MVVM.Views.Abilities;
using UnityEngine;

namespace MVVM.Views.Entities
{
    public class EntityView : BasicView
    {
        [field: SerializeField] public Rigidbody2D EntityBody { get; private set; }
        [field: SerializeField] public Collider2D  EntityCollider { get; private set; }
        
        protected EntityModel EntityModelReference => (EntityModel)BasicModelReference;

        [SerializeField] protected GameObject  abilitiesParent;

        protected readonly List<AbilityView> ViewAbilities = new List<AbilityView>();

        public T InitializeAbility<T>(AbilityView ability) where T : AbilityViewModel
        {
            var abilityView = Instantiate(ability, abilitiesParent.transform);
            abilityView.SetOwner(this);
            ViewAbilities.Add(abilityView);
            var abilityModel = Instantiate(abilityView.AbilityModelReference);
            var abilityViewModel = ((T)Activator.CreateInstance(typeof(T), abilityView, abilityModel)).BindViewModel();
            return (T)abilityViewModel;
        }
    }
}
