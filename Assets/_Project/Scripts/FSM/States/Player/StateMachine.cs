using UnityEngine;

namespace FSMTest
{
    public class StateMachine : IStateChanger
    {
        private FsmState _stateCurrent;

        public void ChangeState(FsmState state)
        {
            if (_stateCurrent != null && _stateCurrent == state)
                return;

                if (_stateCurrent is IExitableState iExitableState)
                    iExitableState?.Exit();

                _stateCurrent = state;

                if (_stateCurrent is IEnterableState iEnterableState)
                    iEnterableState?.Enter();
        }

        public void Update()
        {
            if (_stateCurrent is IUpdatableState iUpdatableState)
                iUpdatableState?.Update();
        }
    }
}