using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour, ISoundPublisher
{
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private bool _isWorking;
    [SerializeField] private float _duration;

    private BulletSpawner _bulletSpawner;
    private Vector2 _direction;
    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    public event Action<AudioClip> SoundPlayed;

    private void Awake()
    {
        _wait = new WaitForSeconds(_duration);
    }

    public void Init(BulletSpawner bulletSpawner, Vector2 direction)
    {
        _bulletSpawner = bulletSpawner;
        _direction = direction;
    }

    public void Reset()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void StartShootRoutine()
    {
        if (_bulletSpawner != null && _coroutine == null)
            _coroutine = StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        while (_isWorking)
        {
            yield return _wait;

            _bulletSpawner.Spawn(_muzzlePoint.position, _direction);
            SoundPlayed?.Invoke(_weaponData.AudioClip);
        }
    }
}