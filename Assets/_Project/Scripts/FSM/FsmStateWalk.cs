using UnityEngine;

namespace FSMTest
{
    public class FsmStateWalk : FsmStateMovement
    {
        public FsmStateWalk(IStateChanger stateChanger, InputService inputService,
            AnimatorHandler animator, Rigidbody2D rigidbody, float speed) : base(stateChanger, inputService, animator,
            rigidbody, speed)
        {
        }

        protected override void OnUpdate()
        {
            var inputDirection = _inputService.ReadInput();

            _animator.SetMove(inputDirection.sqrMagnitude);
            _animator.PlayFalling((int)_rigidbody.velocity.y);

            Move(inputDirection);
        }
    }
}