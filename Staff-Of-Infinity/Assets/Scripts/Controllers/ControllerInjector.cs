using System.Collections.Generic;
using Implementations;
using UnityEngine;
using Utils.Extensions;

namespace Controllers
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
            AppController.I.InjectHolders(holders);
            Destroy(gameObject);
        }
    }
}
