using Interfaces;
using UnityEngine;

namespace Implementations
{
    public class Level : MonoBehaviour, IInitialization, IDestruction
    {
        public void Initialize()
        {
            
        }

        public void Destruct()
        {
            Destroy(gameObject);
        }
    }
}
