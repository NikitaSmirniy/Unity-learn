using UnityEngine;

public class UnitHitBox : HitBox
{
    [SerializeField] private Unit _unit;

    public override void DefaultOverlapVisit(ColdWeapon coldWeapon)
    {
        _unit.DamageResiver.Apply(coldWeapon.Damage);
    }

    public override void DefaultRaycastVisit(RaycastWeapon fireWeapon, RaycastHit hit)
    {
        _unit.DamageResiver.Apply(fireWeapon.Damage);
    }
}