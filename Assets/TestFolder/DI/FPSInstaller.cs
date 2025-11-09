using UnityEngine;
using Zenject;

public class FPSInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private int _co;

    public override void InstallBindings()
    {
        //PlayerFactory playerFactory = new PlayerFactory();
        //var playerInstance = playerFactory.CreatePlayer(_playerSpawnPoint);

        //Container.Bind<Unit>().FromInstance(playerInstance).AsSingle().NonLazy();
    }
}