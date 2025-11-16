using System;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [Header("Managed Instances")]
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ExplotionCubeSpawner _explotionCubeFactory;

    private Raycaster _raycaster;
    private RandomChanceGenerator _randomChanceGenerator;
    private RandomizerSpawnCubeCount _randomizerSpawnCubeCount;
    private Exploser _exploser;
    private OverlaperExplosionCube _overlaper;

    private List<IDisposable> _disposables = new();
    private List<IInitializable> _initializables = new();

    private void Awake()
    {
        _raycaster = new Raycaster(_inputReader);
        _randomChanceGenerator = new RandomChanceGenerator();
        _randomizerSpawnCubeCount = new();
        _exploser = new Exploser();
        _overlaper = new OverlaperExplosionCube();

        _disposables.Add(_raycaster);
        _initializables.Add(_raycaster);
    }

    private void Start()
    {
        foreach (var initializable in _initializables)
            initializable.Initialize();
    }

    private void OnEnable()
    => _raycaster.CubeFound += Handle;

    private void OnDisable()
    => _raycaster.CubeFound -= Handle;

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
            disposable.Dispose();
    }

    private void Handle(ExplosionCube explosionCube)
    {
        if (explosionCube.IsDying == false)
        {
            explosionCube.Die();

            int randomSpawnChance = _randomChanceGenerator.Execute();
            int randomCountCubes = _randomizerSpawnCubeCount.Execute();

            List<ExplosionCube> newExplosionCubes = new();

            if (explosionCube.SpawnChance >= randomSpawnChance)
            {
                for (int i = 0; i < randomCountCubes; i++)
                {
                    var newCube = _explotionCubeFactory.Create(explosionCube);
                    newExplosionCubes.Add(newCube);
                }
            }
            else
            {
                newExplosionCubes = _overlaper.Execute(explosionCube.transform.position, explosionCube.Radius);
            }

            foreach (var newExplosionCube in newExplosionCubes)
                _exploser.Execute(newExplosionCube.Rigidbody, newExplosionCube.Force, newExplosionCube.Radius);
        }
    }
}