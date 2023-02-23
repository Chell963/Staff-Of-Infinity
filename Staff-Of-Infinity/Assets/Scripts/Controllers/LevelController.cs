using System.Collections.Generic;
using System.Linq;
using Implementations;
using Interfaces;

namespace Controllers
{
    public class LevelController : Controller, IInjection
    {
        private LevelHolder _levelHolder;
        
        private List<Controller> _controllers;
        
        public void Inject(params Controller[] controllersToInject)
        {
            _controllers = controllersToInject.ToList();
        }
        
        public void SetLevelHolder(LevelHolder levelHolder)
        {
            _levelHolder = levelHolder;
        }
    }
}
