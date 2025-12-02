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
        if (_moverHandler == null)
            _moverHandler = GetComponent<MoverHandler>();

        if (_wayPointsContainer == null)
            _wayPointsContainer = new WayPointsContainer(null);
                
        DamageTaker = GetComponent<DamageTaker>();
    }

    private void OnEnable()
    {
        _wayPointsContainer.Changed += _moverHandler.SetTarget;
    }

    private void OnDisable()
    {
        _wayPointsContainer.Changed -= _moverHandler.SetTarget;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _moverHandler.TargetPosition.position) <= _acceptableSwitchingDistance)
            _wayPointsContainer.Change();
    }
    
    public void Init(Transform[] wayPoints)
    {
        _wayPointsContainer = new WayPointsContainer(wayPoints);
        var startPos = wayPoints[0].transform;

        _moverHandler = GetComponent<MoverHandler>();
        _moverHandler.SetTarget(startPos);
        gameObject.SetActive(true);
    }
}