using UnityEngine;

namespace FSMTest
{
    public class FSMTest : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;

        private Fsm _fsm;

        private void Start()
        {
            _fsm = new Fsm();

            _fsm.AddState(new FsmStateIdle(_fsm));
            _fsm.AddState(new FsmStateWalk(_fsm, transform, _walkSpeed));
            _fsm.AddState(new FsmStateRun(_fsm, transform, _runSpeed));

            _fsm.SetState<FsmStateIdle>();
        }

        private void Update()
        {
            _fsm.Update();
        }
    }
}