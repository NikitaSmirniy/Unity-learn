public class EnemyHealth : HealthMonoBase, IDamageable
{
    public void TakeDamage(float amount)
    {
        Health.Spend(amount);
    }
}