using Abstractions;
using MVVM.ViewModels.Entities;
using UnityEngine;

namespace Implementations.Controllers
{
    public class EntityController : Controller
    {
        [HideInInspector] public PlayerViewModel player;
    }
}
