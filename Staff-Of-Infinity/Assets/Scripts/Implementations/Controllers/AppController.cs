using System.Collections.Generic;
using System.Linq;
using Abstractions;
using Implementations.Holders;
using Interfaces;
using UnityEngine;
using Utils.Extensions;

namespace Implementations.Controllers
{
    public class AppController : Controller, IHolderContainer
    {
        public static AppController I { get; private set; }

        [SerializeField] private List<Controller> controllers;
        
        public void InjectHolders(params Holder[] holdersToInject)
        {
            foreach (var controller in controllers)
            {
                if (controller is IHolderContainer holderContainer)
                {
                    holderContainer.InjectHolders(holdersToInject);
                }
            }
        }

        private void StaticInject()
        {
            foreach (var controller in controllers)
            {
                if (controller is IControllerContainer controllerContainer)
                {
                    controllerContainer.InjectControllers(controllers.ToArray());
                }
            }
        }

        private void StaticInitialize()
        {
            foreach (var controller in controllers)
            {
                if (controller is IInitialization initialization)
                {
                    initialization.Initialize();
                }
            }
        }
        
        private void Awake()
        {
            if (I == null)
            {
                I = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning($"Destroyed duplicated AppController name = {name}!".ApplyColorTag("red"));
                Destroy(gameObject);
            }
            StaticInject();
        }

        private void Start()
        {
            StaticInitialize();
        }
    }
}
