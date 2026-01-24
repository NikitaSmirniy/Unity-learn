using UnityEngine;

public class PlayerCreator
{
    private Bird _bird;
    private BulletSpawner _bulletPlayerSpawner;
    private Transform _birdSpawnPoint;
    private float _maxRotationZoneZ;
    private float _minRotationZoneZ;
    private float _rotateSpeed;

    public PlayerCreator(Bird bird,  BulletSpawner bulletPlayerSpawner, Transform birdSpawnPoint,  float maxRotationZoneZ, float minRotationZoneZ, float rotateSpeed)
    {
        _bird = bird;
        _bulletPlayerSpawner = bulletPlayerSpawner;
        _birdSpawnPoint = birdSpawnPoint;
        _maxRotationZoneZ = maxRotationZoneZ;
        _minRotationZoneZ = minRotationZoneZ;
        _rotateSpeed = rotateSpeed;
    }

    public Bird Create()
    {
        var bird = Object.Instantiate(_bird, _birdSpawnPoint);
        LerpRotator lerpRotator = new LerpRotator(_maxRotationZoneZ, _minRotationZoneZ, _rotateSpeed);

        bird.Init(lerpRotator, _bulletPlayerSpawner);

        return bird;
    }
}