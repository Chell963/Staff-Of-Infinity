using System.Linq;
using System.Threading.Tasks;
using Controllers;
using Interfaces;
using Types;
using UnityEngine;

namespace Implementations
{
    public abstract class Screen : MonoBehaviour, IScreen, IInjection, IInitialization, IDestruction
    {
        public ScreenType ScreenType => screenType;
        public SceneType SceneType => sceneType;
        
        protected abstract ScreenType screenType { get; }
        protected abstract SceneType sceneType { get; }

        private ScreenController _localScreenController;

        public virtual void Inject(params Controller[] controllersToInject)
        {
            _localScreenController =
                (ScreenController)controllersToInject.ToList().Find(controller => controller is ScreenController);
        }

        public virtual void Initialize() { }

        public virtual void Destruct() { }

        public void Show()
        {
            transform.SetAsLastSibling();
            gameObject.SetActive(true);
            Initialize();
        }
        
        public void Close()
        {
            Destruct();
            gameObject.SetActive(false);
        }
        
        protected async Task Switch(ScreenType switchScreenType)
        {
            await _localScreenController.OpenScreen(switchScreenType);
        }
    }
}
