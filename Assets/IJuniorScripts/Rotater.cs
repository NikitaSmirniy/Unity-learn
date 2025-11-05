using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.RotateAround(transform.position, Vector3.up, _speed * Time.deltaTime);
        transform.Rotate(Vector3.up, _speed * Time.deltaTime);
    }
}