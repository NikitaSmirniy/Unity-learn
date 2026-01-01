using UnityEngine;

public class PlayerModel : MonoBehaviour, IGameData
{
    public int Health { get; set; }

    public void AddHealth()
    {
        Health++;
    }
}