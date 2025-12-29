using UnityEngine;

namespace FSMTest
{
    public class FsmStateWalk : FsmStateMoveByInput, IEnterableState
    {
        private readonly PlayerAnimatorHandler _playerAnimator;

        public FsmStateWalk(IStateChanger stateChanger, Mover mover, float speed, InputService inputService,
            PlayerAnimatorHandler playerAnimator) : base(stateChanger, mover, speed, inputService)
        {
            _playerAnimator = playerAnimator;
        }

        protected override void OnUpdate()
        {
            var inputDirection = _inputService.Direction;
            var rbVelocity = _mover.Rigidbody.velocity.y;
            
            _playerAnimator.SetMove(inputDirection.sqrMagnitude);
            _playerAnimator.PlayFalling((int)rbVelocity);

            Move(inputDirection);
        }
        
        public void Enter()
        {
            _mover.SetSpeed(_speed);
        }
    }
}