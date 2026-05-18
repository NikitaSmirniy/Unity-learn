using System;
using System.Collections.Generic;

namespace FSMTest
{
    public abstract class FsmState : IUpdatableState
    {
        protected readonly IStateChanger StateChange;
        protected readonly List<Transition> Transitions = new();

        public FsmState(IStateChanger stateChange)
        {
            StateChange = stateChange;
        }

        public void AddTransition(Transition transition)
        {
            if (transition == null)
                throw new ArgumentNullException(nameof(transition));

            if (Transitions.Contains(transition))
                throw new ArgumentException(nameof(transition));

            Transitions.Add(transition);
        }

        public virtual void Update()
        {
            OnUpdate();

            foreach (Transition transition in Transitions)
            {
                FsmState nextState;

                if (transition.TryTransit(out nextState) == false)
                    continue;

                StateChange.ChangeState(nextState);

                return;
            }
        }

        protected virtual void OnUpdate()
        {
        }
    }
}