using System.Collections;
using System;
using UnityEngine;

public class AbilityTimer : ITimerModel, IActionActivateObserver
{
    private float _workCurrentTimeWork = 0f;
    private float _cooldownCurrentTime = 0f;

    private float _timeWork;
    private float _cooldown;

    private bool _isCoolingDown;

    private ICorouitinesRunner _corouitinesRunner;
    private Coroutine _workCoroutine;
    private Coroutine _cooldownCoroutine;

    public float CurrentWorkTime => _workCurrentTimeWork;
    public float WorkTime => _timeWork;
    public float CurrentCooldown => _cooldownCurrentTime;
    public float Cooldown => _cooldown;

    public event Action WorkTimeChanged;
    public event Action CooldownChanged;
    public event Action ActionStarted;
    public event Action ActionEnded;
    public event Action ActionIsDone;
    
    public AbilityTimer(AbilityTimerData abilityTimerTimerData, ICorouitinesRunner corouitinesRunner)
    {
        _timeWork = abilityTimerTimerData.TimeWork;
        _cooldown = abilityTimerTimerData.Cooldown;

        _corouitinesRunner = corouitinesRunner;
    }

    public void StartAction(Action action)
    {
        if (_workCoroutine == null && _isCoolingDown == false)
            _workCoroutine = _corouitinesRunner.StartRoutine(AbilityWorkRoutine(action));
    }

    private IEnumerator AbilityWorkRoutine(Action action)
    {
        _workCurrentTimeWork = _timeWork;
        
        ActionStarted?.Invoke();

        while (_workCurrentTimeWork >= 0)
        {
            action?.Invoke();

            _workCurrentTimeWork -= Time.deltaTime;

            WorkTimeChanged?.Invoke();

            yield return null;
        }

        _workCoroutine = null;

        ActionEnded?.Invoke();

        _cooldownCoroutine = _corouitinesRunner.StartRoutine(CoolDownRoutine());
    }

    private IEnumerator CoolDownRoutine()
    {
        _isCoolingDown = true;

        _cooldownCurrentTime = _cooldown;

        while (_cooldownCurrentTime >= 0)
        {
            _cooldownCurrentTime -= Time.deltaTime;

            CooldownChanged?.Invoke();

            yield return null;
        }

        ActionIsDone?.Invoke();
        
        _cooldownCoroutine = null;
        _isCoolingDown = false;
    }
}