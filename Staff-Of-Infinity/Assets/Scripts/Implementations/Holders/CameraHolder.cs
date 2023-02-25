using Abstractions;
using UnityEngine;

namespace Implementations.Holders
{
    [RequireComponent(typeof(Camera))]
    public class CameraHolder : Holder
    {
        [field: SerializeField] protected Camera CurrentCamera { get; private set; }
    }
}
