using UnityEngine;

namespace Data
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
