using System;

public class Ability : IDisposable
{
    private VampireAbilityAction _vampireAbilityAction;
    private TargetAbilityOverlapSelector _targetAbilitySelector;
    private InputService _inputService;
    private AbilityTimer _abilityTimer;

    public Ability(VampireAbilityAction vampireAbilityAction, TargetAbilityOverlapSelector targetAbilitySelector,
        InputService inputService, AbilityTimer  abilityTimer)
    {
        _vampireAbilityAction = vampireAbilityAction;
        _targetAbilitySelector = targetAbilitySelector;
        _inputService = inputService;
        _abilityTimer = abilityTimer;

        _inputService.OnAbillityKeyDown += ApplyAction;
    }

    public void Dispose()
    {
        _inputService.OnAbillityKeyDown -= ApplyAction;
    }

    private void ApplyAction()
    {
        _abilityTimer.StartAction(() => _vampireAbilityAction.Action(_targetAbilitySelector.SelectTarget()));
    }
}