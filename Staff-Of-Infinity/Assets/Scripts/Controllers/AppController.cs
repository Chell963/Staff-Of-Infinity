using System.Collections.Generic;
using System.Linq;
using Implementations;
using Interfaces;
using UnityEngine;
using Utils.Extensions;

namespace Controllers
{
    public class AppController : Controller
    {
        public static AppController I { get; private set; }

        [SerializeField] private List<Controller> controllers;
        
        public void InjectHolders(List<Holder> holders)
        {
            var screenController =
                (ScreenController)controllers.ToList().Find(controller => controller is ScreenController);
            var levelController = 
                (LevelController)controllers.ToList().Find(controller => controller is LevelController);
            var screenHolder = (ScreenHolder)holders.Find(holder => holder is ScreenHolder);
            var levelHolder = (LevelHolder)holders.Find(holder => holder is LevelHolder);
            if(screenHolder != null)
                screenController.SetScreenHolder(screenHolder);
            if(levelHolder != null)
                levelController.SetLevelHolder(levelHolder);
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

        private void StaticInject()
        {
            foreach (var controller in controllers)
            {
                if (controller is IInjection injection)
                {
                    injection.Inject(controllers.ToArray());
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
    }
}
