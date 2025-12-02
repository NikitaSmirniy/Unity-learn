using UnityEngine;

public class MoverHandler : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    
    private IMovable _movable;
    
    public Transform TargetPosition { get; private set; }

    private void Awake()
    {
        _movable = new TransformMover(transform);
    }

    private void Update()
    {
        if (TargetPosition.position != Vector3.zero)
        {
            _movable?.Move((TargetPosition.position - transform.position).normalized, _moveSpeed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target) => TargetPosition = target;
}