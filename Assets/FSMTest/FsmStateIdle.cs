using UnityEngine;

namespace FSMTest
{
    public class FsmStateIdle : FsmState, IUpdatebleState
    {
        public FsmStateIdle(IFsm fsm) : base(fsm) { }

        public void Update()
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                _fsm.SetState<FsmStateWalk>();
        }
    }
}