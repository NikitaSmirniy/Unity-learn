using UnityEngine;
using UnityEngine.Serialization;

namespace FSMTest
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ObstacleCheker))]
    [RequireComponent(typeof(CoinsDetector))]
    [RequireComponent(typeof(MedKitDetector))]
    [RequireComponent(typeof(AudioPlayer))]
    [RequireComponent(typeof(InputService))]
    [RequireComponent(typeof(PlayerHealth))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private ObstacleCheker _obstacleCheker;
        [SerializeField] private PlayerAnimatorHandler _playerAnimator;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Transform _rotateableObject;

        private CoinsDetector _coinsDetector;
        private MedKitDetector _medKitDetector;

        private StateMachine _stateMachine;
        private InputService _inputService;
        private RotatorTransform _rotatorTransform;
        private Wallet _wallet;
        private AudioPlayer _audioPlayer;
        
        public Rigidbody2D Rigidbody {get; private set;}

        public void Enable()
        {
            _coinsDetector.Touched += OnCoinTouched;
            _medKitDetector.Touched += OnMedKitTouched;
        }

        private void OnDisable()
        {
            _coinsDetector.Touched -= OnCoinTouched;
            _medKitDetector.Touched -= OnMedKitTouched;
        }

        private void Update()
        {
            _rotatorTransform.Rotate(_rotateableObject, _inputService.Direction);
            _stateMachine.Update();
        }

        public void Init(RotatorTransform rotatorTransform, Wallet wallet, PlayerFsmFactory playerFsmFactory,
            Health health)
        {
            _rotatorTransform = rotatorTransform;
            _wallet = wallet;
            
            Rigidbody = GetComponent<Rigidbody2D>();
            _coinsDetector = GetComponent<CoinsDetector>();
            _medKitDetector = GetComponent<MedKitDetector>();
            _audioPlayer = GetComponent<AudioPlayer>();
            _inputService = GetComponent<InputService>();
            _playerHealth = GetComponent<PlayerHealth>();
            
            _playerHealth.Init(health);
            
            Mover mover = new Mover(Rigidbody);
            
            var context =
                new PlayerFSMContext(_walkSpeed, _jumpForce, _obstacleCheker, _playerAnimator, Rigidbody,
                    _inputService, mover, health);

            _stateMachine = playerFsmFactory.Create(context);
        }
        
        private void OnCoinTouched(Coin coin)
        {
            _wallet.Add(coin.Amount);
            _audioPlayer.Play(coin.AudioClip);
            coin.Interact();
        }
        
        private void OnMedKitTouched(MedKit medKit)
        {
            _playerHealth.Cure(medKit.Amount);
            _audioPlayer.Play(medKit.AudioClip);
            medKit.Interact();
        }
    }
}