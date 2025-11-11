using System;
using UnityEngine;

public class RaycastWeapon : Weapon, IReloadableWeapon, IRaycastWeapon
{
    [Header("Ray")]
    [SerializeField] protected LayerMask _layerMask;
    [SerializeField, Min(0)] protected float _distance = Mathf.Infinity;
    [SerializeField, Min(0)] protected int _shotCount = 1;

    [Header("Spread")]
    [SerializeField] protected bool _useSpread;
    [SerializeField, Min(0)] protected float _spreadFactor = 1f;

    [SerializeField] private FireWeaponSO _weaponStats; 
    private int _ammoCapacity;
    private int _reloadSpeed;
    private int _currentAmmo;
    private float _triggerTime;

    public event Action AmmoOut;

    public bool HasAmmoInClip => _currentAmmo > 0;

    private void Start()
    {
        AmmoOut += Reload;
    }

    protected override void InitStats()
    {
        Name = _weaponStats.Name;
        Damage = _weaponStats.Damage;
        AttackDelay = _weaponStats.AttackDelay;
        _ammoCapacity = _weaponStats.AmmoCapacity;
        _reloadSpeed = _weaponStats.ReloadSpeed;
        _layerMask = _weaponStats.LayerMask;
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = UnityEngine.Random.Range(-_spreadFactor, _spreadFactor),
            y = UnityEngine.Random.Range(-_spreadFactor, _spreadFactor),
            z = UnityEngine.Random.Range(-_spreadFactor, _spreadFactor)
        };
    }

    private bool IsReloading()
    {
        return true;
    }

    private void SetDelay()
    {
        _triggerTime = Time.time + AttackDelay;
    }

    public void Reload()
    {
        throw new NotImplementedException();
    }

    public override void PerformAttack()
    {
        for (var i = 0; i < _shotCount; i++)
            PerformRaycastAttack();
    }

    public void PerformRaycastAttack()
    {
        TriggerAttackHappened();

        var direction = _useSpread ? transform.forward + CalculateSpread() : transform.forward;
        var ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IWeaponVisitor weaponVisitor))
                Accept(weaponVisitor, hitInfo);
        }
    }

    public void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit)
    {
        weaponVisitor?.Visit(this, hit);
    }

    private void OnDrawGizmosSelected()
    {
        var ray = new Ray(transform.position, transform.forward);

        DrawRaycast(ray);
    }

    private void DrawRaycast(Ray ray)
    {
        if (Physics.Raycast(ray, out var hitInfo, _distance, _layerMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            var hitPosition = ray.origin + ray.direction * _distance;

            DrawRay(ray, hitPosition, _distance, Color.green);
        }
    }

    private void DrawBoxCast(Ray ray)
    {
        var boxHalfExtents = transform.lossyScale / 2f;

        if (Physics.BoxCast(ray.origin, boxHalfExtents, ray.direction,
                out var hitInfo, transform.rotation, _distance, _layerMask))
        {
            DrawRay(ray, ray.origin + ray.direction * hitInfo.distance, hitInfo.distance, Color.red);
        }
        else
        {
            DrawRay(ray, ray.origin + ray.direction * _distance, _distance, Color.green);
        }
    }

    private void DrawSphereCast(Ray ray)
    {
        var sphereRadius = transform.lossyScale.x / 2f;

        if (Physics.SphereCast(ray.origin, sphereRadius, ray.direction, out var hitInfo, _distance, _layerMask))
        {
            DrawRay(ray, ray.origin + ray.direction * hitInfo.distance, hitInfo.distance, Color.red);
        }
        else
        {
            DrawRay(ray, ray.origin + ray.direction * _distance, _distance, Color.green);
        }
    }

    private void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
    }
}