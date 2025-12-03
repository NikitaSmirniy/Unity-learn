using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;

    public Transform TargetPosition { get; private set; }

    private void Update()
    {
        if (TargetPosition.position != Vector3.zero)
            Move((TargetPosition.position - transform.position).normalized, _moveSpeed * Time.deltaTime);
    }

    private void Move(Vector3 direction, float moveSpeed) =>
        transform.position += (direction * moveSpeed);

    public void SetTarget(Transform target) =>
        TargetPosition = target;
}