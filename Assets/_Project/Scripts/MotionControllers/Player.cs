using UnityEngine;

namespace FSMTest
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ObstacleCheker))]
    [RequireComponent(typeof(CoinsDetector))]
    [RequireComponent(typeof(AudioPlayer))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private ObstacleCheker _obstacleCheker;
        [SerializeField] private AnimatorHandler _animator;

        private Rigidbody2D _rigidbody;
        private CoinsDetector _coinsDetector;

        private StateMachine _stateMachine;
        private InputService _inputService;
        private RotatorTransform _rotatorTransform;
        private Wallet _wallet;
        private AudioPlayer _audioPlayer;
        private PlayerFsmFactory _playerFsmFactory;

        private void Start()
        {
            
        }

        public void Enable()
        {
            _coinsDetector.Touched += OnTouched;
        }

        private void OnDisable()
        {
            _coinsDetector.Touched -= OnTouched;
        }

        private void Update()
        {
            _rotatorTransform.Rotate(transform, _inputService.ReadInput());
            _stateMachine.Update();
        }

        private void OnTouched(Coin coin)
        {
            _wallet.Add(coin.Amount);
            _audioPlayer.Play(coin.AudioClip);
            coin.Interact();
        }

        public void Init(InputService inputService, RotatorTransform rotatorTransform, Wallet wallet, PlayerFsmFactory playerFsmFactory)
        {
            _inputService = inputService;
            _rotatorTransform = rotatorTransform;
            _wallet = wallet;
            _playerFsmFactory = playerFsmFactory;
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _coinsDetector = GetComponent<CoinsDetector>();
            _audioPlayer = GetComponent<AudioPlayer>();

            var context =
                new PlayerFSMContext(_walkSpeed, _jumpForce, _obstacleCheker, _animator, _rigidbody,
                    _inputService);

            _stateMachine = _playerFsmFactory.Create(context);
        }
    }
}