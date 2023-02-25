using MVVM.Models;
using UnityEngine;

namespace MVVM.Views
{
    public class StaffView : EntityView
    {
        public StaffModel StaffModel => (StaffModel)EntityModel;
        
        [SerializeField] private SpriteRenderer staffSprite;
    }
}
