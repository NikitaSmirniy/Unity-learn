using UnityEngine;

namespace FSMTest
{
    public class FsmStateIdle : FsmState, IEnterableState
    {
        private AnimatorHandler _animator;
        private Rigidbody2D _rigidbody;

        public FsmStateIdle(IStateChanger stateChanger,
            AnimatorHandler animator, Rigidbody2D rigidbody) : base(stateChanger)
        {
            _animator = animator;
            _rigidbody = rigidbody;
        }

        protected override void OnUpdate()
        {
            _animator.PlayFalling((int)_rigidbody.velocity.y);
        }

        public void Enter()
        {
            _animator.SetMove(0);
        }
    }
}