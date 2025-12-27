using UnityEngine;

namespace FSMTest
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ObstacleCheker))]
    [RequireComponent(typeof(CoinsDetector))]
    [RequireComponent(typeof(AudioPlayer))]
    [RequireComponent(typeof(InputService))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private ObstacleCheker _obstacleCheker;
        [SerializeField] private AnimatorHandler _animator;

        private CoinsDetector _coinsDetector;

        private StateMachine _stateMachine;
        private InputService _inputService;
        private RotatorTransform _rotatorTransform;
        private Wallet _wallet;
        private AudioPlayer _audioPlayer;
        private PlayerFsmFactory _playerFsmFactory;
        
        public Rigidbody2D Rigidbody {get; private set;}

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
            _rotatorTransform.Rotate(transform, _inputService.Direction);
            _stateMachine.Update();
        }

        public void Init(RotatorTransform rotatorTransform, Wallet wallet ,PlayerFsmFactory playerFsmFactory)
        {
            _rotatorTransform = rotatorTransform;
            _wallet = wallet;
            _playerFsmFactory = playerFsmFactory;
            
            Rigidbody = GetComponent<Rigidbody2D>();
            _coinsDetector = GetComponent<CoinsDetector>();
            _audioPlayer = GetComponent<AudioPlayer>();
            _inputService = GetComponent<InputService>();
            
            Mover mover = new Mover(Rigidbody, Vector2.zero);
            
            var context =
                new PlayerFSMContext(_walkSpeed, _jumpForce, _obstacleCheker, _animator, Rigidbody,
                    _inputService, mover);

            _stateMachine = _playerFsmFactory.Create(context);
        }
        
        private void OnTouched(Coin coin)
        {
            _wallet.Add(coin.Amount);
            _audioPlayer.Play(coin.AudioClip);
            coin.Interact();
        }
    }
}