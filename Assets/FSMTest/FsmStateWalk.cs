using UnityEngine;

namespace FSMTest
{
    public class FsmStateWalk : FsmStateMovement
    {
        public FsmStateWalk(IFsm fsm, Transform transform, float speed) : base(fsm, transform, speed) { }

        public override void Update()
        {
            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0)
                _fsm.SetState<FsmStateIdle>();

            if (Input.GetKeyDown(KeyCode.LeftShift))
                _fsm.SetState<FsmStateRun>();

            Move(inputDirection);
        }
    }
}
