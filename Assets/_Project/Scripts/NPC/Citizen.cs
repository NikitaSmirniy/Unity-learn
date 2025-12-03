using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(DamageTaker))]
public class Citizen : NPC
{
    [SerializeField] private float _acceptableSwitchingDistance = 0.25f;
    
    public DamageTaker DamageTaker { get; private set; }
    
    private WayPointsContainer _wayPointsContainer;

    private void Awake()
    {
        if (_mover == null)
            _mover = GetComponent<Mover>();

        if (_wayPointsContainer == null)
            _wayPointsContainer = new WayPointsContainer(null);
                
        DamageTaker = GetComponent<DamageTaker>();
    }

    private void OnEnable()
    {
        _wayPointsContainer.Changed += _mover.SetTarget;
    }

    private void OnDisable()
    {
        _wayPointsContainer.Changed -= _mover.SetTarget;
    }

    private void Update()
    {
        if((_mover.TargetPosition.position - transform.position).sqrMagnitude <= _acceptableSwitchingDistance)
            _wayPointsContainer.Change();
    }
    
    public void Init(Transform[] wayPoints)
    {
        _wayPointsContainer = new WayPointsContainer(wayPoints);
        var startPos = wayPoints[0].transform;

        _mover = GetComponent<Mover>();
        _mover.SetTarget(startPos);
        gameObject.SetActive(true);
    }
}