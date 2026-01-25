using System;
using UnityEngine;

public class Weapon : MonoBehaviour, ISoundPublisher
{
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private Transform _muzzlePoint;

    private BulletSpawner _bulletSpawner;
    private Vector2 _shootDirection;

    public event Action<AudioClip> SoundPlayed;

    public void Init(BulletSpawner bulletSpawner, Vector2 direction)
    {
        _bulletSpawner = bulletSpawner;
        SetShootDirection(direction);
    }

    public void SetShootDirection(Vector2 direction) =>
        _shootDirection = direction;
    
    public void Shoot()
    {
        if (_bulletSpawner != null)
        {
            _bulletSpawner.Spawn(_muzzlePoint.position, _shootDirection);
            SoundPlayed?.Invoke(_weaponData.AudioClip);
        }
    }
}