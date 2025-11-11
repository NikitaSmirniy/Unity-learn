using UnityEngine;
<<<<<<< HEAD
using Zenject;

public class PlayerFactory : IFactory<Player>
{
    private Transform _spawnPoint;

    Player IFactory<Player>.Create()
=======

public class PlayerFactory
{
    private Transform _spawnPoint;

    public Player Create()
>>>>>>> Animation
    {
        var prefab = Resources.Load<GameObject>("Unit/Player");
        var go = Object.Instantiate(prefab);
        var player = go.GetComponent<Player>();
        return player;
    }
}