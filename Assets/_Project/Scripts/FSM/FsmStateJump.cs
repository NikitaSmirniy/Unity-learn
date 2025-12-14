using UnityEngine;

namespace FSMTest
{
    public class FsmStateJump : FsmStateMovement, IEnterableState
    {
        public FsmStateJump(IStateChanger stateChanger, InputService inputService,
            AnimatorHandler animator, Rigidbody2D rigidbody, float speed) : base(stateChanger, inputService, animator,
            rigidbody,
            speed)
        {
        }

        protected override void OnUpdate()
        {
            var inputDirection = _inputService.ReadInput();

            Move(inputDirection);
        }

        protected override void Move(Vector2 inputDirection)
        {
            _rigidbody.AddForce(new Vector3(inputDirection.normalized.x, Vector2.up.y, 0) *
                                (_speed * Time.deltaTime), ForceMode2D.Impulse);
        }

        public void Enter()
        {
            _animator.PlayJump();
        }
    }
}