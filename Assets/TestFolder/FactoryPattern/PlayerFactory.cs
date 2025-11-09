using UnityEngine;

public class PlayerFactory
{
    private Transform _spawnPoint;

    public Player Create()
    {
        var prefab = Resources.Load<GameObject>("Unit/Player");
        var go = Object.Instantiate(prefab);
        var player = go.GetComponent<Player>();
        return player;
    }
}