using UnityEngine;

public class ObstacleCheker : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private Transform _checkPoint2;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _obstacleLayerMask;
    [SerializeField] private float _radius;
    [SerializeField] private float _range;

    public bool HasObstacle(Vector2 direction)
    {
        return Physics2D.Raycast(_checkPoint2.position, direction , _range, _groundLayerMask); 
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_checkPoint.position, _radius, _groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_checkPoint.position, _radius);
        Gizmos.DrawRay(_checkPoint2.position, Vector2.right * _range);
    }
}