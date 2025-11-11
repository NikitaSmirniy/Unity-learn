using System;
using System.Collections.Generic;

namespace FSMTest
{
    public class Fsm : IFsm
    {
        private FsmState _stateCurrent;

        private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();

        public void AddState(FsmState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : FsmState
        {
            var type = typeof(T);

            if (_stateCurrent != null && _stateCurrent.GetType() == type)
                return;

            if (_states.TryGetValue(type, out var newState))
            {
                if (_stateCurrent is IExitableState iExitableState)
                    iExitableState?.Exit();

                _stateCurrent = newState;

                if (_stateCurrent is IEnterableState iEnterableState)
                    iEnterableState?.Enter();
            }
        }

        public void Update()
        {
            if (_stateCurrent is IUpdatebleState iUpdatebleState)
                iUpdatebleState?.Update();
        }
    }
}