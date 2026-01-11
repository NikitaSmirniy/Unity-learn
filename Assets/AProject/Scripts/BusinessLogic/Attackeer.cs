public class Attackeer
{
    private int _damage;
    private IDamageable _damageable;

    public Attackeer(int damage,  IDamageable damageable)
    {
        _damage = damage;
        _damageable  = damageable;
    }
    
    public void Attack()
    {
        _damageable.TakeDamage(_damage);
    }
}