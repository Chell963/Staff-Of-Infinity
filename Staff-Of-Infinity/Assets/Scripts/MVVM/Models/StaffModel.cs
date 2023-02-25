using UnityEngine;

namespace MVVM.Models
{
    [CreateAssetMenu(fileName = "StaffModel", menuName = "Models/Entities/StaffModel")]
    public class StaffModel : EntityModel
    {
        [field: SerializeField] public string StaffName { get; private set; }
        [field: SerializeField] public Sprite StaffSprite { get; private set; }
    }
}
