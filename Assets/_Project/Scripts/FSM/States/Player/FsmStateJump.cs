using UnityEngine;

namespace FSMTest
{
    public class FsmStateJump : FsmStateMoveByInput, IEnterableState, IExitableState
    {
        private readonly AnimatorHandler _animator;

        public FsmStateJump(IStateChanger stateChanger, Mover mover, float speed, InputService inputService,
            AnimatorHandler animator) : base(stateChanger, mover, speed, inputService)
        {
            _animator = animator;
        }

        protected override void OnUpdate()
        {
            var rbVelocity = _mover.Rigidbody.velocity.y;
            
            _animator.PlayFalling((int)rbVelocity);
        }
        
        public void Enter()
        {
            _mover.SetSpeed(_speed);
            Move(_inputService.Direction);
            _animator.PlayJump();
        }

        public void Exit()
        {
            _animator.StopJump();
            _animator.PlayFalling((int)_mover.Rigidbody.velocity.y);
        }
        
        protected override void Move(Vector2 inputDirection)
        {
            _mover.Move(new Vector2(inputDirection.x, Vector2.up.y));
        }
    }
}