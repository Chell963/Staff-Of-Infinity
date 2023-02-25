using UnityEngine;

namespace Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "DefeatObjectiveData", menuName = "Objectives/DefeatObjectiveData")]
    public class DefeatObjectiveData : ObjectiveData
    {
        [field: SerializeField] public int EntitiesLeft { get; private set; }
    }
}
