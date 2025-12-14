using UnityEngine;

namespace FSMTest
{
    public class FsmStateIdle : FsmState, IEnterableState
    {
        private ObstacleCheker _obstacleCheker;
        private AnimatorHandler _animator;
        private Rigidbody2D _rigidbody;

        public FsmStateIdle(IStateChanger stateChanger, ObstacleCheker obstacleCheker,
            AnimatorHandler animator, Rigidbody2D rigidbody) : base(stateChanger)
        {
            _obstacleCheker = obstacleCheker;
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

            if (_obstacleCheker.IsGrounded())
                _rigidbody.velocity = Vector2.zero;
        }
    }
}