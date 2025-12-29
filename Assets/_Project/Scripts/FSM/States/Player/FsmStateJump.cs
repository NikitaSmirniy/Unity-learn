using UnityEngine;

namespace FSMTest
{
    public class FsmStateJump : FsmStateMoveByInput, IEnterableState, IExitableState
    {
        private readonly PlayerAnimatorHandler _playerAnimator;

        public FsmStateJump(IStateChanger stateChanger, Mover mover, float speed, InputService inputService,
            PlayerAnimatorHandler playerAnimator) : base(stateChanger, mover, speed, inputService)
        {
            _playerAnimator = playerAnimator;
        }

        protected override void OnUpdate()
        {
            var rbVelocity = _mover.Rigidbody.velocity.y;
            
            _playerAnimator.PlayFalling((int)rbVelocity);
        }
        
        public void Enter()
        {
            _mover.SetSpeed(_speed);
            Move(_inputService.Direction);
            _playerAnimator.PlayJump();
        }

        public void Exit()
        {
            _playerAnimator.StopJump();
            _playerAnimator.PlayFalling((int)_mover.Rigidbody.velocity.y);
        }
        
        protected override void Move(Vector2 inputDirection)
        {
            _mover.Move(new Vector2(inputDirection.x, Vector2.up.y));
        }
    }
}