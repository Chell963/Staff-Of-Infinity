using Abstractions;
using MVVM.Models;

namespace MVVM.Views
{
    public class EntityView : BasicView
    {
        protected EntityModel EntityModel => (EntityModel)BasicModel;
    }
}
