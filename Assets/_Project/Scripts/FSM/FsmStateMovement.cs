using UnityEngine;

namespace FSMTest
{
    public abstract class FsmStateMovement : FsmState
    {
        protected readonly InputService _inputService;
        protected readonly AnimatorHandler _animator;
        protected readonly Rigidbody2D _rigidbody;
        protected readonly float _speed;

        public FsmStateMovement(IStateChanger stateChanger, InputService inputService, AnimatorHandler animator, Rigidbody2D rigidbody,
             float speed) : base(stateChanger)
        {
            _inputService = inputService;
            _animator = animator;
            _rigidbody =  rigidbody;
            _speed = speed;
        }

        protected virtual void Move(Vector2 inputDirection)
        {
            _rigidbody.AddForce(inputDirection * _speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}