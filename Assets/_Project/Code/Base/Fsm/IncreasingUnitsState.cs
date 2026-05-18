using FSMTest;
using UnityEngine;

namespace _Project.Code
{
    public class IncreasingUnitsState : FsmState
    {
        private readonly Base _base;
        private int _newUnitPrice = 3;
        private UnitFactory _unitFactory;
        
        public IncreasingUnitsState(IStateChanger stateChange, Base @base, UnitFactory unitFactory) : base(stateChange)
        {
            _base = @base;
            _unitFactory = unitFactory;
        }

        protected override void OnUpdate()
        {
            if (_base.Wallet.Amount >= _newUnitPrice)
            {
                _base.AddUnit(_unitFactory.Create(_base.transform));
                _base.Wallet.Remove(_newUnitPrice);
            }
        }
    }
}