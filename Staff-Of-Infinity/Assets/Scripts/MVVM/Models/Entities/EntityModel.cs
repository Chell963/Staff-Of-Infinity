using System.Collections.Generic;
using Abstractions;
using MVVM.Views.Abilities;
using UnityEngine;

namespace MVVM.Models.Entities
{
    public abstract class EntityModel : BasicModel
    {
        [field: SerializeField] public List<AbilityView> ModelAbilities { get; private set; }
    }
}
