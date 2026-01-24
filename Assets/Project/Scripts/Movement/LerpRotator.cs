using UnityEngine;

public class LerpRotator
{
    private float _maxRotationZoneZ;
    private float _minRotationZoneZ;
    private float _rotationSpeed;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    public LerpRotator(float maxRotationZoneZ, float minRotationZoneZ,  float rotationSpeed)
    {
        _maxRotationZoneZ = maxRotationZoneZ;
        _minRotationZoneZ = minRotationZoneZ;
        _rotationSpeed =  rotationSpeed;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZoneZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZoneZ);
    }

    public void RotateToMaxPosition(Transform transform)
    {
        transform.rotation = _maxRotation;
    }
    
    public void RotateToMinPosition(Transform transform)
    {
         transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}