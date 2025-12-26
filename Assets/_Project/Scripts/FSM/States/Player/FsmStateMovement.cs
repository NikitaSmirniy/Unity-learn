using UnityEngine;

namespace FSMTest
{
    public abstract class FsmStateMovement : FsmState, IEnterableState
    {
        protected readonly float _speed;
        protected readonly Mover _mover;

        public FsmStateMovement(IStateChanger stateChanger, Mover mover, float speed) : base(
            stateChanger)
        {
            _mover = mover;
            _speed = speed;
        }

        public void Enter()
        {
            _mover.SetSpeed(_speed * Time.deltaTime);
        }
    }
}