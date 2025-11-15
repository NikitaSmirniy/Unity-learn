using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ExplotionCubeSpawner _explotionCubeFactory;

    private Raycaster _raycaster;
    private RandomChanceGenerator _randomChanceGenerator;

    private void Awake()
    {
        _raycaster = new Raycaster(_inputReader);
        _randomChanceGenerator = new RandomChanceGenerator();
    }

    private void OnEnable()
    => _raycaster.CubeFound += Handle;

    private void OnDisable()
    => _raycaster.CubeFound -= Handle;

    private void Handle(ExplosionCube explosionCube)
    {
        if (explosionCube.IsDying == false)
        {
            explosionCube.Die();

            int randomSpawnChance = _randomChanceGenerator.Execute();

            if (explosionCube.SpawnChance >= randomSpawnChance)
                _explotionCubeFactory.Create(explosionCube);
        }
    }
}