using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundedChecker : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private LayerMask _obstacleLayerMask;
    [SerializeField] private float _range;

    
    public bool HasObstacle(Vector2 direction)
    {
        return Physics2D.OverlapCircle(_checkPoint.position, _range, _obstacleLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_checkPoint.position, _range);
    }
}