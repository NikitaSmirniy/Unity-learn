using UnityEngine;

public class MoverHandler : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private IMovable _movable;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _movable = new Mover(transform);
    }

    private void Update()
    {
        if (_moveDirection != Vector3.zero)
            _movable?.Move(_moveDirection.normalized, _moveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction) => _moveDirection = direction;
}