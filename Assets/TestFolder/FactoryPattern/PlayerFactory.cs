using UnityEngine;
using Zenject;

public class PlayerFactory : IFactory<Player>
{
    private Transform _spawnPoint;

    Player IFactory<Player>.Create()
    {
        var prefab = Resources.Load<GameObject>("Unit/Player");
        var go = Object.Instantiate(prefab);
        var player = go.GetComponent<Player>();
        return player;
    }
}