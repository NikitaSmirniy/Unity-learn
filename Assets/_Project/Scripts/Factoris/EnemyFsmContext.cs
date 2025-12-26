using UnityEngine;

public struct EnemyFsmContext
{
    public EnemyFsmContext(Mover mover, float speed, ObstacleCheker obstacleChker, AnimatorHandler animator,
        PlayerDetector playerDetector, WayPointsContainer wayPointsContainer, float acceptableSwitchingDistance,Transform target, Transform enemyTransform)
    {
        Mover = mover;
        Speed = speed;
        ObstacleCheker  = obstacleChker;
        AnimatorHandler = animator;
        PlayerDetector = playerDetector;
        WayPointsContainer = wayPointsContainer;
        AcceptableSwitchingDistance = acceptableSwitchingDistance;
        Target = target;
        EnemyTransform  = enemyTransform;
    }
    
    public Mover Mover { get;}
    public float Speed { get;}
    public ObstacleCheker ObstacleCheker { get;}
    public AnimatorHandler AnimatorHandler{ get;}
    public PlayerDetector PlayerDetector{ get;}
    public WayPointsContainer WayPointsContainer{ get;}
    public float AcceptableSwitchingDistance{ get;}
    public Transform Target{ get;}
    public Transform EnemyTransform{ get;}
}