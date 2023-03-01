using UnityEngine;

namespace MVVM.Models.Entities
{
    [CreateAssetMenu(fileName = "StaffModel", menuName = "Models/Entities/StaffModel")]
    public class PlayerModel : EntityModel
    {
        [field: SerializeField] public string StaffName { get; private set; }
        [field: SerializeField] public Sprite StaffSprite { get; private set; }
    }
}
