using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DefeatObjectiveData", menuName = "Objectives/DefeatObjectiveData")]
    public class DefeatObjectiveData : ObjectiveData
    {
        [field: SerializeField] public int EntitiesLeft { get; private set; }
    }
}
