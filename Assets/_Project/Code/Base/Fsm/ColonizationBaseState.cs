using _Project.Code;
using FSMTest;

public class ColonizationBaseState : FsmState, IExitableState
{
    private readonly Base _base;

    private int _price = 5;
    private Unit _unitBuilder;

    public ColonizationBaseState(IStateChanger stateChange, Base @base) : base(stateChange)
    {
        _base = @base;
    }

    protected override void OnUpdate()
    {
        if (_unitBuilder == null)
        {
            if (_base.Wallet.Amount >= _price && _base.Flag.IsSet)
            {
                if (_base.TryGetFreeUnit(out Unit freeUnit))
                {
                    _unitBuilder = freeUnit;

                    freeUnit.SetTarget(_base.Flag);
                    freeUnit.Built += _base.OnBuilt;
                }
            }
        }
    }

    public void Exit()
    {
        if (_unitBuilder != null)
            _unitBuilder.RemoveTarget();

        _unitBuilder = null;
    }
}