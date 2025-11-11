using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        var playerInstance = Container.InstantiatePrefabForComponent<Player>(_player
            , _spawnPoint.position, Quaternion.identity, null);

        Container.BindInterfacesAndSelfTo<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
    }
}