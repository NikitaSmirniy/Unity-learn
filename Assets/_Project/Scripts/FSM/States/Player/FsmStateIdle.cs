using UnityEngine;

namespace FSMTest
{
    public class FsmStateIdle : FsmState, IEnterableState
    {
        private PlayerAnimatorHandler _playerAnimator;
        private Rigidbody2D _rigidbody;

        public FsmStateIdle(IStateChanger stateChanger,
            PlayerAnimatorHandler playerAnimator, Rigidbody2D rigidbody) : base(stateChanger)
        {
            _playerAnimator = playerAnimator;
            _rigidbody = rigidbody;
        }

        protected override void OnUpdate()
        {
            _playerAnimator.PlayFalling((int)_rigidbody.velocity.y);
        }

        public void Enter()
        {
            _playerAnimator.SetMove(0);
        }
    }
}