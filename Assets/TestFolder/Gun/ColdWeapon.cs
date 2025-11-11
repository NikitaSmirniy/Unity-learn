using UnityEngine;

public class ColdWeapon : Weapon
{
    [SerializeField] private ColdWeapon _weaponStats;

    public override void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    protected override void InitStats()
    {
        Name = _weaponStats.Name;
        Damage = _weaponStats.Damage;
        AttackDelay = _weaponStats.AttackDelay;
    }
}