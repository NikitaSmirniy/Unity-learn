using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSMTest
{
    public class FsmStateRun : FsmStateMovement
    {
        public FsmStateRun(IFsm fsm, Transform transform, float speed) : base(fsm, transform, speed) { }

        public override void Update()
        {
            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0)
                _fsm.SetState<FsmStateIdle>();

            if (Input.GetKeyUp(KeyCode.LeftShift))
                _fsm.SetState<FsmStateWalk>();

            Move(inputDirection);
        }
    }
}