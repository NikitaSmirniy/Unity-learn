using UnityEngine;

public class TargetAbilityOverlapSelector
{
    private Transform _transform;
    private float _rangeOfAction;
    private  LayerMask _layerMask;

    public TargetAbilityOverlapSelector(Transform transform, float rangeOfAction, LayerMask layerMask)
    {
        _transform = transform;
        _rangeOfAction = rangeOfAction;
        _layerMask  = layerMask;
    }

    public IDamageable SelectTarget()
    {
        if (TryGetTarget(out IDamageable result))
        {
            return result;
        }

        return null;
    }

    private bool TryGetTarget(out IDamageable damageable)
    {
        Collider2D collider = Physics2D.OverlapCircle(_transform.position, _rangeOfAction, _layerMask);

        if (collider != null && collider.TryGetComponent(out IDamageable result))
        {
            damageable = result;

            return true;
        }

        damageable = null;

        return false;
    }
}