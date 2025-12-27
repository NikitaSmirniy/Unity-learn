using UnityEngine;

namespace FSMTest
{
    public class FsmStateWalk : FsmStateMoveByInput, IEnterableState
    {
        private readonly AnimatorHandler _animator;

        public FsmStateWalk(IStateChanger stateChanger, Mover mover, float speed, InputService inputService,
            AnimatorHandler animator) : base(stateChanger, mover, speed, inputService)
        {
            _animator = animator;
        }

        protected override void OnUpdate()
        {
            var inputDirection = _inputService.Direction;
            var rbVelocity = _mover.Rigidbody.velocity.y;
            
            _animator.SetMove(inputDirection.sqrMagnitude);
            _animator.PlayFalling((int)rbVelocity);

            Move(inputDirection);
        }
        
        public void Enter()
        {
            _mover.SetSpeed(_speed);
        }
    }
}