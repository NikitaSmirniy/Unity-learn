public class PlayerHealth : HealthMonoBase, IDamageable, IHealable
{
    public void TakeDamage(float amount)
    {
        Health.Spend(amount);
    }

    public void Cure(float amount)
    {
        Health.Add(amount);
    }
}