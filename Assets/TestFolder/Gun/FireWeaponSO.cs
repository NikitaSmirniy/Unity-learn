using UnityEngine;

[CreateAssetMenu(menuName = "New Fire Weapon SO", fileName = "New Fire Weapon")]
public class FireWeaponSO : WeaponScriptableObject
{
    [SerializeField, Min(0)] private int _ammoCapacity;
    [SerializeField, Min(0)] private int _reloadSpeed;

    public int AmmoCapacity => _ammoCapacity;
    public int ReloadSpeed => _reloadSpeed;
}