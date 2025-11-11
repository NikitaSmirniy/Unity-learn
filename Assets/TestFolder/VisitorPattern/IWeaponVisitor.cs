using UnityEngine;

public interface IWeaponVisitor 
{
    void Visit(ColdWeapon coldWeapon);
    void Visit(RaycastWeapon fireWeapon, RaycastHit hit);
}