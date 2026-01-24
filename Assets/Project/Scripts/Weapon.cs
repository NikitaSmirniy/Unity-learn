using System;
using UnityEngine;

public class Weapon : MonoBehaviour, ISoundPublisher
{
    [SerializeField] private WeaponData _weaponData;
    
    [field: SerializeField] public Transform MuzzlePoint;

    private BulletSpawner _bulletSpawner;
    private Vector2 _direction;

    public event Action<AudioClip> SoundPlayed;

    public void Init(BulletSpawner bulletSpawner, Vector2 direction)
    {
        _bulletSpawner = bulletSpawner;
        _direction = direction;
    }

    public void Shoot()
    {
        if (_bulletSpawner != null)
        {
            _bulletSpawner.Spawn(MuzzlePoint.position, _direction);
            SoundPlayed?.Invoke(_weaponData.AudioClip);
        }
    }

    public void SetDirection(Vector2 direction) =>
        _direction = direction;
}