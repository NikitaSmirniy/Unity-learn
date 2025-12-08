using UnityEngine;

public class BootStraper : MonoBehaviour
{
    [Header("Thief Settings")]
    [SerializeField] private Thief _thiefPrefab;
    [SerializeField] private Transform _parentOfWayPoints;
    
    [Header("Siren System Handlers Settings")]
    [SerializeField] private SirenSystemHandler _sirenSystemHandlerPrefab;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private Transform _spawnPosition;
    
    private void Awake()
    {
        CreateNPC();
    }

    private void CreateNPC()
    {
        var newThief = Instantiate(_thiefPrefab, transform.position, Quaternion.identity);
        newThief.Init(CreateWayPointsContainer());
        newThief.gameObject.SetActive(true);
        
        var newSirenHandler = Instantiate(_sirenSystemHandlerPrefab, _spawnPosition.position, Quaternion.identity);
        newSirenHandler.Init(_clip);
        newSirenHandler.gameObject.SetActive(true);
    }

    private WayPointsContainer CreateWayPointsContainer()
    {
        var wayPoints = new Transform[_parentOfWayPoints.childCount];
        
        for (int i = 0; i < _parentOfWayPoints.childCount; i++)
            wayPoints[i] = _parentOfWayPoints.GetChild(i).transform;

        return new(wayPoints);
    }
}