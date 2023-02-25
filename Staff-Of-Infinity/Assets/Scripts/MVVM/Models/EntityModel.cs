using Abstractions;
using UnityEngine;

namespace MVVM.Models
{
    public abstract class EntityModel : BasicModel
    {
        [SerializeField] private int health;
    }
}
