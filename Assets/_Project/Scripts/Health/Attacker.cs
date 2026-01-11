using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;

    public void Init(LayerMask layerMask, Transform attackPoint, float damage, float attackRange)
    {
        _layerMask = layerMask;
        _attackPoint = attackPoint;
        _damage = damage;
        _attackRange = attackRange;
    }

    private void PerformAttack()
    {
        var collider = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _layerMask);

        if (collider != null && collider.TryGetComponent(out IDamageable resource))
        {
            resource.TakeDamage(_damage);
        }
    }
}