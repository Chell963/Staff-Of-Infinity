using System.Collections.Generic;
using Abstractions;
using Data.ScriptableObjects;
using Unity.Collections;
using UnityEngine;

namespace MVVM.Models
{
    [CreateAssetMenu(fileName = "LevelModel", menuName = "Models/Levels/LevelModel")]
    public class LevelModel : BasicModel
    {
        [ReadOnly] [SerializeField] private int stars;
        [SerializeField] private List<ObjectiveData> objectives;
        [ReadOnly] [SerializeField] private bool isCompleted;

        public void CompleteLevel()
        {
            isCompleted = true;
        }
    }
}
