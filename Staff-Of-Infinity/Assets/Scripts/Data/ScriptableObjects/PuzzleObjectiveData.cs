using Types;
using UnityEngine;

namespace Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PuzzleObjectiveData", menuName = "Objectives/PuzzleObjectiveData")]
    public class PuzzleObjectiveData : ObjectiveData
    {
        [field: SerializeField] public PuzzleType PuzzleType { get; private set; }
        [field: SerializeField] public int StepsLeft { get; private set; }
    }
}
