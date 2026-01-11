public struct EnemyFsmContext
{
    public EnemyFsmContext(Mover mover, float speed, ObstacleCheker obstacleChker,
        EnemyAnimatorHandler enemyAnimatorHandler,
        PlayerDetector playerDetector, WayPointsContainer wayPointsContainer, float acceptableSwitchingDistance,
        Enemy enemy, Health health)
    {
        Mover = mover;
        Speed = speed;
        ObstacleCheker = obstacleChker;
        EnemyAnimatorHandler = enemyAnimatorHandler;
        PlayerDetector = playerDetector;
        WayPointsContainer = wayPointsContainer;
        AcceptableSwitchingDistance = acceptableSwitchingDistance;
        Enemy = enemy;
        Health = health;
    }

    public Mover Mover { get; }
    public float Speed { get; }
    public ObstacleCheker ObstacleCheker { get; }
    public EnemyAnimatorHandler EnemyAnimatorHandler { get; }
    public PlayerDetector PlayerDetector { get; }
    public WayPointsContainer WayPointsContainer { get; }
    public float AcceptableSwitchingDistance { get; }
    public Enemy Enemy { get; }
    public Health Health{ get; }
}