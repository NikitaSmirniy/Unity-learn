using UnityEngine;

public abstract class HitBox : MonoBehaviour, IWeaponVisitor
{
    [SerializeField] protected Collider _hitBox;

    public void Visit(ColdWeapon coldWeapon)
    {
        DefaultOverlapVisit(coldWeapon);
    }

    public void Visit(RaycastWeapon fireWeapon, RaycastHit hit)
    {
        DefaultRaycastVisit(fireWeapon, hit);
    }

    public abstract void DefaultOverlapVisit(ColdWeapon coldWeapon);

    public abstract void DefaultRaycastVisit(RaycastWeapon fireWeapon, RaycastHit hit);
}