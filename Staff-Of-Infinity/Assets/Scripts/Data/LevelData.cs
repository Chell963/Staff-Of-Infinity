using System.Collections.Generic;
using Implementations;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Levels/LevelData")]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public int Stars { get; private set; }
        [field: SerializeField] public Level Level { get; private set; }
        [field: SerializeField] public List<ObjectiveData> Objectives { get; private set; }
    }
}
