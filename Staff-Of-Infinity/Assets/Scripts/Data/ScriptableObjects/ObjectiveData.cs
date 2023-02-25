using UnityEngine;

namespace Data.ScriptableObjects
{
    public class ObjectiveData : ScriptableObject
    {
        private bool _isCompleted;

        public void CompleteObjective()
        {
            _isCompleted = true;
        }
    }
}
