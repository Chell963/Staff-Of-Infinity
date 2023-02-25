using System.Collections.Generic;
using Abstractions;
using UnityEngine;
using Utils.Extensions;

namespace Implementations.Controllers
{
    public class ControllerInjector : MonoBehaviour
    {
        [SerializeField] private AppController injection;
        [SerializeField] private List<Holder> holders;

        private void Awake()
        {
            if (AppController.I == null)
            {
                Instantiate(injection);
            }
            else
            {
                Debug.Log("AppController is already initialized!".ApplyColorTag("yellow"));
            }
            AppController.I.InjectHolders(holders.ToArray());
            Destroy(gameObject);
        }
    }
}
