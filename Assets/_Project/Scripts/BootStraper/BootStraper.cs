using FSMTest;
using UnityEngine;

public class BootStraper : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private void Awake()
    {
        InitPlayer();
    }

    private void OnEnable()
    {
        _player.Enable();
    }

    private void InitPlayer()
    {
        InputService inputService = new InputService();
        RotatorTransform rotatorTransform = new RotatorTransform();
        Wallet wallet = new Wallet();
        PlayerFsmFactory playerFsmFactory = new PlayerFsmFactory();
        
        _player.Init(inputService, rotatorTransform, wallet, playerFsmFactory);
    }
}