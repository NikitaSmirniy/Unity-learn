using UnityEngine;

public class VampireAbilityAction
{
    private float _damage;
    private float _heal;

    private IHealable _healable;

    public VampireAbilityAction(AbilityActionData abilityActionData, IHealable healable)
    {
        _damage = abilityActionData.DamagePerSecond;
        _heal = abilityActionData.HealPerSecond;

        _healable = healable;
    }

    public void Action(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.TakeDamage(_damage * Time.deltaTime);
            _healable.Cure(_heal * Time.deltaTime);
        }
    }
}