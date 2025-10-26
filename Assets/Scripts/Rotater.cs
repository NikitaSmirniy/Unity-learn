using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Vector3 Offset { get ; set; }

    private void Start()
    {
        Offset = transform.position - transform.position;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.position = transform.position + Offset;
        transform.RotateAround(transform.position, Vector3.up, _speed * Time.deltaTime);
        transform.Rotate(Vector3.up, _speed * Time.deltaTime);
        Offset = transform.position - transform.position;
    }
}