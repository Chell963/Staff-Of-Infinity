using Abstractions;
using MVVM.ViewModels;
using UnityEngine;

namespace Implementations.Controllers
{
    public class EntityController : Controller
    {
        [HideInInspector] public StaffViewModel player;
    }
}
