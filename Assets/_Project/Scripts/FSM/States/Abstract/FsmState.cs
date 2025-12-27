using System;
using System.Collections.Generic;

namespace FSMTest
{
    public abstract class FsmState : IUpdatableState
    {
        private readonly IStateChanger _stateChange;
        private readonly List<Transition> _transitions = new();

        public FsmState(IStateChanger stateChange)
        {
            _stateChange = stateChange;
        }

        public void AddTransition(Transition transition)
        {
            if (transition == null)
                throw new ArgumentNullException(nameof(transition));
            
            if (_transitions.Contains(transition))
                throw new ArgumentException(nameof(transition));

            _transitions.Add(transition);
        }

        public void Update()
        {
            OnUpdate();

            foreach (Transition transition in _transitions)
            {
                if (transition.TryTransit(out FsmState nextState) == false)
                    continue;

                _stateChange.ChangeState(nextState);
                
                return;
            }
        }

        protected virtual void OnUpdate(){}
    }
}