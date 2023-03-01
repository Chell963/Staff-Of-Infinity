namespace MVVM.Views.Abilities
{
    public class HealthAbilityView : AbilityView
    {
        public void Death()
        {
            Destroy(Owner);
        }
    }
}
